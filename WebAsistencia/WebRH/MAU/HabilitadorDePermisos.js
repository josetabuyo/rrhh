//FC: no deberia ir mas este, se usa HabilitadorDeControles
var HabilitadorDePermisos = {
    traerPermisos: function () {
        var idUsuarioSeleccionado = sessionStorage.getItem("idUsuario");
        if (!idUsuarioSeleccionado)
            idUsuarioSeleccionado = 0;
        var _this = this;

        Backend.GetFuncionalidadesPerfilesAreas(idUsuarioSeleccionado)
            .onSuccess(function (permisos) {
                if (permisos) {
                    localStorage.setItem('permisos', JSON.stringify(permisos));
                    //FC: traigo todos los elementos del html que tengan el atributo RequiereFuncionalidad
                   /* $('[RequiereFuncionalidad]').each(function (index, control) {

                        $(control).hide();

                        var funcionalidad = $(control).attr('RequiereFuncionalidad');
                        var area = $(control).attr('RequiereArea');
                        //FC: evaluo si los permisos que tiene el usaurio, coincide con la funcionalidad y el area q requiere
                        if (_this.tieneLaFuncionalidad(permisos, funcionalidad) && _this.tieneElArea(permisos, area)) {
                            $(control).show();
                        } else {
                            $(control).remove();
                        }

                    });*/

                    console.log(permisos);
                } else {
                    alertify.error('Error');
                }

            })
            .onError(function (e) {

            });
    },
    comprobarPermisosEnPantalla: function () {
        var _this = this;
        var permisos = JSON.parse(localStorage.getItem('permisos'));
        //FC: traigo todos los elementos del html que tengan el atributo RequiereFuncionalidad
        $('[RequiereFuncionalidad]').each(function (index, control) {

            $(control).hide();

            var funcionalidad = $(control).attr('RequiereFuncionalidad');
            var area = $(control).attr('RequiereArea');
            //FC: evaluo si los permisos que tiene el usaurio, coincide con la funcionalidad y el area q requiere
            if (_this.tieneLaFuncionalidad(permisos, funcionalidad) && _this.tieneElArea(permisos, area)) {
                $(control).show();
            } else {
                $(control).remove();
            }

        });

    },
    tieneLaFuncionalidad: function (permisos, funcionalidad) {

        for (i = 0; i < permisos.length; i++) {
            if (permisos[i].Nombre === funcionalidad) {
                return true;
            }
                
        }

        return false;

    },
    tieneElArea: function (permisos, idArea) {

        for (i = 0; i < permisos.length; i++) {
            for (j = 0; j < permisos[i].Areas.length; j++) {
                if (permisos[i].Areas[j].Id == parseInt(idArea))
                    return true;
            }   
        }

        return false;
    }
}
