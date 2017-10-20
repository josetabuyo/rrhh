var Instructivo = {
    init: function () {

    },
    abrirInstructivo: function () {
        var url = window.location.pathname;
        var partes = url.split(/[\s/]+/);

        Backend.GetInstructivo(partes[partes.length - 1])
                        .onSuccess(function (ubicacion) {

                            window.open(ubicacion, '_blank','left=20,top=20,width=500,height=500,toolbar=1,resizable=0','',false);
                            //alert(ubicacion);

                        })
                    .onError(function (e) {

                    });

    }

}