<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComitesDeEvaluacion.aspx.cs" Inherits="EvaluacionDesempenio_ComitesDeEvaluacion" %>

<%@ Register Src="../BarraMenu/BarraMenu2.ascx" TagName="BarraMenu2" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../node_modules/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../node_modules/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../node_modules/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Scripts/jquery-ui-1.10.2.custom/css/smoothness/jquery-ui-1.10.2.custom.min.css" />
    <link rel="stylesheet" href="../node_modules/jquery-timepicker/jquery.timepicker.css" />
    <link rel="stylesheet" href="../scripts/select2-3.4.4/select2.css" />

    <script data-main="ComitesDeEvaluacion" src="../node_modules/requirejs/require.js"></script>
    <title>Sigirh -Comités de Evaluacion</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:BarraMenu2 ID="BarraMenu21" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
            UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
        <div class="container tab-content">
            <div class="row">
                <div class="col">&nbsp;</div>
            </div>
            <div role="tabpanel" id="scr_home">
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
                        <table id="tabla_periodos" class="table table-bordered table-striped table-sm">
                            <thead>
                                <tr>
                                    <!--<th scope="col" rowspan="2" class="align-middle">#</th>-->
                                    <th rowspan="2" class="align-middle w-25">Periodo</th>
                                    <th rowspan="2" class="align-middle">Evaluaciones Pendientes</th>
                                    <th rowspan="2" class="align-middle">Evaluaciones Provisorias</th>
                                    <th colspan="3" class="align-middle w-50">Evaluaciones Realizadas</th>
                                    <th rowspan="2" class="align-middle">Reuniones Realizadas</th>
                                    <th rowspan="2" class="align-middle">Crear Nueva Reunion</th>
                                </tr>
                                <tr>
                                    <th scope="col">Sin GDE</th>
                                    <th scope="col">Sin Comité</th>
                                    <th scope="col">Finalizado</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="row-template" style="display: none">
                                    <td>{{Periodo}}</td>
                                    <td class="text-right">{{EvaluacionesPendientes}}</td>
                                    <td class="text-right">{{EvaluacionesProvisorias}}</td>
                                    <td class="text-right">{{SinGDE}}</td>
                                    <td class="text-right">{{SinComite}}</td>
                                    <td class="text-right">{{Finalizado}}</td>
                                    <td class="text-right">{{ReunionesRealizadas}}<a style="display: inline" data-toggle="tooltip" data-placement="top" title="Ver Reuniones" class="nav-link" href="#"><span class="fa fa fa-eye"></span></a></td>
                                    <td class="text-right">
                                        <button type="button" class="btn btn-sm btn-primary" btn_id_periodo="{{IdPeriodo}}" on_next="#scr_datos_generales">Crear Nueva Reunion</button></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div role="tabpanel" id="scr_datos_generales" style="display: none">
                <div class="row">
                    <div class="col col-md-5">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item" on_leave="#scr_home"><a href="#">Comités de Evaluacion</a></li>
                                <li class="breadcrumb-item active" aria-current="page">Paso 1: Datos Generales</li>
                            </ol>
                        </nav>
                    </div>
                    <div class="col"></div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Nueva Reunión</h5>
                                <h6 class="card-subtitle mb-2 text-muted">Paso 1: Datos Generales</h6>
                                <p class="lead" id="desc_periodo" />
                                <div class="card-text">
                                    <div class="form-group row">
                                        <label for="telnum" class="col-12 col-md-2 col-form-label">Fecha</label>
                                        <div class="col-5 col-md-3">
                                            <input type="tel" class="form-control" id="fecha" name="Fecha" placeholder="Fecha">
                                        </div>
                                        <div class="col-7 col-md-7">
                                            <input type="tel" class="form-control timepicker" id="hora" name="telnum" placeholder="hora">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="emailid" class="col-md-2 col-form-label">Lugar</label>
                                        <div class="col-md-10">
                                            <input type="email" class="form-control" id="lugar" name="lugar" placeholder="Lugar">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="emailid" class="col-md-2 col-form-label">Descripcion</label>
                                        <div class="col-md-10">
                                            <input type="email" class="form-control" id="descripcion" name="descripcion" placeholder="Descripcion">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            <hr />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-12 text-right">
                                            <a href="#" class="btn btn-secondary" role="button" on_leave="#scr_home">Atras</a>
                                            <a href="#" class="btn btn-primary active" role="button" on_next="#scr_integrantes">Siguiente</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div role="tabpanel" id="scr_integrantes" style="display: none">
                <div class="row">
                    <div class="col col-12 col-md-6">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item" on_leave="#scr_home"><a href="#">Comités de Evaluacion</a></li>
                                <li class="breadcrumb-item" on_leave="#scr_datos_generales"><a href="#">Paso 1: Datos Generales</a></li>
                                <li class="breadcrumb-item  active">Paso 2: Integrantes</li>
                            </ol>
                        </nav>
                    </div>
                    <div class="col"></div>
                </div>
                <div class="row">
                    <div class="col col-12">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Nueva Reunión</h5>
                                <h6 class="card-subtitle mb-2 text-muted">Paso 2: Integrantes</h6>
                                <p class="lead" id="desc_periodo_int" />
                                <div class="card-text">
                                    <div class="row">

                                        <div class="col-12 col-md-12">
                                            <table id="tabla_integrantes" class="table table-bordered table-striped table-sm">
                                                <thead>
                                                    <tr>
                                                        <th scope="col">Integrante</th>
                                                        <th scope="col">En Caracter De</th>
                                                        <th scope="col">Acciones</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr class="row-template" style="display: none">
                                                        <td>{{Apellido}}, {{Nombre}}</td>
                                                        <td>{{EnCaracterDe}}</td>
                                                        <td>
                                                            <a style="display: inline" data-toggle="tooltip" data-placement="top" title="Eliminar Integrante" class="delete-integrante" href="#" integrante="{{IdPersona}}"><span class="fa fa fa-trash"></span></a>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            <hr />
                                        </div>
                                    </div>
                                    <div>
                                        <div class="card bg-light mb-3 col-12">
                                            <div class="card-body">
                                                <h5 class="card-title">Agregar Integrante</h5>
                                                <div class="form-group row">
                                                    <label for="buscador" class="col-12 col-md-2 offset-md-2 col-form-label">Integrante</label>
                                                    <div id="cmb_selector_integrantes" class="col-12 col-md-6">
                                                        <input id="buscador" type="hidden" class="buscarPersona" />
                                                        <input type="hidden" id="persona_buscada" />
                                                    </div>
                                                    <div class="col col-md-2"></div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="caracter" class="col-12 col-md-2 offset-md-2 col-form-label">En Caracter De</label>
                                                    <div class="col-12 col-md-6">
                                                        <select class="form-control" id="cmb_en_caracter_de">
                                                            <option>--Seleccione--</option>
                                                            <option value="1">Representante Gremial UPCN</option>
                                                            <option value="2">Representante Gremial ATE</option>
                                                            <option value="3">Coordinador del proceso de Selección</option>
                                                            <option value="4">Evaluador</option>
                                                        </select>
                                                    </div>
                                                    <div class="col col-md-2"></div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-12 col-md-8 offset-md-2 text-right">
                                                        <button id="btn_agregar_integrante" type="button" class="btn btn-sm btn-primary">Agregar >></button>
                                                    </div>
                                                    <div class="col col-md-2"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            <hr />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col col-md-12 text-right">
                                            <a href="#" class="btn btn-secondary" role="button" on_leave="#scr_datos_generales">Atras</a>
                                            <a href="#" class="btn btn-primary active" role="button" on_next="#scr_unidades">Siguiente</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div role="tabpanel" id="scr_unidades" style="display: none">
                <div class="row">
                    <div class="col col-9">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item" on_leave="#scr_home"><a href="#">Comités de Evaluacion</a></li>
                                <li class="breadcrumb-item" on_leave="#scr_datos_generales"><a href="#">Paso 1: Datos Generales</a></li>
                                <li class="breadcrumb-item" on_leave="#scr_integrantes"><a href="#">Paso 2: Integrantes</a></li>
                                <li class="breadcrumb-item  active">Paso 3: Unidades de Evaluacion</li>
                            </ol>
                        </nav>
                    </div>
                    <div class="col"></div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Nueva Reunión</h5>
                                <h6 class="card-subtitle mb-2 text-muted">Paso 3: Unidades de Evaluación</h6>
                                <p class="lead" id="desc_periodo_ues" />
                                <div class="card-text">
                                    <table class="table table-bordered table-striped table-sm" id="tabla_unidades">
                                        <thead>
                                            <tr>
                                                <th>Codigo</th>
                                                <th class="w-100">Unidad de Evaluación</th>
                                                <th class="text-center">DESTA CADOS</th>
                                                <th class="text-center">BUENO</th>
                                                <th class="text-center">REGU LAR</th>
                                                <th class="text-center">DEFI CIENTE</th>
                                                <th class="text-center">Total Evaluados</th>
                                                <th class="text-center">PROVI SORIA</th>
                                                <th class="text-center">PENDIEN TE</th>
                                                <th class="text-center">Total General</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="row-template" style="display: none">
                                                <td>{{Codigo}}</td>
                                                <td>{{NombreArea}}</td>
                                                <td class="text-right">{{Destacados}}</td>
                                                <td class="text-right">{{Bueno}}</td>
                                                <td class="text-right">{{Regular}}</td>
                                                <td class="text-right">{{Deficiente}}</td>
                                                <td class="text-right">{{TotalEvaluados}}</td>
                                                <td class="text-right">{{Provisoria}}</td>
                                                <td class="text-right">{{Pendiente}}</td>
                                                <td class="text-right">{{TotalGeneral}}</td>
                                                <td class="text-right">
                                                    <input type="checkbox" {{Selected}} model_id="{{Id}}" />
                                                </td>
                                            </tr>
                                            <tr class="table-info">
                                                <td colspan="3" class="text-right">Total para UE Seleccionadas</td>
                                                <td class="text-right">2</td>
                                                <td class="text-right">9</td>
                                                <td class="text-right">16</td>
                                                <td class="text-right">1</td>
                                                <td class="text-right">28</td>
                                                <td class="text-right">0</td>
                                                <td class="text-right">0</td>
                                                <td class="text-right">28</td>
                                                <td></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col col-md-12 text-right">
                        <a href="#" class="btn btn-secondary" role="button" on_leave="#scr_integrantes">Atras</a>
                        <a href="#" class="btn btn-primary active" role="button" on_next="#scr_evaluaciones">Siguiente</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <input type="hidden" id="id_periodo_seleccionado" />
    <div id="plantillas" style="display: none">
        <div class="vista_persona_en_selector">
            <span id="contenedor_legajo" class="badge badge-pill badge-success">
                <span id="titulo_legajo">Leg:
                </span>
                <span id="legajo"></span>
            </span>
            <span id="nombre"></span>
            <span id="apellido"></span>
            <span id="contenedor_doc" class="badge badge-pill badge-info">
                <span id="titulo_doc">Doc:</span>
                <span id="documento"></span>
            </span>
        </div>
    </div>
    <!--<script src="../node_modules/jquery/jquery.min.js"></script>
    <script src="../node_modules/popper.js/dist/umd/popper.min.js"></script>
    <script src="../node_modules/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="ComitesDeEvaluacion.js"></script>-->
</body>
</html>
