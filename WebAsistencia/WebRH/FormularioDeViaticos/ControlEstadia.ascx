<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlEstadia.ascx.cs" Inherits="ControlEstadia" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.0.30930.28736, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Src="GrillaEstadias.ascx" TagName="GrillaEstadias" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>


<style type="text/css">
    .style1
    {
        width: 64px;
    }
</style>

<script src="../Scripts/bootstrap/js/jquery.validate.js" type="text/javascript"></script>





<script type ="text/javascript" language="javascript">

    function ValidaSecuencia(source, arguments) {

        var id_hasta = '<%=TBFechaHasta.ClientID%>';
        var id_desde = '<%=TBFechaDesde.ClientID%>';

        var id_hora_desde = '<%=TBHoraDesde.ClientID%>';
        var id_hora_hasta = '<%=TBHoraHasta.ClientID%>';

     
        //Obtiene valor de los textbox de fechas				
        var fecha_desde = document.getElementById(id_desde).value;
        var fecha_hasta = document.getElementById(id_hasta).value;

        //Obtiene valor de los textbox de hora	
        var hora_desde = document.getElementById(id_hora_desde).value;
        var hora_hasta = document.getElementById(id_hora_hasta).value;

             
        //Comprobación de valor 
        if ((fecha_desde == fecha_hasta) && (hora_desde > hora_hasta)) 
        {
            arguments.IsValid = false;
            return;
        }
        arguments.IsValid = true; //
    }


    function ValidaFechas(source, arguments) 
    {
      
        var id_hasta = '<%=TBFechaHasta.ClientID%>';
        var id_desde = '<%=TBFechaDesde.ClientID%>';
      

        //Obtiene valor de los textbox de fechas				
        var fecha_desde = document.getElementById(id_desde).value;
        var fecha_hasta = document.getElementById(id_hasta).value;

        //Obtiene valor de los textbox de fecha
        //alert(fecha_desde.length);
        //Comprobación de valor 
        if ((fecha_desde.length < 10)) 
        {
            arguments.IsValid = false;
            return;
        }

        arguments.IsValid = true; //
    }



    function ValidaFormatoFechas(source, arguments) {


        var id_hasta = '<%=TBFechaHasta.ClientID%>';
        var id_desde = '<%=TBFechaDesde.ClientID%>';


        //Obtiene valor de los textbox de fechas				
        var fecha_desde = document.getElementById(id_desde).value;
        var fecha_hasta = document.getElementById(id_hasta).value;

        alert(fecha_desde.toString().length);

        var sExpresion = /^\d{2}\/\d{2}\/\d{4}$/;

        if (fecha_desde.toString().length < 10)
        {
            arguments.IsValid = true;
                        return;
        }
        arguments.IsValid = false;
      
       
        //Obtiene valor de los textbox de fecha
        //alert(fecha_desde.length);
        //Comprobación de valor 
//        if ((fecha_desde.length < 10)) {
//            arguments.IsValid = false;
//            return;
//        }

//        arguments.IsValid = true; //
    }




</script>

                
   

<%--<table>
             <tr>
               <td>
                  <asp:TextBox ID="ControlEstadiaName" runat="server" CssClass="input-small" name = "ControlEstadiaName" />
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" 
                TargetControlID="ControlEstadia$ControlEstadiaName" />
               </td>
             </tr>
             <tr>
               <td>
                  <input type="text" name="mail" id="mail" />
               </td>
             </tr>
             <tr>
                <td>
                   <input type="text" name="edad" id="edad" />
                </td>
             </tr>
          </table>
