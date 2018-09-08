$(document).ready(function () {
    var proveedor_ajax = new ProveedorAjax();
    $('[RequiereFuncionalidad]').each(function (index, control) {

        $(control).hide();

        var funcionalidad = $(control).attr('RequiereFuncionalidad')

        proveedor_ajax.postearAUrl({ url: "ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre",

            data: {
                nombre_funcionalidad: funcionalidad
            },
            success: function (tiene_funcionalidad) {
                if (!tiene_funcionalidad) $(control).remove();
                else {
                    $(control).show();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });
    });
});
