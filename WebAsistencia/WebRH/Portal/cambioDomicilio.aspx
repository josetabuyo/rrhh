<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cambioDomicilio.aspx.cs" Inherits="Portal_cambioDomicilio" %>
 <style type="text/css">
      
        
    </style>

<div>
<h1>Cambio Domicilio</h1>

<p>Domicilio Solicitado para cambiar:  <span id="calle"></span> N°<span id="numero"></span>. Piso: <span id="piso"></span> Depto:<span id="depto"></span> Localidad: <span id="localidad"></span> <span id="provincia"></span>
<span id="manzana"></span> <span id="casa"></span> <span id="barrio"></span> <span id="torre"></span> <span id="uf"></span> 
</p>


<div style="margin-top: 170px; text-align:center;">
    <input type="button" class="btn btn-primary" id="btnConfirmarDomicilio" value="Confirmar" />
    <input type="button" class="btn btn-primary" id="btnCancelarDomicilio" value="Cancelar" />
    <input type="button" class="btn btn-primary" id="btnDelegarDomicilio" value="Delegar" />
</div>
</div>

<script type="text/javascript">
    var idAlerta = localStorage.getItem("idAlerta");
    var documento = localStorage.getItem("documento");

    $('#btnConfirmarDomicilio').click(function () {
        Backend.VerificarDomicilioPendiente(idAlerta, documento)
        .onSuccess(function (resultado) {
            alert(resultado);

        });
    });

    $('#btnCancelarDomicilio').click(function () {
        alert('a');
    });

    $('#btnDelegarDomicilio').click(function () {
        alert('a');
    });

    Backend.GetDomicilioPendientePorAlerta(idAlerta)
        .onSuccess(function (domicilioJSON) {

            var domicilio = $.parseJSON(domicilioJSON);
            //alert(detalleTareaJSON);
            $('#calle').html(domicilio.Calle);
            $('#numero').html(domicilio.Numero);
            $('#piso').html(domicilio.Piso);
            $('#depto').html(domicilio.Depto);
            $('#localidad').html(domicilio.Localidad);
            $('#provincia').html(domicilio.Provincia);

            $('#manzana').html(domicilio.Manzana);
            $('#casa').html(domicilio.Casa);
            $('#torre').html(domicilio.Torre);
            $('#barrio').html(domicilio.Barrio);
            $('#uf').html(domicilio.Uf);


    });
   

</script>
