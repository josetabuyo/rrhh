define(['jquery','underscore'], function ($, _) {

    var update_spinner = function() {
        if (this.req_count > 0) {
            $('.spinner-modal').modal('show')
        } else {
            $('.spinner-modal').modal('hide')
        }
    }

    var parallel = function(requests, cb) {

        this.req_count = this.req_count || 0
        this.req_count += requests.length
        this.update_spinner()

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
                this.req_count -= respuestas.length
                update_spinner()
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
