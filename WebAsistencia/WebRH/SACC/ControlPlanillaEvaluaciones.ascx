<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPlanillaEvaluaciones.ascx.cs" Inherits="SACC_ControlPlanillaEvaluaciones" %>

<asp:HiddenField ID="planillaJSON" runat="server" EnableViewState="true"/>
<asp:HiddenField ID="Curso" runat="server" EnableViewState="true"/>
<asp:HiddenField ID="CursoId" Value="0" runat="server" EnableViewState="true" />

<div id="ContenedorPlanilla" runat="server">

</div>
<input type="hidden" id="DetalleEvaluaciones" runat="server" />
