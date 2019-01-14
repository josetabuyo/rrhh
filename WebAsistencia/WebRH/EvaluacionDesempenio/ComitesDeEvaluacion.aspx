<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComitesDeEvaluacion.aspx.cs" Inherits="EvaluacionDesempenio_ComitesDeEvaluacion" %>

<%@ Register Src="../BarraMenu/BarraMenu2.ascx" TagName="BarraMenu2" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../node_modules/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../node_modules/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Scripts/jquery-ui-1.10.2.custom/css/smoothness/jquery-ui-1.10.2.custom.min.css" />
    <link rel="stylesheet" href="../node_modules/jquery-timepicker/jquery.timepicker.css" />
    <link rel="stylesheet" href="../scripts/select2-3.4.4/select2.css" />

    <style>
        .bd-example-modal-lg .modal-dialog {
            display: table;
            position: relative;
            margin: 0 auto;
            top: calc(50% - 24px);
        }

        .bd-example-modal-lg .modal-dialog .modal-content {
            background-color: transparent;
            border: none;
        }
    </style>

    <script data-main="ComitesDeEvaluacion" src="../node_modules/requirejs/require.js"></script>
    <title>Sigirh -Comités de Evaluacion</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:BarraMenu2 ID="BarraMenu21" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
            UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    </form>
    <div class="container tab-content">
        <div class="row">
            <div class="col">&nbsp;</div>
        </div>
        <div role="tabpanel" id="scr_periodos">
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
                                <td class="text-right">{{ReunionesRealizadas}}<a style="display: inline" data-toggle="tooltip" data-placement="top" on_next="#scr_reuniones_comites/{{IdPeriodo}}" title="Ver Reuniones" class="nav-link text-info" href="#"><span class="fa fa fa-eye"></span></a></td>
                                <td class="text-center">
                                    <a style="display: inline" data-toggle="tooltip" data-placement="top" on_next="#scr_datos_generales/{{IdPeriodo}}" title="Crear Nueva Reunion" class="nav-link" href="#"><span class="fa fa fa-plus-circle"></span></a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div role="tabpanel" id="scr_reuniones_comites" style="display: none">
            <div class="row">
                <div class="col col-md-7">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item" on_leave="#scr_periodos"><a href="#">Comités de Evaluacion</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Reuniones Realizadas - <span id="desc_periodo"></span></li>
                        </ol>
                    </nav>
                </div>
                <div class="col"></div>
            </div>
            <div class="row">
                <div class="col col-md-12">
                    <table id="tabla_reuniones" class="table table-bordered table-striped table-sm">
                        <thead>
                            <tr>
                                <!--<th scope="col" rowspan="2" class="align-middle">#</th>-->
                                <th class="align-middle w-25">Periodo</th>
                                <th class="align-middle">Fecha</th>
                                <th class="align-middle">Lugar</th>
                                <th class="align-middle">Integrantes</th>
                                <th class="align-middle">Ver Detalle</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="row-template" style="display: none">
                                <td>{{Periodo}}</td>
                                <td class="text-right">{{Fecha}}</td>
                                <td class="text">{{Lugar}}</td>
                                <td class="text">{{Integrantes}}</td>
                                <td class="text">
                                    <a style="display: inline" data-toggle="tooltip" data-placement="top" title="Ver Detalle" class="detalle" href="#" on_next="#scr_evaluaciones/{{IdComite}}"><span class="fa fa fa-eye"></span></a>
                                </td>
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
                            <li class="breadcrumb-item" on_leave="#scr_periodos"><a href="#">Comités de Evaluacion</a></li>
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
                                <form id="frm_datos_generales" method="get" on_next="#scr_integrantes">
                                    <div class="form-group row">
                                        <label for="date" class="col-12 col-md-2 col-form-label">Fecha</label>
                                        <div class="col-5 col-md-3">
                                            <input type="text" class="form-control" id="fecha" name="fecha" placeholder="fecha" required>
                                        </div>
                                        <div class="col-7 col-md-7">
                                            <input type="hora" class="form-control timepicker" id="hora" name="hora" placeholder="hora" minlength="5" maxlength="5">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="lugar" class="col-md-2 col-form-label">Lugar</label>
                                        <div class="col-md-10">
                                            <input type="text" class="form-control" id="lugar" name="lugar" placeholder="Lugar" required minlength="3">
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="descripcion" class="col-md-2 col-form-label">Descripcion</label>
                                        <div class="col-md-10">
                                            <input type="text" class="form-control" id="descripcion" name="descripcion" placeholder="Descripcion" required minlength="3">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            <hr />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-12 text-right">
                                            <a href="#" class="btn btn-secondary" role="button" on_leave="#scr_periodos">Atras</a>
                                            <input type="submit" class="btn btn-primary active" role="button" value="Siguiente" />
                                        </div>
                                    </div>
                                </form>
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
                            <li class="breadcrumb-item" on_leave="#scr_periodos"><a href="#">Comités de Evaluacion</a></li>
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
                                            <form id="frm_agregar_integrante" method="get">
                                                <h5 class="card-title">Agregar Integrante</h5>
                                                <div class="form-group row">
                                                    <label for="buscador" class="col-12 col-md-2 offset-md-2 col-form-label">Integrante</label>
                                                    <div id="cmb_selector_integrantes" class="col-12 col-md-6">
                                                        <input id="buscador" name="buscador" type="hidden" class="buscarPersona" />
                                                        <input type="hidden" id="persona_buscada" name="persona_buscada" required />
                                                    </div>
                                                    <div class="col col-md-2"></div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="caracter" class="col-12 col-md-2 offset-md-2 col-form-label">En Caracter De</label>
                                                    <div class="col-12 col-md-6">
                                                        <select class="form-control" id="cmb_en_caracter_de" name="cmb_en_caracter_de" required>
                                                            <option value="">--Todos--</option>
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
                                                        <input id="btn_agregar_integrante" type="submit" class="btn btn-primary active" role="button" value="Agregar" />
                                                        <!--<button id="btn_agregar_integrante" type="button" class="btn btn-sm btn-primary">Agregar >></button>-->
                                                    </div>
                                                    <div class="col col-md-2"></div>
                                                </div>
                                            </form>
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
                            <li class="breadcrumb-item" on_leave="#scr_periodos"><a href="#">Comités de Evaluacion</a></li>
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
                                                <input type="checkbox" cb_checked="{{Selected}}" model_id="{{Id}}" />
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
            <div class="row">
                <div class="col">&nbsp;</div>
            </div>
        </div>
        <div role="tabpanel" id="scr_evaluaciones" style="display: none">
            <div class="row">
                <div class="col col-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item" on_leave="#scr_periodos"><a href="#">Comités de Evaluacion</a></li>
                            <li class="breadcrumb-item" on_leave="#scr_datos_generales"><a href="#">Paso 1: Datos Generales</a></li>
                            <li class="breadcrumb-item" on_leave="#scr_integrantes"><a href="#">Paso 2: Integrantes</a></li>
                            <li class="breadcrumb-item" on_leave="#scr_unidades"><a href="#">Paso 3: Unidades de Evaluacion</a></li>
                            <li class="breadcrumb-item  active">Paso 4: Evaluaciones</li>
                        </ol>
                    </nav>
                </div>
                <div class="col"></div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-4">
                                    <h5 class="card-title">Nueva Reunión</h5>
                                    <h6 class="card-subtitle mb-2 text-muted">Paso 4: Evaluaciones</h6>
                                    <p class="lead" id="desc_periodo_eval" />
                                </div>
                                <div class="col-8">
                                    <!--tabla resumen en tab evaluaciones -->
                                    <table class="table table-bordered table-striped table-sm" id="tabla_resumen">
                                        <thead>
                                            <tr>
                                                <th class="text-center"><small class="text-muted">Destacados</small></th>
                                                <th class="text-center"><small class="text-muted">Bueno</small></th>
                                                <th class="text-center"><small class="text-muted">Regular</small></th>
                                                <th class="text-center"><small class="text-muted">Deficiente</small></th>
                                                <th class="text-center"><small>Total Evaluados</small></th>
                                                <th class="text-center"><small class="text-muted">Provisoria</small></th>
                                                <th class="text-center"><small class="text-muted">Pendiente</small></th>
                                                <th class="text-center"><small>Total General</small></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="row-template" style="display: none">
                                                <td class="text-right">{{Destacados}}</td>
                                                <td class="text-right">{{Bueno}}</td>
                                                <td class="text-right">{{Regular}}</td>
                                                <td class="text-right">{{Deficiente}}</td>
                                                <td class="text-right">{{TotalEvaluados}}</td>
                                                <td class="text-right">{{Provisorias}}</td>
                                                <td class="text-right">{{Pendientes}}</td>
                                                <td class="text-right">{{TotalGeneral}}</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="card-text">
                                <div class="card border-dark mb-3 col-12">
                                    <div class="card-body text-dark">
                                        <div class="form-group row">
                                            <label for="txt_filtro_apellido" class="col-12 col-md-2 col-form-label text-right">Filtro por apellido</label>
                                            <div class="col-5 col-md-3">
                                                <input type="text" class="form-control" id="txt_filtro_apellido" name="txt_filtro_apellido" placeholder="Apellido">
                                            </div>
                                            <label for="txt_filtro_estado" class="col-12 col-md-2 col-form-label text-right">Filtro por estado</label>
                                            <div class="col-5 col-md-3">
                                                <select class="custom-select" id="inputGroupSelect01">
                                                    <option selected>Seleccione</option>
                                                    <option>Provisoria</option>
                                                    <option>Pendiente</option>
                                                    <option disabled>──────────</option>
                                                    <option value="1">Destacados</option>
                                                    <option value="2">Bueno</option>
                                                    <option value="3">Regular</option>
                                                    <option value="3">Deficiente</option>
                                                </select>
                                            </div>
                                            <div class="col">
                                                <input type="submit" class="btn btn-primary active" role="button" value="Filtrar" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-text">
                                    <td class="row">
                                        <table class="table table-bordered table-striped table-sm" id="tabla_evaluaciones">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Dni</th>
                                                    <th class="text-center">Apellido</th>
                                                    <th class="text-center">Nombre</th>
                                                    <th class="text-center">Area</th>
                                                    <th class="text-center">Evaluacion</th>
                                                    <th class="text-center">GDE</th>
                                                    <th class="text-center">Accion</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr class="row-template" style="display: none">
                                                    <td class="text-right">{{Dni}}</td>
                                                    <td class="text">{{Apellido}}</td>
                                                    <td class="text">{{Nombre}}</td>
                                                    <td class="text">{{Area}}</td>
                                                    <td class="text">{{Evaluacion}}</td>
                                                    <td class="text small">{{GDE}}</td>
                                                    <td class="text-center">
                                                        <span style="display: inline">
                                                            <a style="display: inline" data-toggle="tooltip" data-placement="top" title="Reevaluar" class="text-info modificar_evaluacion" href="#" opcion_disponible="{{AunNoAprobado}}" model_id="{{IdEvaluacion}}" ><span class="fa fa fa-undo"></span></a>
                                                            <a style="display: inline" data-toggle="tooltip" data-placement="top" title="Ver" class="nav-link ver_eval" model_id="{{IdEvaluacion}}" href="#"><span class="fa fa fa-eye"></span></a>
                                                            <a style="display: inline" data-toggle="tooltip" data-placement="top" title="Aprobar" class="text-success aprobador_evaluacion" href="#" opcion_disponible="{{AunNoAprobado}}" model_id="{{IdEvaluacion}}"><span class="fa fa fa-check-circle"></span></a>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col col-md-12 text-right">
                                    <a href="#" class="btn btn-secondary" role="button" on_leave="#scr_unidades">Atras</a>
                                    <a href="#" class="btn btn-primary active" role="button" on_leave="#scr_periodos">Finalizar</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">&nbsp;</div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal spinner-modal fade bd-example-modal-lg" data-backdrop="static" data-keyboard="false" tabindex="-1">
            <div class="modal-dialog modal-sm">
                <div class="modal-content" style="width: 48px">
                </div>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="AprobarEvaluacionModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Aprobar Evaluación</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body text-center">
                        <p>
                            ¿Esta seguro que desea aprobar la evaluacion de <br /><b><span id="span_evaluado_a_aprobar"></b></span>?
                            <br /><small>(esta opción no se puede "deshacer")</small>
                        </p>
                        
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        <button type="button" id="btn_aprobar_evaluacion" class="btn btn-primary">Aprobar</button>
                        <input type="hidden" id="id_evaluacion_a_aprobar" ></input>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal spinner-modal fade bd-example-modal-lg" data-backdrop="static" data-keyboard="false" tabindex="-1">
            <div class="modal-dialog modal-sm">
                <div class="modal-content" style="width: 48px">
                    <span class="fa fa-spinner fa-pulse fa-3x"></span>
                </div>
            </div>
        </div>
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
                    <span id="documento" name="documento"></span>
                </span>
            </div>
        </div>
</body>
</html>
