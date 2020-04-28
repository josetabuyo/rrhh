<%@ Page Language="C#" AutoEventWireup="true" CodeFile="csv.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="es" style="height: 100%;"><head><meta http-equiv="Content-Type" content="text/html; charset=utf8">
<!--<link rel="shortcut icon" type="image/x-icon" href="https://......./imagenes/favicon.ico">-->

<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Verificador</title>
<!-- Bootstrap -->
<link rel="stylesheet" href="/Scripts/bootstrap/css/bootstrappersonalizado.min.css" type="text/css"/>
<link rel="stylesheet" href="/Scripts/bootstrap/css/personalizado.bootstrap3.css" type="text/css"/>


<!-- HTML5 Shim and Respond.js IE8 support ofHTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
				<script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
				<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
			<![endif]-->
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<!--<script type="text/javascript" async="" src="/Scripts/bootstrap/js/recaptcha__es.js.descarga"></script> -->
 <script type="text/javascript" src="/Scripts/Backend.js"></script>

 <%= Referencias.Css("../")%>
 <%= Referencias.Javascript("../")%>

<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->


<script type="text/javascript" src="/Scripts/jsPortal/verificadorCSV.js"></script>


</head>
	<body>

		<div class="back-colorNOUSADOESLALETRADELRESULTADO" style="background-image: url('../Imagenes/fondo_verificadorpng.png'); height:60%;width:100%;background-repeat:no-repeat;background-size: cover;">
        <div id="contenedor_imagen" style="width:100%" >
            <img src="../Imagenes/logo_sistema.png" id="img_logo_sistema" alt="logosistema" style="width:10%;margin-top:30px; margin-left:2%;cursor:pointer" onclick="window.location.href='../Login.aspx'">
            <!--<img src="../Imagenes/logo_direccion.png" id="img_logo_direccion" alt="logosistema" style="width:13%;margin-top:40px;float:right;margin-right: 2%">
            <img src="../Imagenes/logo_ministerio.png" id="img_logo_minis" alt="logosistema" style="width:14%;margin-top:40px;float:right;margin-right: 2%;">-->            
            <img src="../Imagenes/003logo_rrhh.gif" id="img2" alt="logosistema" style="width:10%;margin-top:55px;float:right;margin-right: 2%;">  
            <img src="../Imagenes/002logo_ministerio.gif" id="img1" alt="logosistema" style="width:17%;margin-top:40px;float:right;margin-right: 2%">         
            
                   
        </div><br />

		<div class="container h-100">
			<div class="row h-100">
				<div class="col-sm-12 my-auto card-container">
					<div class=" col-lg-5 col-md-7 col-sm-9 mx-auto h-100" style ="margin-top:10%;max-width: 41.666667%;">
						<div class="card card-block  altura-div fondo-color" >
							<div class="card-header fondo-color" style="height: 38%; border-bottom: 0px solid rgba(0,0,0,.125);">
								<div class="text-center" style="height: 90%">
                                   
									<img alt="" class="img-fluid fondo-color" style="border: 0px solid #006b74 ;/*background-color: rgba(0, 108, 116, 0.74);*/height: 90%; width:auto; 
									    transform: translateY(40%);" src="/Imagenes/logo_sistema.png"> 
                                  
								</div>
							</div>
							<div class="card-body fondo-color" style=" margin-left:5%; margin-right:5%;/*background-color: #006b74*/">
								


<script type="text/javascript">

    //limpiar los mensajes de error
    // deshabilitar el boton verificar disable(this);
    //luego de hacer click en el captcha, se debe poder habilitar el boton verificar*-*********************
    //var $alertFiltro = null;

    $(document).ready(function () {

       /* $alertFiltro = $("#alertFiltro");
        $divPrincipal = $("#divPrincipal");
        if ($alertFiltro.html() != '') {
            CConicetUtils.showElement($alertFiltro);
            $divPrincipal.removeClass("pt-4");
            $divPrincipal.removeClass("mt-3");
        }*/

        /*En caso de venir desde una lectura por QR ya se dispone del csv*/
        var valor = CSV.obtenerValorParametro('c');
        if (valor){
            document.getElementById('codigoVerificador').value = valor;
        }else{
             //alert('El parámetro no existe en la URL');
         }

    });
</script>


