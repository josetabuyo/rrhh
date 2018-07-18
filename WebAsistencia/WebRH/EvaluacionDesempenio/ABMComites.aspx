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
                        Backend.AgregarComiteEvaluacionDesempenio().onSuccess(function (comite) {
                            comites.push(comite);
                            CargarGrillaComites();
                        });                        
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
