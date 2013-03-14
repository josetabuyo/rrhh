<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPlanillaAsistenciasAlumnos.ascx.cs" Inherits="ControlPlanillaAsistenciasAlumnos" %>
<asp:HiddenField ID="planillaJSON" runat="server" EnableViewState="true"/>
<asp:HiddenField ID="Curso" runat="server" EnableViewState="true"/>
<asp:HiddenField ID="CursoId" Value="0" runat="server" EnableViewState="true" />
<asp:HiddenField ID="Mes" Value="0" runat="server" EnableViewState="true" />

<div id="ContenedorPlanilla" runat="server">

</div>
<input type="hidden" id="DetalleAsistencias" runat="server" />