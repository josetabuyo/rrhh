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
                cb(err)
                return
            }
            if (res[0].ExceptionType) {
                cb(err)
                return
            }
            state = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData'))
            var comite_agregado = res[0]
            state.GetAllComites.push(comite_agregado)
            window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify(state))
            cb(null, comite_agregado)
        })
    }

    var GetPeriodo = function (idPeriodo) {
        var periodos = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData')).GetPeriodosEvaluacion
        return _.find(periodos, p => p.id_periodo == idPeriodo)
    }

    var GetUnidadesEvaluacion = function () {
        var ues = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData')).GetEstadosEvaluacionesPeriodosActivos
        return ues
    }

    var GetComite = function (idComite) {
        var comites = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData')).GetAllComites
        return _.find(comites, c => c.Id == idComite)
    }

    var PeriodoDe = function (idComite) {
        return GetComite(idComite).Periodo
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
                return
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
            onSuccess(lista_personas)
        })
    }

    var GetCaracteres = function () {
        return [{ Id: '1', Descripcion: 'Representante Gremial UPCN' },
            { Id: '2', Descripcion: 'Representante Gremial ATE' },
            { Id: '3', Descripcion: 'Coordinador del proceso de Selección' },
            { Id: '4', Descripcion: 'Evaluador' },
        ]
    }

    var GetEnCaracterDe = function (id) {
        var caracteres = GetCaracteres()
        return _.find(caracteres, c => { return c.Id == id }).Descripcion
    }

    var DelIntegrante = function (id_integrante, idComite, cb) {
        var req = [{
            nombre_metodo: "EvalRemoverIntegranteComite",
            argumentos_json: [idComite, id_integrante]
        }]

        ws.parallel(req, function (err, res) {
            if (err) {
                cb(err)
                return
            }
            if (res[0].DioError) {
                cb(res[0].MensajeDeErrorAmigable)
                return
            }
            //var id_integrante = res[0].Respuesta

            app_data = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData'))
            var c = _.find(app_data.GetAllComites, c => c.Id == idComite)
            c.Integrantes = _.reject(c.Integrantes, i => i.IdPersona == id_integrante)
            window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify(app_data))
            cb(null, id_integrante)
        })       
    }

    var AddIntegrante = function (integrante, idComite, cb) {
        var req = [{
            nombre_metodo: "EvalAddIntegranteComite",
            argumentos_json: [idComite, JSON.stringify(integrante)]
        }]

        ws.parallel(req, function (err, res) {
            if (err) {
                cb(err)
                return
            }
            if (res[0].DioError) {
                cb(res[0].MensajeDeErrorAmigable)
                return
            } 
            var id_integrante = res[0].Respuesta

            app_data = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData'))
            var c = _.find(app_data.GetAllComites, c => c.Id == idComite)
            c.Integrantes.push(integrante)
            window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify(app_data))
            cb(null, id_integrante)
        })
    }

    var EvalAddUnidadEvaluacionAComite = function (id_comite, id_ue, cb) {
        var req = [{
            nombre_metodo: "EvalAddUnidadEvaluacionAComite",
            argumentos_json: [id_comite, id_ue]
        }]

        ws.parallel(req, function (err, res) {
            if (err) {
                cb(err)
                return
            }
            if (res[0].DioError) {
                cb(res[0].MensajeDeErrorAmigable)
                return
            }
            var ue = _.find(GetUnidadesEvaluacion(), e => e.Id == id_ue)
            app_data = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData'))
            var c = _.find(app_data.GetAllComites, c => c.Id == id_comite)
            c.UnidadesEvaluacion.push(ue)
            window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify(app_data))

            cb(null, res[0])
        })
    }

    var EvalRemoveUnidadEvaluacionAComite = function (id_comite, id_ue, cb) {
        var req = [{
            nombre_metodo: "EvalRemoveUnidadEvaluacionAComite",
            argumentos_json: [id_comite, id_ue]
        }]

        ws.parallel(req, function (err, res) {
            if (err) {
                cb(err)
                return
            }
            if (res[0].DioError) {
                cb(res[0].MensajeDeErrorAmigable)
                return
            }

            app_data = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData'))
            var c = _.find(app_data.GetAllComites, c => c.Id == id_comite)
            c.UnidadesEvaluacion = _.reject(c.UnidadesEvaluacion, ue => ue.Id == id_ue)
            window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify(app_data))

            cb(null, res[0])
        })
    }
    var OnStateChange = function (observer) {
        this.observers = this.observers || []
        this.observers.push(observer)
    }

    var StateChanged = function () {
        this.observers = this.observers || []
        _.each(this.observers, each => each())
    }

    //API del modulo
    return {
        AddComite: AddComite,
        GetDataGridPeriodos: GetDataGridPeriodos,
        BuscarPersonas: BuscarPersonas,
        GetPeriodo: GetPeriodo,
        PeriodoDe: PeriodoDe,
        GetComite: GetComite,
        AddIntegrante: AddIntegrante,
        GetCaracteres: GetCaracteres,
        GetEnCaracterDe: GetEnCaracterDe,
        DelIntegrante: DelIntegrante,
        GetUnidadesEvaluacion: GetUnidadesEvaluacion,
        EvalAddUnidadEvaluacionAComite: EvalAddUnidadEvaluacionAComite,
        EvalRemoveUnidadEvaluacionAComite: EvalRemoveUnidadEvaluacionAComite,
        OnStateChange: OnStateChange,
        StateChanged: StateChanged

    }
})