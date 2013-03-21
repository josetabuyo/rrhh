
var AdministradorDeDocumentos = function (cfg) {
    cfg.grillaDocumentos.DibujarEn(cfg.panelDocumentos);
    var listaAreas = JSON.parse(cfg.listaAreas.val());
    var selectorDeAreaOrigenEnAlta = new InputAutocompletableDeAreas(cfg.selectorDeAreaOrigenEnAlta, listaAreas, cfg.areaOrigenSeleccionadaEnAlta);
    var selectorDeAreaDestinoEnAlta = new InputAutocompletableDeAreas(cfg.selectorDeAreaDestinoEnAlta, listaAreas, cfg.areaDestinoSeleccionadaEnAlta);
    var selectorDeAreaDestinoEnDetalle = new InputAutocompletableDeAreas(cfg.selectorDeAreaDestinoEnDetalle, listaAreas, cfg.areaDestinoSeleccionadaEnDetalle);
    var selectorDeAreaActualEnfiltro = new InputAutocompletableDeAreas(cfg.selectorDeAreaActualEnfiltro, listaAreas, cfg.areaActualSeleccionadaEnFiltro);
    var selectorDeAreaOrigenEnfiltro = new InputAutocompletableDeAreas(cfg.selectorDeAreaOrigenEnfiltro, listaAreas, cfg.areaOrigenSeleccionadaEnFiltro);
    
    //despliegue panel alta
    cfg.botonDesplegarPanelAlta.click(function (e) {
        cfg.panelFiltros.slideUp("fast");
        cfg.botonDesplegarPanelFiltros.removeClass("boton_que_abre_panel_desplegable_activo");

        cfg.panelAlta.slideToggle("fast");
        cfg.botonDesplegarPanelAlta.toggleClass("boton_que_abre_panel_desplegable_activo");
        cfg.panelDetalle.cerrar();
    });

    //despliegue panel filtros
    cfg.botonDesplegarPanelFiltros.click(function (e) {
        cfg.panelAlta.slideUp("fast");
        cfg.botonDesplegarPanelAlta.removeClass("boton_que_abre_panel_desplegable_activo");

        cfg.panelFiltros.slideToggle("fast");
        cfg.botonDesplegarPanelFiltros.toggleClass("boton_que_abre_panel_desplegable_activo");
        cfg.panelDetalle.cerrar();
    });

    cfg.botonCerrarDetalle.mouseenter(function () {
        cfg.botonCerrarDetalle.attr('src', '../Imagenes/Botones/Botones Sicoi/cerrar_s2.png');
    });

    cfg.botonCerrarDetalle.mouseleave(function () {
        cfg.botonCerrarDetalle.attr('src', '../Imagenes/Botones/Botones Sicoi/cerrar_s1.png');
    });

    cfg.botonCerrarDetalle.click(function () {
        cfg.panelDetalle.cerrar();
    });


    cfg.idTipoDeDocumentoSeleccionadoEnAlta.val("");

    for (var i = 0; i < cfg.tiposDeDocumento.length; i++) {
        var tipo = cfg.tiposDeDocumento[i];
        var listItem = $('<option>');
        listItem.val(tipo.Id);
        listItem.text(tipo.descripcion);
        cfg.cmbTipoDeDocumento.append(listItem);
        cfg.cmbFiltroPorTipoDeDocumento.append(listItem.clone());
    }

    cfg.cmbTipoDeDocumento.change(function (e) {
        var idSeleccionado = cfg.cmbTipoDeDocumento.find('option:selected').val();
        cfg.idTipoDeDocumentoSeleccionadoEnAlta.val(idSeleccionado);

        var tipoSeleccionado;
        for (var i = 0; i < cfg.tiposDeDocumento.length; i++) {
            var tipo = cfg.tiposDeDocumento[i];
            if (tipo.Id == idSeleccionado) tipoSeleccionado = tipo;
        }
        if (tipoSeleccionado !== undefined) {
            cfg.lblLetrasDelTipoDeDocumento.text(tipoSeleccionado.sigla);
            cfg.txtNumero.parent().width(250 - cfg.lblLetrasDelTipoDeDocumento.width());
        }
        else {
            cfg.lblLetrasDelTipoDeDocumento.text('');
            cfg.txtNumero.parent().width('250px');
        }
    });

}

