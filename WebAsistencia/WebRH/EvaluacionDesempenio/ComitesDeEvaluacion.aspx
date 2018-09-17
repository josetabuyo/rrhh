<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComitesDeEvaluacion.aspx.cs" Inherits="EvaluacionDesempenio_ComitesDeEvaluacion" %>

<%@ Register Src="../BarraMenu/BarraMenu2.ascx" TagName="BarraMenu2" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../node_modules/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../node_modules/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../node_modules/bootstrap/dist/css/bootstrap.min.css">
        
    <title>Sigirh -Comités de Evaluacion</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <uc1:BarraMenu2 ID="BarraMenu21" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
            UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
        <div class="container">
            <div class="row">
                <div class="col col-md-3">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item active" aria-current="page">Comités de Evaluacion</li>
                        </ol>
                    </nav>
                </div>
                <div class="col"></div>
            </div>
            <div class="row">
                <div class="col col-md-12">
                    <table class="table  table-bordered table-striped table-sm">
                      <thead>
                          <tr>
                            <th scope="col" rowspan="2" class="align-middle">#</th>
                            <th scope="col" rowspan="2" class="align-middle  w-25">Periodo</th>
                            <th scope="col" rowspan="2" class="align-middle">Evaluaciones Pendientes</th>
                            <th scope="col" rowspan="2" class="align-middle">Evaluaciones Provisorias</th>
                            <th scope="col" colspan="3" class="align-middle w-50">Evaluaciones Realizadas</th>
                            <th scope="col" rowspan="2" class="align-middle">Reuniones Realizadas</th>
                            <th scope="col" rowspan="2" class="align-middle">Crear Nueva Reunion</th>
                          </tr>
                        <tr>
                            <th scope="col">Sin GDE</th>
                            <th scope="col">Sin Comité</th>
                            <th scope="col">Finalizado</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <th scope="row">1</th>
                          <td>2016 - Planta Permanente</td>
                          <td class="text-right">30</td>
                          <td class="text-right">19</td>
                          <td class="text-right">125</td>
                          <td class="text-right">37</td>
                          <td class="text-right">32</td>
                          <td class="text-right">6<a style="display:inline" data-toggle="tooltip" data-placement="top" title="Ver Reuniones" class="nav-link" href="#"><span class="fa fa fa-eye"></span></a></td>
                          <td class="text-right"><button type="button" class="btn btn-sm btn-primary">Crear Nueva Reunion</button></td>
                        </tr>
                        <tr>
                          <th scope="row">2</th>
                          <td>2017 - P. P. Ingresantes</td>
                          <td class="text-right">50</td>
                          <td class="text-right">26</td>
                          <td class="text-right">17</td>
                          <td class="text-right">7</td>
                          <td class="text-right">9</td>
                          <td class="text-right">19<a style="display:inline" data-toggle="tooltip" data-placement="top" title="Ver Reuniones" class="nav-link" href="#"><span class="fa fa fa-eye"></span></a></td>
                          <td class="text-right"><button type="button" class="btn btn-sm btn-primary">Crear Nueva Reunion</button></td>
                        </tr>
                      </tbody>
                    </table>                 
                </div>
            </div>
        </div>
    </form>
    <script src="../node_modules/jquery/jquery.min.js"></script>
    <script src="../node_modules/popper.js/dist/umd/popper.min.js"></script>
    <script src="../node_modules/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="ComitesDeEvaluacion.js"></script>
</body>
</html>