--%>
  <%--        <input id="buton"type="submit" value="Enviar" />--%>




 <table id= "tabla" style="width:100%;" >
            
            <tr>
                <td align="center" class="style1">
                 <asp:Label ID="Label2" CssClass="control-label" Text="Desde" runat="server" />
                 </td>
                 <td>
                    <span style="padding-right: 5px;">
                    <asp:Label ID="Label10" Text="Fecha:" runat="server" /></span>
                </td>
                <td>
                <asp:TextBox ID="TBFechaDesde" runat="server" CssClass="input-small" 
                        name = "TBFechaDesde" MaxLength="10" />
                    
                <cc1:CalendarExtender ID="TextBox1_CalendarExtender" Format="dd/MM/yyyy" runat="server" 
                TargetControlID="TBFechaDesde" />
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBFechaDesde"
                    ErrorMessage="*" ></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                        runat="server" ControlToValidate="TBFechaDesde" 
                        
                        
                        ValidationExpression="^\d\d\/\d\d\/\d\d\d\d$" 
                        ></asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                        runat="server" ControlToValidate="TBFechaDesde"></asp:RequiredFieldValidator>

                     
                     <%--        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                        ControlToValidate="TBFechaDesde" ErrorMessage="aa" 
                        ClientValidationFunction="ValidaFormatoFechas"></asp:CustomValidator>--%>

                     
                             </td>

                             

            </tr>
            <tr>
            <td align="center" class="style1">
            </td>
                <td>
                   <span style="padding-right: 14px;">
                    <asp:Label ID="Label1" Text="Hora: " runat="server" /></span>
                </td>
                <td>
                <asp:TextBox ID="TBHoraDesde" CssClass="input-small" runat="server" MaxLength="5"
               ></asp:TextBox>
                <cc1:MaskedEditExtender ID="MaskedEditExtender_TBHoraDesde" runat="server" TargetControlID="TBHoraDesde"
                Mask="99:99" MessageValidatorTip="true" MaskType="Time" AcceptAMPM="False" CultureName="es-AR" />
                <cc1:MaskedEditValidator ID="MaskedEditValidator_TBHoraDesde" runat="server" ControlExtender="MaskedEditExtender_TBHoraDesde"
                ControlToValidate="TBHoraDesde" IsValidEmpty="false" EmptyValueMessage="*" InvalidValueMessage="Hora inválida"
                ValidationGroup="Demo_TBHoraDesde" Display="Dynamic" TooltipMessage="" 
                        ErrorMessage="MaskedEditValidator_TBHoraDesde" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TBHoraDesde" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>

            </tr>

            <tr>
                <td align="center" class="style1">
                 <asp:Label ID="Label3" CssClass="control-label" Text="Hasta" runat="server" />
                    <span style="padding-right: 5px;" </span>
                 </td>
                 <td>
                    <asp:Label ID="Label11" Text="Fecha:" runat="server" />
                </td>
                <td>
                <asp:TextBox ID="TBFechaHasta" runat="server" CssClass="input-small" 
                        MaxLength="10" />
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="TBFechaHasta" />
               
                <asp:CompareValidator ID="CompareValidator1" runat="server" type = "date"
                ControlToCompare="TBFechaDesde" ControlToValidate="TBFechaHasta" 
                ErrorMessage="*" Operator="GreaterThanEqual"></asp:CompareValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="TBFechaHasta"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="TBFechaHasta" 
                        ValidationExpression="^\d\d\/\d\d\/\d\d\d\d$" ValidationGroup="fechas"></asp:RegularExpressionValidator>

                </td>

            </tr>
            <tr>
            <td align="center" class="style1">
            </td>
                <td>
                   <span style="padding-right: 14px;">
                    <asp:Label ID="Label12" Text="Hora: " runat="server" /></span>
                </td>
                <td>
                 <asp:TextBox ID="TBHoraHasta" CssClass="input-small" runat="server" MaxLength="5"
                 ValidationGroup="Demo_TBHoraHasta"></asp:TextBox>
                <cc1:MaskedEditExtender ID="MaskedEditExtender_TBHoraHasta" runat="server" TargetControlID="TBHoraHasta"
                Mask="99:99" MessageValidatorTip="true" MaskType="Time" AcceptAMPM="False" CultureName="es-AR" />
                <cc1:MaskedEditValidator ID="MaskedEditValidator_TBHoraHasta" runat="server" ControlExtender="MaskedEditExtender_TBHoraHasta"
                ControlToValidate="TBHoraHasta" IsValidEmpty="false" InvalidValueMessage="Hora inválida"
                ValidationGroup="Demo_TBHoraHasta" Display="Dynamic" TooltipMessage="" 
                        ErrorMessage="*" />
                

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="TBHoraHasta" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
            <td align="center" class="style1">
            </td>
                <td>
                  <asp:Label ID="Label13" CssClass="control-label" Text="Eventuales: " runat="server" />
                </td>
                <td>
                 <asp:TextBox ID="TBEventuales" runat="server" CssClass="input-small" 
                        MaxLength="8" />
                    <cc2:FilteredTextBoxExtender ID="TBEventuales_FilteredTextBoxExtender" ValidChars="1234567890."
                    runat="server" TargetControlID="TBEventuales">
                     </cc2:FilteredTextBoxExtender>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TBEventuales" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="TBEventuales" ValidationExpression="^\d+\.?\d*$" ErrorMessage="Importe incorrecto"></asp:RegularExpressionValidator>


                        
                 </td>
            </tr>
            <tr>
            <td align="center" class="style1">
            </td>
                <td>
                  <asp:Label ID="Label14" CssClass="control-label" Text="Adic. x Pasajes: " runat="server" /> 
                </td>
                <td>
                <asp:TextBox ID="TBAdicionalPorPasajes" runat="server" CssClass="input-small" 
                        MaxLength="8" >0.00</asp:TextBox>
                 <cc2:FilteredTextBoxExtender ID="TBAdicionalPorPasajes_FilteredTextBoxExtender" runat="server"
                 TargetControlID="TBAdicionalPorPasajes" ValidChars="1234567890.">
                 </cc2:FilteredTextBoxExtender>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TBAdicionalPorPasajes"
                 ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                        ControlToValidate="TBAdicionalPorPasajes" ErrorMessage="Importe incorrecto" 
                        ValidationExpression="^\d+\.?\d*$"></asp:RegularExpressionValidator>
                </td>

            </tr>
            <tr>
            <td align="center" class="style1">
            </td>
                <td>
                 <asp:Label ID="Label15" CssClass="control-label" Text="Provincia: " runat="server" />  
                </td>
                <td>
                <asp:DropDownList ID="DDLProvincias" runat="server" CssClass="input-medium">
                </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                        ControlToValidate="DDLProvincias" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
            <td align="center" class="style1">
            </td>
                <td>
                   <asp:Label ID="Label16" CssClass="control-label" runat="server" Text="Motivo: "></asp:Label>
                </td>
                <td>
                <asp:TextBox id = "TBMotivo" runat="server" name = "TBMotivo" CssClass="input-medium" MaxLength="200"></asp:TextBox>
                    </td>
            </tr>
        </table>
        

