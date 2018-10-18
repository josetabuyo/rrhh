///En este módulo se gestiona el estado de la aplicacion (sección Evaluación de desempeño)
///Se sirve para ello de: 
///                 ws de viáticos, 
///                 localStorage['ComitesDeEvaluacionData'] como "cache"
///
///En esta 'capa' nos aseguramos de tener sincronizados los datos de la caché (localStorage)
///con el estado de los datos en el backend
define(['wsviaticos', 'underscore'], function (ws, _) {

    //cargar todos los datos necesarios para completar la grilla de periodos
    var GetDataGridPeriodos = function (cb) {
        //var traigo todos los datos del backend en paralelo y los guardo en el local storage
        if (!window.localStorage.getItem('ComitesDeEvaluacionData')) {
            var requests = [
                { nombre_metodo: "GetAllComites", argumentos_json: [] },
                { nombre_metodo: "GetEstadosEvaluacionesPeriodosActivos", argumentos_json: [] },
                { nombre_metodo: "GetAgentesEvaluablesParaComites", argumentos_json: [] },
                { nombre_metodo: "GetPeriodosEvaluacion", argumentos_json: [] }
            ]
            ws.parallel(requests, function (err, res) {
                if (err) {
                    console.log('Se produjo un error ' + err)
                    return
                }
                window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify({
                    GetAllComites: res[0],
                    GetEstadosEvaluacionesPeriodosActivos: res[1],
                    GetAgentesEvaluablesParaComites: res[2],
                    GetPeriodosEvaluacion: res[3]
                }))
                cb(JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData')))
            })
        } else {
            cb(JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData')))
        }
    }


    //guardar un comité nuevo
    var AddComite = function (descripcion, fecha, hora, lugar, periodo, cb) {
        var req = [{
            nombre_metodo: "AgregarComiteEvaluacionDesempenio",
            argumentos_json: [descripcion, fecha, hora, lugar, periodo]
        }]
        ws.parallel(req, function (err, res) {
            if (err) {
                alert("se produjo un error al guardar " + err)
                return
            }
            state = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData'))
            var comite_agregado = res [0]
            state.GetAllComites.push(comite_agregado)
            window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify(state))
            cb(res)
        })
    }

    var GetPeriodo = function (idPeriodo) {
        var periodos = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData')).GetPeriodosEvaluacion
        return _.find(periodos, p => p.id_periodo == idPeriodo)
    }

    var BuscarPersonas = function (criterio, onSuccess, onError) {
        var req = [{
            nombre_metodo: "BuscarPersonas",
            argumentos_json: [criterio]
        }]

        ws.parallel(req, function (err, res) {
            if (err) {
                //alert("se produjo un error al obtener datos personales " + err)
                onError(err)
                //return
            }
            var personas_json = res[0]
            var lista_personas = [];
            for (var i = 0; i < personas_json.length; i++) {
                var persona_json = personas_json[i];
                lista_personas.push({
                    id: persona_json.Id,
                    nombre: persona_json.Nombre,
                    apellido: persona_json.Apellido,
                    legajo: persona_json.Legajo,
                    documento: persona_json.Documento
                });
            }
            onSuccess(lista_personas);
        })
    }


    //API del modulo
    return {
        AddComite: AddComite,
        GetDataGridPeriodos: GetDataGridPeriodos,
        BuscarPersonas: BuscarPersonas,
        GetPeriodo: GetPeriodo
    }

})