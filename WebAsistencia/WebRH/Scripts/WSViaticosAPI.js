define(['underscore'], function (_) {

    var handleErrors = function (response) {
        if (response.some(r => !r.ok)) {
            throw Error(response.find(r => !r.ok).statusText);
        }
        return response;
    }

    function parallel(requests, cb) {
        Promise.all(requests.map(req =>
            fetch('http://localhost:43414/AjaxWS.asmx/EjecutarEnBackend', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify(req)
            })
        ))
            .then(respuestas => Promise.all(respuestas.map(r => r.json())))
            .then(responses => {
            var respuestas = responses.map((res) => {
                if (res.hasOwnProperty('d')) {
                    return JSON.parse(res.d)
                } else {
                    return res
                }
            })
            cb(null, respuestas)
        }).catch(err => cb(err))
    }

    return {
        parallel: parallel
    }
})