<%--Comentado por German porque no podiamos pasar de solapas entre la estadia y los pasajes--%>

        
        <script type="text/javascript">
            $(document).ready(function () {
        
               

       jQuery.validator.addMethod("fechadesde", function(value, element) { 

        
          if(/^\d{2}\/\d{2}\/\d{4}/i.test(value)) { 
         
            var year = substr(value, 6, 4); 
            var month = substr(value, 3, 2); 
            var day = substr(value, 0, 2); 
            if (month == 2) { 
                if (day == 29) { 
                    if (year % 4 != 0 || year % 100 == 0 && year % 400 != 0) { 
                        var errors = {}; 
                        errors[element.name] = jQuery.format('Fecha incorrecta', new Array(year)); 
                        this.showErrors(errors); 
                    } 
                } 
                else if (day > 28) { 
                    var errors = {}; 
                    errors[element.name] = jQuery.format('Fecha incorrecta', new Array(year)); 
                    this.showErrors(errors); 
                } 
            } 
            else if (month == 4 || month == 6 || month  == 9 || month == 11) { 
                if (day > 30) { 
                    var errors = {}; 
                    errors[element.name] = 'Fecha incorrecta'; 
                    this.showErrors(errors); 
                } 
            } 
            else { 
                if (day > 31) { 
                    var errors = {}; 
                    errors[element.name] = 'Fecha incorrecta'; 
                    this.showErrors(errors); 
                } 
            } 
            var today = new Date(); 
            today.setHours(23); 
            today.setMinutes(59);   
            today.setSeconds(59); 
            var new_epoch = new Date('2000', '0', '1'); 
            var entered_date = new Date(year, month - 1, day, 23, 59, 59); 
            if ((entered_date > today) || (entered_date < new_epoch)) { 
                var errors = {}; 
                errors[element.name] = 'Fecha incorrecta'; 
                this.showErrors(errors); 
            } 
            else { 
                this.hideErrors(); 
                return true; 
            }o 
        } 
        else { 
            var errors = {}; 
            errors[element.name] = 'Fecha incorrecta'; 
            this.showErrors(errors); 
        } 
        return true; 
    });         
 

 
      jQuery.validator.addMethod("fechahasta", function(value, element) { 
          if(/^\d\d\/\d\d\/\d\d\d\d/i.test(value)) { 
          
            var year = substr(value, 6, 4); 
            var month = substr(value, 3, 2); 
            var day = substr(value, 0, 2); 
            if (month == 2) { 
                if (day == 29) { 
                    if (year % 4 != 0 || year % 100 == 0 && year % 400 != 0) { 
                        var errors = {}; 
                        errors[element.name] = jQuery.format('Fecha incorrecta', new Array(year)); 
                        this.showErrors(errors); 
                    } 
                } 
                else if (day > 28) { 
                    var errors = {}; 
                    errors[element.name] = jQuery.format('Fecha incorrecta', new Array(year)); 
                    this.showErrors(errors); 
                } 
            } 
            else if (month == 4 || month == 6 || month  == 9 || month == 11) { 
                if (day > 30) { 
                    var errors = {}; 
                    errors[element.name] = 'Fecha incorrecta'; 
                    this.showErrors(errors); 
                } 
            } 
            else { 
                if (day > 31) { 
                    var errors = {}; 
                    errors[element.name] = 'Fecha incorrecta'; 
                    this.showErrors(errors); 
                } 
            } 
            var today = new Date(); 
            today.setHours(23); 
            today.setMinutes(59);   
            today.setSeconds(59); 
            var new_epoch = new Date('2000', '0', '1'); 
            var entered_date = new Date(year, month - 1, day, 23, 59, 59); 
            if ((entered_date > today) || (entered_date < new_epoch)) { 
                var errors = {}; 
                errors[element.name] = 'Fecha incorrecta'; 
                this.showErrors(errors); 
            } 
            else { 
                this.hideErrors(); 
                return true; 
            }o 
        } 
        else { 
            var errors = {}; 
            errors[element.name] = 'Fecha incorrecta'; 
            this.showErrors(errors); 
        } 
        return true; 
    });         

  

        $("#form1").validate({
            rules: {
                debug:true,
            
            <%= TBFechaDesde.UniqueID  %>:{ Date: true},
            <%= TBFechaDesde.UniqueID  %>:{ required: true},
            <%= TBFechaDesde.UniqueID  %>: "fechadesde",

            <%= TBFechaHasta.UniqueID  %>:{ Date: true},
            <%= TBFechaHasta.UniqueID  %>:{ required: true},
            <%= TBFechaHasta.UniqueID  %>: "fechahasta",
           
           
           
//            <%= TBEventuales.UniqueID  %>:{ required: true, number: true },
            },
            messages: {
                        
//            <%= TBEventuales.UniqueID  %>: "Importe incorrecto",
            <%= TBFechaDesde.UniqueID  %>: "Fecha incorrecta",
            <%= TBFechaHasta.UniqueID  %>: "Fecha incorrecta"
            },
        });
    });
         </script>
        