<div id="divPrincipal" style="display: inline;">
	<div class="form-group pt-4 mt-3" >
		<div class="alert alert-warning" style="display: none;width:86%;margin-left:24px" role="alert" id="alertFiltro"></div>		
		<input type="text" class="form-control" style="width:86%;height:100%;margin-left:7%"value="" name="codigoVerificador" id="codigoVerificador" placeholder="Ingrese el código">
		
	</div>
	<script src='https://www.google.com/recaptcha/api.js?hl=es'></script>
    <div class="g-recaptcha" data-sitekey="6LeawLgUAAAAAIuhAIq5kdwe1bvHFpyST5ih5ghM" data-callback="habilitarBtnVerificador" style= "display: flex;justify-content: center"></div>
    <div id="g-recaptcha-error"></div>

	<div class="row" style="padding-top: 40px;">
    <input type="submit" onclick="javascript:verifyCaptcha();return false;"  style="margin:0 auto;font-weight: bold;color:Gray" value="Verificar" class="btn boton" id="btnVerificar" disabled>
		<div class="col-lg-12 text-right" >
			<!--<input type="submit" onclick="javascript:submitUserForm();return false;"  value="Verificar" class="btn boton">-->
		</div>
	</div>

    </div>


<div id="divReciboOK" style="display: none;color:white">
	<div class="form-group pt-4 mt-3" >
		<div class="form-group row" style="margin-right: 0px;margin-left: 0px;">
		<label for="recibo.cuil" class="col-sm-5 col-form-label"> <b>CUIL&nbsp;</b>
		</label>
		<div class="col-sm-7">
			<div class="form-control-plaintext" id="divCuil"></div>
		</div>
	</div>
	<div class="form-group row" style="margin-right: 0px;margin-left: 0px;">
		<label for="recibo.periodo" class="col-sm-5 col-form-label"> <b>Periodo&nbsp;</b>
		</label>
		<div class="col-sm-7">
			<div class="form-control-plaintext" id="divPeriodo"></div>
		</div>
	</div>
	<div class="form-group row" style="margin-right: 0px;margin-left: 0px;">
		<label for="recibo.importe" class="col-sm-5 col-form-label"> <b>Importe Neto&nbsp;</b>
		</label>
		<div class="col-sm-7">
			<div class="form-control-plaintext" id="divNeto"></div>
		</div>
	</div>
	<div class="row" style="padding-top: 10px;">
		<div class="col-lg-12 text-right">
            <input type="submit" onclick="javascript:ocultarPanelRecibo();return false;"  value="Volver" class="btn boton">
		</div>
	</div>
	</div>  
</div>



							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		</div>
	
</body>

<!-- controladores de verificacion de csv -->
<script type="text/javascript">

    var divCuil = document.getElementById('divCuil');
    var divPeriodo = document.getElementById('divPeriodo');
    var divNeto = document.getElementById('divNeto');
    var botonVerificar = document.getElementById('btnVerificar'); 

    function habilitarBtnVerificador() {
        botonVerificar.disabled = false;
        botonVerificar.style.color = 'black';
    }

    /*function submitUserForm() {
        var response = grecaptcha.getResponse();
        if (response.length == 0) {
            document.getElementById('g-recaptcha-error').innerHTML = '<span style="color:red;">El captcha es invalido.Intente nuevamente.</span>';
            return false;
        }
        return true;
    }*/

    function verifyCaptcha() {
        document.getElementById('g-recaptcha-error').innerHTML = '';        
        verificarCSV();
    }

    function verificarCSV() {

        var codigo = document.getElementById('codigoVerificador').value;
        if (codigo != '') {
            CSV.verificarCSV(codigo);
        } else {
            document.getElementById('g-recaptcha-error').innerHTML = '<span style="color:red;margin-right: 0px;margin-left: 24px;">Debe escribir un CSV.</span>';
        }
        //probando un csv hack
        //CSV.verificarCSV("MDS1-1234-1234-1234-1234-1234");

    }

    function mostrarPanelRecibo() {
        //oculto el panel principal
        document.getElementById('divPrincipal').style.display = 'none';
        //muestro el panel con datos del recibo
        document.getElementById('divReciboOK').style.display = 'block';

    }

    function ocultarPanelRecibo() {
        //oculto el panel principal
        document.getElementById('divPrincipal').style.display = 'block';
        //muestro el panel con datos del recibo
        document.getElementById('divReciboOK').style.display = 'none';
        //limpio los datos
        document.getElementById('codigoVerificador').value = '';
        divCuil.innerHTML = '&nbsp;';
        divPeriodo.innerHTML = '&nbsp;';
        divNeto.innerHTML = '&nbsp;';
        ocultarAlert();        

    }

    function mostrarAlert() {
        //muestro el panel 
        document.getElementById('alertFiltro').style.display = 'block';

    }
    function ocultarAlert() {
        //oculto el panel 
        document.getElementById('alertFiltro').style.display = 'none';
        document.getElementById("alertFiltro").innerHTML = "";
    }


</script>

</html>