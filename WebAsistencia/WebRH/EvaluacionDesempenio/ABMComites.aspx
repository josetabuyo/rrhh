<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMComites.aspx.cs" Inherits="EvaluacionDesempenio_ABMComites" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reuniones de Comite</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 17px;">
        </h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align: center;" class="caja_izq">
            </div>
            <div class="caja_der papel">
                <legend style="margin-top: 20px;">Comités</legend>
                <input id="btn_add_comite" type=button value="+"/>
                <div id="tabla_comites">
                </div>
            </div>
        </div>
    </div>   
    <div id="plantillas">
        <div class="botonera_grilla">
            <img id="btn_editar" src="../Imagenes/edit2.png" height="25px" />
            <input type="hidden" id="hidden_model" />
        </div>
        <div class="botonera_grilla_ues">
            <!--<img id="btn_eliminar_ue" src="../Imagenes/icono_eliminar2.png" height="25px"  />-->
            <input type="checkbox" id="chk_selected" />
            <input type="hidden" id="hidden1" />
        </div>
        <div class="alta_comite">
                <h4>
                    Datos de la Reunión</h4>
                <div>
                    <label for="fecha_1">
                        Fecha <em>*</em>
                    </label>
                    <input id="fecha_1" campo="fecha_1" type="text" placeholder="dd/mm/aaaa" style="flex-grow: 100;" />
                </div>
                <div class="grupo_campos nueva_linea">
                    <label for="hora">
                        Hora <em>*</em></label>
                    <input id="txt_hora" type="text" style="width: 160px;" maxlength="100" />
                </div>
                <div class="grupo_campos nueva_linea">
                    <label for="lugar">
                        Lugar <em>*</em></label>
                    <input id="txt_lugar" type="text" style="width: 160px;" maxlength="100" />
                </div>
            <input id="btn_aceptar_alta" value="OK" type="button"/>
        </div>
    </div>
    </form>
    <script type="text/javascript" src="../Scripts/Spin.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
        var comites = [];
        var grilla;
        $(document).ready(function () {
            Backend.start(function () {
                var spinner = new Spinner({ scale: 2 });
                spinner.spin($("html")[0]);

                Backend.GetEstadosEvaluaciones().onSuccess(function (ues) {
                    localStorage.setItem("estadosEvaluaciones", JSON.stringify(ues));
                });

                Backend.GetAllComites().onSuccess(function (comites_devueltos) {
                    comites = comites_devueltos;
                    CargarGrillaComites();
                    spinner.stop();
                    $("#btn_add_comite").click(function () {
                        vex.defaultOptions.className = 'vex-theme-os';
                        vex.open({
                            afterOpen: function ($vexContent) {
                                var ui = $("#plantillas .alta_comite").clone();
                                ui.find('#fecha_1').datepicker({
                                    dateFormat: "dd/mm/yy",
                                    onSelect: function (date) {
                                    }
                                });

                                ui.find('#fecha_1').datepicker("setDate", new Date());

                                ui.find("#btn_aceptar_alta").click(function () {
                                    var fecha = ui.find('#fecha_1').val();
                                    var hora = ui.find('#txt_hora').val();
                                    var lugar = ui.find('#txt_lugar').val();
                                    Backend.AgregarComiteEvaluacionDesempenio(fecha, hora, lugar).onSuccess(function (comite) {
                                        comites.push(comite);
                                        CargarGrillaComites();
                                        vex.close();
                                    });
                                });
                                $vexContent.append(ui);
                                ui.show();
                                return ui;
                            }
                        })
                    });
                }
            ).onError(function (e) {
                spinner.stop();
            });
            });
        });

    var CargarGrillaComites = function () {
        $("#tabla_comites").empty();
        var divGrilla = $("#tabla_comites");
        var columnas = [];

        columnas.push(new Columna("Periodo", { generar: function (model) { return model.Periodo.descripcion_periodo; } }));
        columnas.push(new Columna("Fecha", { generar: function (model) { return model.Fecha.substring(0, 10); } }));
        columnas.push(new Columna("Unidades de Evaluacion", { generar: function (model) {
            var ues = model.UnidadesEvaluacion;
            if (ues.length == 0) {
                return "No especificado";
            }
            if (ues.length == 1) {
                return ues[0].NombreArea;
            }
            return ues[0].NombreArea & " y " & (ues.length - 1).toString() & " ue mas";
        }
        }));

        columnas.push(new Columna('Acciones', {
            generar: function (model) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                //var hidden_model = contenedorBtnAcciones.find("#hidden_model");
                //hidden_model.attr('value', JSON.stringify(model));

                btn_editar.click(function () {
                    localStorage.setItem("detalleComite", JSON.stringify(model));
                    window.location.replace('PantallaDetalleComite.aspx');
                });

                return contenedorBtnAcciones;
            }
        }));

        grilla = new Grilla(columnas);
        grilla.SetOnRowClickEventHandler(function (model) { });
        grilla.CambiarEstiloCabecera("estilo_tabla_portal");
        grilla.CargarObjetos(comites);
        grilla.DibujarEn(divGrilla);
        $('.table-hover').removeClass("table-hover");
    };
    </script>
</body>
</html>
