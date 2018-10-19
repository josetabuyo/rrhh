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

define(['jquery'], function ($) {

    
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
                parameter: ''
            }
        }
        var tab_definition = url.split('/')
        var tab_name = tab_definition[0]
        var tab_parameter = tab_definition[1]
        return {
            name: tab_name,
            parameter: tab_parameter
        }
    }

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


    var change_tab = function (destination_tab_id, tabs_events, es_on_next) {

        var next_tab = tab_definition_from_url(destination_tab_id)

        var leaving_tab = tab_definition_from_url(location.hash)
        var leaving_tab_config = get_tab_config(tabs_events, leaving_tab.name)

        var url_param = leaving_tab.parameter
        var on_tab_leave = function (param) {
            var next_tab_url = next_tab.name
            mostrarTab(next_tab_url, param)
            var url = next_tab.name
            if (param) {
                next_tab.parameter = param
            }
            if (next_tab.parameter) {
                url += '/' + next_tab.parameter
            }
            history.pushState(null, null, url);
            var entering_tab_config = get_tab_config(tabs_events, next_tab.name)
            entering_tab_config.on_enter(next_tab.parameter)
        }
        if (es_on_next) {
            leaving_tab_config.on_next(on_tab_leave, url_param, es_on_next)
        } else {
            just_go_next(on_tab_leave)
        }
        
    }

    ///recibe tabs_config, con los métodos definiendo las acciones a realizar por cada solapa, de la forma:
    ///var tabs_config = [
    /// {
    ///    tab_name: '#scr_home',      <--nombre del tab html
    ///    on_next: on_scr_home_next   <--funcion evaluada al presionar "next" (que es un boton html tipo <button on_next="#siguiente_tab">)
    ///    on_enter: on_scr_home_enter <-- funcion evaluada al entrar al tab
    /// }, ...
    ///]
    var createTabs = function (tabs_events) {
        $('[on_next]').click(function (e) {
            e.preventDefault();
            change_tab(event.currentTarget.attributes.on_next.value, tabs_events, true)
        })
        $('[on_leave]').click(function (e) {
            e.preventDefault();
            change_tab(event.currentTarget.attributes.on_leave.value, tabs_events, false)
        })
        
    }

    var getParam = function () {
        var def = tab_definition_from_url(location.hash)
        return def.parameter
    }

    window.addEventListener("popstate", function (e) {
        var tab = tab_definition_from_url(location.hash)
        var activeTab = $(tab.name);
        if (activeTab.length) {
            var url_param =  tab.parameter
            mostrarTab(tab.name)
        } else {
            mostrarTab('#scr_home')
        }
    });

    return {
        createTabs: createTabs,
        getParam: getParam
    }
})