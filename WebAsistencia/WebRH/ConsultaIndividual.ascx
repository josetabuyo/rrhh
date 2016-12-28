<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsultaIndividual.ascx.cs" Inherits="ConsultaIndividual" %>

<div id="panel_izquierdo" style="width:95%;" class="estilo_formulario">
    <div class="bloque_foto">
        <img id="foto_usuario" src="../Imagenes/silueta.gif" alt="Usuario" width="128" height="128">
        <!--<input id="btn_timeline" type="button" value="Carrera" class="btn btn-primary" />-->
    </div>
        <div id="panel_datos_personales">
            <div class="linea dato_personal">
                    <fieldset>
                    <legend>Datos Personales</legend>
                    <div>
                        <p class="bloque_consulta"><label>Legajo: </label><span id="legajo_consulta"></span></p>
                        <p class="bloque_consulta"><label>Documento: </label><span id="documento_consulta"></span></p>
                    </div>
                    <div>
                        <p class="bloque_consulta"><label>Nombre: </label><span id="nombre_consulta"></span></p>
                        <p class="bloque_consulta"><label>Edad: </label><span id="edad"></span></p>
                    </div>
                    <div>
                        <p class="bloque_consulta"><label>F. Nacimiento: </label><span id="fechaNacimiento"></span></p>
                        <p class="bloque_consulta"><label>Sexo: </label><span id="sexo"></span></p>
                    </div>
                    <div>
                        <p class="bloque_consulta"><label>Estado Civil: </label><span id="estadoCivil"></span></p>
                        <p class="bloque_consulta"><label>CUIL: </label><span id="cuil"></span></p>
                    </div>
                    <div>
                        <p class="bloque_consulta_full"><label>Domicilio: </label><span id="domicilio"></span></p>
                    </div>
                    <div>
                        <p class="bloque_consulta_full"><label>Estudio: </label><span id="estudio"></span></p>
                    </div>
                </fieldset>
            </div>
        </div>
        <div class="linea dato_personal">
            <fieldset>
                <legend>Cargo y Actividad</legend>
                    <div>
                    <p class="bloque_consulta_full"><label>Sector: </label><span id="sector"></span></p> 
                </div>
                <div>
                    <p class="bloque_consulta"><label>Nivel y Grado: </label><span id="nivel_grado"></span></p>
                    <p class="bloque_consulta"><label>Planta: </label><span id="planta"></span></p>
                </div>
                <div>
                    <p class="bloque_consulta"><label>Cargo: </label><span id="cargo"></span></p>
                    <p class="bloque_consulta"><label>Agrupamiento: </label><span id="agrupamiento"></span></p>
                </div>
                <div>
                    <p class="bloque_consulta"><label>Ing. Min.: </label><span id="ing_min"></span></p>
                    </div>  
            </fieldset>
            </div>
                    <!--<div class="linea dato_personal">
                    <fieldset>
                        <legend>Antiguedad</legend>
                        <div>
                            <p class="bloque_consulta"><label>Estado: </label><span id="estado"></span></p>
                            <p class="bloque_consulta"><label>Privada: </label><span id="privada"></span></p>
                            <p class="bloque_consulta"><label>Resta: </label><span id="resta"></span></p>
                        </div>
                        <div>
                            <p class="bloque_consulta"><label>Ing. Min.: </label><span id="ing_min"></span></p>
                            <p class="bloque_consulta"><label>Ant. Min: </label><span id="ant_min"></span></p>
                            <p class="bloque_consulta"><label>Total: </label><span id="total"></span></p>
                            </div>
                    </fieldset>
                    </div>   -->
</div>