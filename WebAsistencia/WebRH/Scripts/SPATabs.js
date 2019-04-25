///este módulo sirve para convertir una página con tabs
///en una SinglePageApp (maneja el 'back' y 'forward' del navegador)
///
///los componentes del html que tengan el atributo on_next="#nombre_de_tab"
///disparan un evento de mostrar ese otro tab, y cambiar la url en el browser
///los tabs en el html tienen que tener el id="#nombre_de_tab"
///
///los componentes del html que tengan el atriibuto on_leave="#nombre_de_tabe"
///disparan un evento de mostrar ese otro tab, y cambiar la url en el browser pero sin ejecutar la funcion "on_next"
///osea, es como presionar "back", sin avanzar. Es para los casos en los que se quiere mostrar otro tab sin, por ejemplo "guardar" 
///o alguna otra cosa.

define(['jquery','underscore'], function ($, _) {

    
    var do_nothing = function () { 
        
    }

    
    var just_go_next = function(go_next) {
        go_next()
    }

    var mostrarTab = function (tab_name) {
        $('[role="tabpanel"]').hide()
        $(tab_name).show()
    }

    var tab_definition_from_url = function (url) {
        if (!url) {
            return {
                name: '',
                parameters: []
            }
        }
        var tab_definition = url.split('/')
        var tab_name = tab_definition[0]
        tab_definition.shift()

        return {
            name: tab_name,
            parameters: tab_definition
        }
    }

    ///devuelve la configuracion del tab dado "tab_name"
    ///segun el mapa de configuraciones "tab_events"
    var get_tab_config = function(tabs_events, tab_name) {
        var tab_config = _.find(tabs_events, function (each) { return each.tab_name == tab_name })
        if (!tab_config) {
            tab_config = {
                tab_name: tab_name,
            }
        }

        //por default no hacer nada
        if (!tab_config.on_next) {
            tab_config.on_next = just_go_next
        }

        //por default no hacer nada
        if (!tab_config.on_enter) {
            tab_config.on_enter = do_nothing
        }
        return tab_config
    }

    
    ///establece el parametro en la url (#blah/param) para los links que vayan hacia atras (back_actions).
    var set_url_to_back_actions = function (next_tab, leaving_tab) {

        var back_actions = $('[on_leave]')
        back_actions.each(function (index) {
            var url = this.attributes.on_leave.value

            //si apunta al tab anterior (si apunta a algún otro tab, no modificarlo)
            var url_split = url.split('/')
            if (url_split[0] === next_tab.name || url_split[0] === leaving_tab.name) {
                this.attributes.on_leave.value = url_split[0] + '/' + next_tab.parameters.join('/')
            }
        })
    }


    var on_tab_leave_cb = function (next_tab, tabs_events, current_tab) {
        var on_tab_leave = function (next_tab_params) {
            var next_tab_url = next_tab.name
            
            var new_url = next_tab.name
            if (next_tab_params) {
                next_tab.parameters = next_tab_params
            }
            if (next_tab.parameters) {
                new_url += '/' + next_tab.parameters.join('/')
            }

            next_tab_params = next_tab.parameters

            mostrarTab(next_tab_url, next_tab_params)

            history.pushState(null, null, new_url);
            var entering_tab_config = get_tab_config(tabs_events, next_tab.name)
            
            set_url_to_back_actions(next_tab, current_tab)
            entering_tab_config.on_enter(next_tab.parameters)
        }
        return on_tab_leave
    }

    //el tab que está viendo el user (basado en la url)
    var get_current_tab = function () {
        return tab_definition_from_url(location.hash)
    }


    var change_tab = function (destination_tab_id, tabs_events, es_on_next) {

        var destination_tab = tab_definition_from_url(destination_tab_id)

        var current_tab = get_current_tab()
        var current_tab_config = get_tab_config(tabs_events, current_tab.name)

        var url_param = current_tab.parameters

        //tab_leave se produce siempre que se sale de una solapa, sea por que se presionó "next" o se hizo back
        var on_tab_leave = on_tab_leave_cb(destination_tab, tabs_events, current_tab)

        if (es_on_next) {
            current_tab_config.on_next(on_tab_leave, url_param, es_on_next)
        } else {
            just_go_next(on_tab_leave)
        }
    }

    var formSubmitted = function (event) {
        event.data = this.tabs_events
        on_next_click(event)
    }

    var on_next_click = function (event) {
        event.preventDefault();
        var tabs_events = event.data
        change_tab(event.currentTarget.attributes.on_next.value, tabs_events, true)
    }

    var on_leave_click = function (event) {
        event.preventDefault();
        var tabs_events = event.data
        change_tab(event.currentTarget.attributes.on_leave.value, tabs_events, false)
    }

    ///recibe tabs_events, con los métodos definiendo las acciones a realizar por cada solapa, de la forma:
    ///var tabs_config = [
    /// {
    ///    tab_name: '#scr_home',      <--nombre del tab html
    ///    on_next: on_scr_home_next   <--funcion evaluada al presionar "next" (que es un boton html tipo <button on_next="#siguiente_tab">)
    ///    on_enter: on_scr_home_enter <-- funcion evaluada al entrar al tab
    /// }, ...
    ///]
    var createTabs = function () {

        appendTabsTo('', this.tabs_events)

        //start in the tab form the url
        var start_tab = location.hash
        if (location.hash === "") {
            start_tab = starting_tab()
        }
        change_tab(start_tab, tabs_events, false)
    }


    //funcion para agregar los links a otros tabs 
    //a un componente jquery (en general, es para cuando se re-dibuja una grilla)
    var appendTabsTo = function (component_id, tabs_events ) {
        this.tabs_events = this.tabs_events || tabs_events
        tabs_events = this.tabs_events
        if (component_id) component_id += ' '
        $(component_id + 'a[on_next]').unbind('click', on_next_click)
        $(component_id + 'a[on_next]').click(tabs_events, on_next_click)

        $(component_id + 'button[on_next]').unbind('click', on_next_click)
        $(component_id + 'button[on_next]').click(tabs_events, on_next_click)

        $(component_id + 'a[on_leave]').unbind('click', on_leave_click)
        $(component_id + 'a[on_leave]').click(tabs_events, on_leave_click)

        $(component_id + 'li[on_leave]').unbind('click', on_leave_click)
        $(component_id + 'li[on_leave]').click(tabs_events, on_leave_click)
    }

    var starting_tab = function () {
        return '#' + $('[role="tabpanel"]').first().attr('id')
    }

    var goHome = function () {
        change_tab(starting_tab(), this.tabs_events, false)
    }

    ///devuelve el parametro en la url (despues de la "/")
    var getParams = function () {
        var def = tab_definition_from_url(location.hash)
        return def.parameters
    }

    window.addEventListener("popstate", function (e) {
        var tab = tab_definition_from_url(location.hash)
        var activeTab = $(tab.name);
        if (activeTab.length) {
            var url_param =  tab.parameters
            mostrarTab(tab.name)
        } else {
            mostrarTab('#scr_home')
        }
    });


    ///tomar todos los links del tab actual, que apunten a la siguiente tab, y agregarles el parametro
    var setNextParameter = function (new_parameter) {
        var current_tab = get_current_tab()

        var next_actions = $(current_tab.name).find('[on_next]')
        next_actions.each(function (index) {
            var url = this.attributes.on_next.value
            this.attributes.on_next.value = url.split('/')[0] + '/' + new_parameter
        })
    }

    var addTabs = function (tabs) {
        this.tabs_events = this.tabs_events || []

        _.each(tabs, tab => {
            var tab_def = {}
            tab_def.tab_name = tab.tab_name
            if (tab.on_next) {
                tab_def.on_next = tab.on_next
            }

            if (tab.on_tab_enter) {
                tab_def.on_enter = tab.on_tab_enter
            }

            this.tabs_events.push(tab_def)

            if (tab.init) {
                tab.init()
            }
        })
    }

    return {
        createTabs: createTabs,
        getParams: getParams,
        setNextParameter: setNextParameter,
        goHome: goHome,
        formSubmitted: formSubmitted,
        addTabs: addTabs,
        appendTabsTo: appendTabsTo
    }
})