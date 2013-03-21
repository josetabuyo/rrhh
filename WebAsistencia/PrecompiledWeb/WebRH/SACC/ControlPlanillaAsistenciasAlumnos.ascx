<%@ control language="C#" autoeventwireup="true" inherits="ControlPlanillaAsistenciasAlumnos, App_Web_c0pv0oqu" %>
<asp:HiddenField ID="planillaJSON" runat="server" EnableViewState="true"/>
<asp:HiddenField ID="Curso" runat="server" EnableViewState="true"/>
<asp:HiddenField ID="CursoId" Value="0" runat="server" EnableViewState="true" />
<asp:HiddenField ID="Mes" Value="0" runat="server" EnableViewState="true" />

<div id="ContenedorPlanilla" runat="server">

</div>
<input type="hidden" id="DetalleAsistencias" runat="server" />