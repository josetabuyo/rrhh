define(['jquery','underscore'], function ($, _) {

    var update_spinner = function () {
        var $modal_element = $('.spinner-modal')
        if (this.req_count > 0) {

            //se pone el event handler de onload, porque si se completa
            //el request antes de que esto termine de mostrarse, 
            //el 'hide' se ejecuta antes de que el modal haya sido mostrado, 
            //y no tiene efecto.
            $modal_element.unbind('shown.bs.modal')
            var _this = this
            $modal_element.on('shown.bs.modal', function (e) {
                _this.update_spinner()
            })
            $modal_element.modal('show')
        } else {
            $modal_element.modal('hide')
        }
    }

    var parallel = function(requests, cb, avoid_spinner) {

        this.req_count = this.req_count || 0

        if (!avoid_spinner) {
            this.req_count += requests.length
            this.update_spinner()
        }

        Promise.all(requests.map(req =>
            fetch('http://localhost:43414/AjaxWS.asmx/EjecutarEnBackend', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify(req)
            })
        ))
            .then(respuestas => {
                return Promise.all(respuestas.map(r => r.json()))
            })
            .then(responses => {
            var respuestas = responses.map((res) => {
                    if (res.hasOwnProperty('d')) {
                        return JSON.parse(res.d)
                    } else {
                        return res
                    }
                })
                if (!avoid_spinner) {
                    this.req_count -= respuestas.length
                    this.update_spinner()
                }
                try {
                    cb(null, respuestas)
                } catch (e) {
                    alert('Se produjo al recibir la respuesta del servidor, consulte la consola para ver detalles')
                    console.log(e)
                }
        }).catch(err => cb(err))
    }

    return {
        parallel: parallel,
        update_spinner: update_spinner
    }
})
