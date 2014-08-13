<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pasos.ascx.cs" Inherits="FormularioConcursar_Pasos" %>

 <div style="margin:20px 5px;">
            <div class="pasos">
                <ul>
                    <li class="" >
                        <a id="paso_1" class="link_activado"><span class="number">1. </span>Postulaciones</a>
                    </li>
                    <li class="" >
                        <a id="paso_2" class="link_desactivado"><span class="number">2. </span>Pre-Inscripcion</a>
                    </li>
                    <li  class="" >
                        <a id="paso_3" class="link_desactivado"><span class="number">3. </span>Inscripcion</a>
                    </li>
                </ul>
            </div>
            <div class="actions clearfix">
                <ul>
                    <li class="" ><a href="javascript:Anterior();" id="anterior">Anterior</a></li>
                    <li ><a id="siguiente" onclick="javascript:Siguiente();" >Siguiente</a></li>
                    <li style="display: none;"><a href="#finish" >Finalizar</a></li>
                </ul>
            </div>
        </div>
