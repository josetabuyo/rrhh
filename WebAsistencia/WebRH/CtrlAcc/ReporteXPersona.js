
jQuery(document).ready(function () {
    $('#btnPrueba').click(function () {
        var nombre = $('#txtNombre').val();
        var apellido = $('#txtApellido').val();
        if (nombre && (nombre != ''))
            sendDataAjax(nombre, apellido);
    });
});

function sendDataAjax(p_nombre, p_apellido) {
    var actionData = "{'nombre': '" + p_nombre + "', 'apellido': '" + p_apellido + "'}";
    $.ajax(
            {
                url: "ReporteXPersona.aspx/GetData",
                data: actionData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (msg) { alert(msg.d); },
                error: function (result) {
                    alert("ERROR " + result.status + ' ' + result.statusText);
                }
            });
};