function HabilitarBuscarComite() {
    if ($('#id_comite').val() == "") {
        $('#id_perfil').prop("disabled", true);
        $('#btn_filtrar').prop("disabled", true);
    } else {
        $('#id_perfil').prop("disabled", false);
        $('#btn_filtrar').prop("disabled", false);
        BuscarPreinscriptos();
    }

};

function BuscarPreinscriptos() {
    var id_comite = $('#id_comite').val();

    Backend.BuscarPostulacionesDePreinscriptos(id_comite)
    .onSuccess(function (resultado) {
        //        buscar todos los titulares y seplentes del comité y listarlos - Continuar
        if (resultado.length == 0) {
            alertify.alert('No se encontraron resultados');
        } else {
            $('#comite_titular').text(resultado[0].Perfil.Comite.Integrantes[0].Apellido);
            DibujarTabla(resultado);
        }
    });
};

function DibujarTabla(postulaciones) {

    $("#tabla_postulaciones").empty();
    var divGrilla = $('#tabla_postulaciones');

    var columnas = [];
    columnas.push(new Columna("Nro Postulación", { generar: function (una_postulacion) { return una_postulacion.Numero } }));
    columnas.push(new Columna("Postulante", { generar: function (una_postulacion) { return una_postulacion.IdPersona } }));
    columnas.push(new Columna("Nro Perfil", { generar: function (una_postulacion) { return una_postulacion.Perfil.Numero } }));
    columnas.push(new Columna("Nivel", { generar: function (una_postulacion) { return una_postulacion.Perfil.Nivel } }));
    columnas.push(new Columna("Tipo", { generar: function (una_postulacion) { return una_postulacion.Perfil.Tipo } }));
    columnas.push(new Columna("Perfil", { generar: function (una_postulacion) { return una_postulacion.Perfil.Denominacion } }));
    // hay que agregarle un estado a la postulacion - Ver con Fer
    columnas.push(new Columna("Estado", { generar: function (una_postulacion) { return "Sin Dictamen" } }));


    columnas.push(new Columna('Cambiar', {
        generar: function (una_postulacion) {
            var btn_accion = $('<a>');
            var img = $('<img>');
                img.attr('src', '../Imagenes/cambiar.png');
                img.attr('width', '35px');
                img.attr('height', '35px');
            btn_accion.append(img);
            btn_accion.click(function () {
                CambiarEstadoPostulacion(una_postulacion);
            });

            return btn_accion;
        } 
    }));

    this.GrillaDePostulaciones = new Grilla(columnas);
    this.GrillaDePostulaciones.AgregarEstilo("cuerpo_tabla_perfil tr td");
    this.GrillaDePostulaciones.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
    this.GrillaDePostulaciones.SetOnRowClickEventHandler(function (un_perfil) {});


    this.GrillaDePostulaciones.CargarObjetos(postulaciones);
    this.GrillaDePostulaciones.DibujarEn(divGrilla);
};


function FiltarPorComite() { };

function CambiarEstadoPostulacion(una_postulacion) { 

};





