$('<link id="cssToolTipo" rel="stylesheet" type="text/css" href="../Scripts/tooltipo/tooltipo.css" >')
        .appendTo("head");
$('[tooltipo]').each(function () {
    var elemento = $(this);
    var contenedor = $("<a>");
    contenedor.addClass("tooltipo");
    contenedor.attr("href", "#");
    elemento.wrap(contenedor);
    var span = $("<span>" + elemento.attr("tooltipo") + "</span>");
    var imagenPikito = $("<img>");
    imagenPikito.addClass("callout");
    imagenPikito.attr("src", "../Scripts/tooltipo/callout_black.gif");
    span.prepend(imagenPikito);
    elemento.after(span);
});