function crearHistorialDeTransiciones(documento) {
    var contenedor = $("#contenedor_historial_documento_detalle");
    contenedor.empty();
    for (var i = 0; i < documento.historial.length; i++) {
        var representacionTransicion = $('#proto_transicion_de_documento_historial').clone();
        representacionTransicion.attr('id', 'transicion' + i.toString());
        representacionTransicion.find('.fecha_transicion').text(documento.historial[i].fecha);
        representacionTransicion.find('.area_origen_transicion').text(documento.historial[i].areaOrigen);
        representacionTransicion.find('.area_destino_transicion').text(documento.historial[i].areaDestino);
        contenedor.append(representacionTransicion);
    }
}

function DeshabilitarControl(control) {
    if (control.prop('disabled') == false) {
        control.prop('disabled', true);
    }

}


function HabilitarControl(control) {
    if (control.prop('disabled') == true) {
        control.prop('disabled', false);
    }

}



function ValidadorComponenteVacio(ArrayDeTextBox) {

    for (x = 0; x < ArrayDeTextBox.length; x++) {

        if (ArrayDeTextBox[x].val() == "") {
            ArrayDeTextBox[x].css("background-color", '#ffffeb');
        }
        else {
            ArrayDeTextBox[x].css("background-color", '#ffffff');
        }
    }
}


function ValidadorDeAltaDeDocumento(ArrayDeControles) {
    var hayVacios = false;
    for (x = 0; x < ArrayDeControles.length; x++) {
        var atributo = ArrayDeControles[x].attr("type");
        var nombreTag = ArrayDeControles[x][0].tagName;

        if (ArrayDeControles[x].val() == "" && (atributo == "text" || nombreTag == "SELECT")) {


            //ArrayDeControles[x].css("background-color", '#ffffeb');
            ArrayDeControles[x].css("background-color", 'rgb(255, 255, 235)');

            for (y = 0; y < ArrayDeControles.length; y++) {
                if (ArrayDeControles[y].attr("type") == "submit") {

                    DeshabilitarControl(ArrayDeControles[y]);
                    hayVacios = true;
                }
            }
        }
        else {

            if (atributo == "text" || nombreTag == "SELECT") {
                ArrayDeControles[x].css("background-color", 'rgb(255, 255, 255)');
            }
        }
    }
    if (!hayVacios) {
        for (y = 0; y < ArrayDeControles.length; y++) {
            if (ArrayDeControles[y].attr("type") == "submit") {

                HabilitarControl(ArrayDeControles[y]);
                hayVacios = true;
            }
        }
    }
}


function ValidadorDeFiltrosDeDocumento(ArrayDeControles) {
    
    for (x = 0; x < ArrayDeControles.length; x++) {
        var atributo = ArrayDeControles[x].attr("type");
        var nombreTag = ArrayDeControles[x][0].tagName;

        if (atributo == "checkbox" && ArrayDeControles[x].attr("checked") == "checked") {

            $('#titulo_filtro_solo_docs_en_mi_area').css("background-color", 'rgb(255, 255, 150)');
       
            $('#boton_desplegar_panel_filtros').addClass("boton_que_abre_panel_desplegable_activo_con_filtros");

                     
        }

        if ((ArrayDeControles[x].val() == "" && (atributo == "text") || (nombreTag == "SELECT" && ArrayDeControles[x].val() == "-1"))) {
            $('#titulo_filtro_solo_docs_en_mi_area').css("background-color", 'rgb(255,255, 255)');
            ArrayDeControles[x].css("background-color", 'rgb(255, 255, 255)');


           // $('#boton_desplegar_panel_filtros').removeClass("boton_que_abre_panel_desplegable_activo_con_filtros");
           // $('#boton_desplegar_panel_filtros').addClass("boton_que_abre_panel_desplegable_activo");
         
        }
        else 
        {
        if (atributo == "text" || nombreTag == "SELECT") {
            ArrayDeControles[x].css("background-color", 'rgb(255, 255, 150)');


            $('#boton_desplegar_panel_filtros').addClass("boton_que_abre_panel_desplegable_activo_con_filtros");
  


            }
        }
    }
}





