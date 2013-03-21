<%@ page language="C#" autoeventwireup="true" inherits="FormulariosDeLicencia_F10G_Maternidad, App_Web_omefktye" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%; text-align: center; border: 0;">
            <tr>
                <td style="height: 1046px">
                    <table border="1" style="width: 642px; text-align: center;">
                        <tr>
                            <td style="height: 425px; width: 100%; text-align: center;">
                                <div>
                                    <asp:Label ID="LError" runat="server" EnableTheming="False" Font-Bold="True" Font-Size="20px"
                                        ForeColor="Red">
                                    </asp:Label>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LTitulo" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
                                                    Font-Underline="True" ForeColor="DimGray" Text="Licencia Especial por Maternidad"></asp:Label><br />
                                                <asp:Label ID="LTituloSecundario" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="10pt" Text="(Decreto 3.413/79 - Anexo I - Cap. III - Art. 10 g)"></asp:Label><br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 21px; text-align: left">
                                                <asp:Label ID="LProcedimiento" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="Small" Font-Underline="True" Text="Procedimiento para su solicitud:"></asp:Label><br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 46px; text-align: left">
                                                <asp:Label ID="Label1" runat="server" Text="1) La licencia médica debe ser solicitada telefónicamente por el agente afectado o un familiar del mismo al lugar de trabajo durante el PRIMER DIA de ausencia laboral."
                                                    Width="590px"></asp:Label><br />
                                                <asp:Label ID="Label2" runat="server" Text="2) Asimismo, estas circunstancias deben informarse inmediatamente por teléfono o personalmente al Departamento de Medicina Ocupacional  (Av. 9 de Julio 1925 Piso 21° Ala Belgrano - Tel: 4379-3722), ACOMPAÑANDO LOS CERTIFICADOS PERTINENTES. "
                                                    Width="588px"></asp:Label><br />
                                                <table style="width: 583px">
                                                    <tr>
                                                        <td style="width: 55px">
                                                        </td>
                                                        <td style="width: 460px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 55px">
                                                        </td>
                                                        <td style="width: 460px">
                                                            <asp:Label ID="Label3" runat="server" Text="En caso de “Enfermedad en horas de labor” o “Accidentes de trabajo” debe informarse también a la ART “LA CAJA” al 0800-888-0200. Le solicitaran el Nº de CUIL del empleado."
                                                                Width="455px"></asp:Label></td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 55px">
                                                        </td>
                                                        <td style="width: 460px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="Label4" runat="server" Text="4) Antes de reincorporarse, el agente deberá concurrir OBLIGATORIAMENTE al Departamento Médico Ocupacional, con los certificados originales correspondientes, quien otorgará el alta respectiva, sin la cual no podrá reintegrarse a su lugar de trabajo, caso contrario, irá a descuento de haberes."
                                                    Width="587px"></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label5" runat="server" Text="Recordar: El agente no podrá usufructuar otro tipo de licencias hasta no tener el alta otorgada por el Servicio Médico de este Ministerio. Recordar apto médico definitivo."></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <hr />
                                                <asp:Label ID="LNormativa" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
                                                    Font-Underline="True" Text="Normativa"></asp:Label>&nbsp;<br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="text-align: left">
                                                <asp:Label ID="Label7" runat="server" Text="Art. 10 - Concepto. Las licencias especiales se acordarán por los motivos que se consigna y conforme a las siguientes normas: "
                                                    Width="590px"></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label6" runat="server" Text="g) Maternidad."></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label8" runat="server" Text="Las licencias por maternidad, se acordarán conforme a las leyes vigentes. A petición de parte y previa certificación de autoridad médica competente que así lo aconseje, podrá acordarse cambio de destino o de tareas a partir de la concepción y hasta el comienzo de la licencia por maternidad. En caso de parto múltiple, el período siguiente al parto se ampliará en diez (10) días corridos por cada alumbramiento posterior al primero."
                                                    Width="590px"></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label9" runat="server" Text='En el supuesto de parto diferido se ajustará la fecha inicial de la licencia, justificándose los días previos a la iniciación real de la misma, con arreglo a lo previsto en el artículo 10 incisos a) "afecciones o lesiones de corto tratamiento" o c) "afecciones o lesiones de largo tratamiento". La disposición precedente será también de aplicación en los casos de partos con fetos muertos. &#13;&#10;'
                                                    Width="590px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 15px">
                                                <hr />
                                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Convenio Colectivo de Trabajo General para la Administración Pública Nacional (Homologado por Decreto Nº 214 del 29 de Diciembre de 2005) TÍTULO XII - REGIMEN DE LICENCIAS, JUSTIFICACIONES Y FRANQUICIAS "
                                                    Width="589px"></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label11" runat="server" Text="ARTICULO 114.- Derechos. El Personal permanente y no permanente tendrá a partir de la fecha de su incorporación, derecho a las licencias, justificaciones y franquicias previstas en sus respectivos regímenes, los que quedan incorporados al presente convenio."></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label12" runat="server" Text="En todos los casos se adicionarán las siguientes licencias:"></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label13" runat="server" Text="Maternidad. Queda prohibido el trabajo del personal femenino durante los TREINTA (30) días anteriores al parto y hasta SETENTA (70) días corridos después del mismo."
                                                    Width="590px"></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label14" runat="server" Text="Sin embargo, la interesada podrá optar, presentando un certificado médico autorizante, por que se le reduzca la licencia anterior al parto. En este caso y en el de nacimiento pretérmino se acumulará al descanso posterior todo el lapso de licencia que no se hubiese gozado antes del parto, de modo de completar los CIEN (100) días."
                                                    Width="590px"></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label15" runat="server" Text="La trabajadora deberá comunicar fehacientemente su embarazo al empleador con presentación de certificado médico en el que conste la fecha presunta del parto o requerir su comprobación por el empleador. La trabajadora conservará su empleo durante los periodos indicados, y gozará de las asignaciones que le confieren los sistemas de seguridad social, que garantizarán a la misma la percepción de una suma igual a la retribución que le corresponda al período de licencia legal, todo de conformidad con las exigencias y demás requisitos que prevean las reglamentaciones respectivas."></asp:Label><br />
                                                <br />
                                                <asp:Label ID="Label16" runat="server" Text="Garantízase a toda mujer durante la gestación el derecho a la estabilidad en el empleo. El mismo tendrá carácter de derecho adquirido a partir del momento en que la trabajadora practique la notificación a que se refiere el párrafo anterior."
                                                    Width="590px"></asp:Label><br />
                                                <br />
                                                <table align="center" border="1">
                                                    <tr>
                                                        <td class="negroTH">
                                                            <asp:Label ID="LInformar" runat="server" Text='Para informar una ausencia por este concepto presione el botón "Informar Ausente con Aviso" (en el Parte Diario figurará "Ausente con Aviso"). Recuerde que debe seguir los pasos indicados en el Procedimiento explicitado arriba. '
                                                                Width="581px"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="negroTH">
                                                            <asp:Label ID="LConsultar" runat="server" Text='Si sólo deseaba consultar las características de esta Licencia, presione "Cancelar" y volverá a la pantalla anterior.'
                                                                Width="580px"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="middle" style="height: 29px; text-align: center;">
                                                            <asp:Button ID="BAceptar" runat="server" Text="Informar Ausente con Aviso" OnClick="BAceptar_Click" />&nbsp;
                                                            <asp:Button ID="BCancelar" runat="server" OnClick="BCancelar_Click" Text="Cancelar" />&nbsp;
                                                            <!--<a href="../indice.asp">Volver</a>-->
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
