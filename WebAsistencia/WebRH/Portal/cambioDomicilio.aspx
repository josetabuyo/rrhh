<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cambioDomicilio.aspx.cs" Inherits="Portal_cambioDomicilio" %>
 <style type="text/css">
      
        
    </style>

<div>
<h1>Cambio Domicilio</h1>

<p>Domicilio para Cambiar</p>

<p>Calle  <span id="calle"></span></p>
<p>Numero  <span id="numero"></span></p>
<p>Piso <span id="piso"></span></p>
<p>Depto <span id="depto"></span> </p>
<p>Localidad <span id="localidad"></span></p>
<p>Provincia  <span id="provincia"></span></p>


<input type="button" id="btnConfirmarDomicilio" value="Confirmar" />
<input type="button" id="btnCancelarDomicilio" value="Cancelar" />
<input type="button" id="btnDelegarDomicilio" value="Delegar" />
</div>

<script type="text/javascript">
    var idAlerta = localStorage.getItem("idAlerta");
    
    $('#btnConfirmarDomicilio').click(function () {
        alert('a');
    });

    $('#btnCancelarDomicilio').click(function () {
        alert('a');
    });

    $('#btnDelegarDomicilio').click(function () {
        alert('a');
    });

    Backend.GetDomicilioPendientePorAlerta(idAlerta)
        .onSuccess(function (detalleTareaJSON) {

            var detalleTarea = $.parseJSON(detalleTareaJSON);
            //alert(detalleTareaJSON);
            $('#calle').html(detalleTarea.Calle);
            $('#numero').html(detalleTarea.Numero);
            $('#piso').html(detalleTarea.Piso);
            $('#depto').html(detalleTarea.Depto);
            $('#localidad').html(detalleTarea.Localidad);
            $('#provincia').html(detalleTarea.Provincia);

    });
   

</script>
