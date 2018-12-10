var cargoIdSeleccionado;
var cargoDescripSeleccionado;
var ContenedorGrilla;
var lista_de_serv_publico;


Backend.start(function () {
    $(document).ready(function () {

        //var valores = getParametrosURL();
        //pLegajo = valores['legajo'];
        //pDocumento = valores['documento'];
        //pFolio = valores['folio'];
        
        completarComboCargo();
        GetUsuario();

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorServicios").empty();

        //ConsultarServicioAdmPublica();
    });
});

var GetUsuario = function () {
    Backend.GetUsuarioLogueado()
    .onSuccess(function (respuesta) {
        pUsuarioLogueado = respuesta.Id;
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
    });
}

var PanelFechas = function (cfg) {
    var self = this;
    this.cfg = cfg;

    cfg.inputFechaDesde.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaDesde.change();
            self.cfg.inputFechaDesde.blur();
            FechaDesde = date;
        }
    });

    cfg.inputFechaHasta.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaHasta.change();
            self.cfg.inputFechaHasta.blur();
            FechaHasta = date;
        }
    });
}



var completarComboCargo = function () {
    var cargo = $('#cmbCargo');
    cargo.html("");
    Backend.GetCargos()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            //item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
            item = new Option(respuesta[i].descripcion, respuesta[i].id);
            $(item).html(respuesta[i].descripcion);
            cargo.append(item);
        }
        cargo.change(function () {
            cargoIdSeleccionado = parseInt($("#cmbCargo").val().split("-")[0]);
            cargoDescripSeleccionado = parseInt($("#cmbCargo").val().split("-")[1]);

            //alert(cargoIdSeleccionado);
            //alert(cargoDescripSeleccionado);

        });

        cargo.change();
        cargo.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
}

