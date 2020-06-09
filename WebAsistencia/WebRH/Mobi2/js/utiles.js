


var UTIL = (function (window, undefined) {

    function enlazarEnter(idInput,idbtnClick) {
        /*codigo para capturar el enter, emulando el click sobre el boton buscar */
        var input = document.getElementById(idInput);
        input.addEventListener("keyup", function (event) {
            if (event.keyCode === 13) {
                event.preventDefault();
                document.getElementById(idbtnClick).click();
            }
        }); 
    }

    function generarAnios(idSelect, cantAnios) {
        /*codigo para capturar el enter, emulando el click sobre el boton buscar */
        var input = document.getElementById(idSelect);
        var day = new Date();
        var anio = day.getFullYear();        

        for (var i = 0; i <= cantAnios; i++) {
            $("#" + idSelect).append('<option value=' + (anio - i).toString() + '>' + (anio - i).toString() + '</option>');
        }
    }

    function descargarPDF(b64,nombrePDF) {
        var base64Data = b64;
        var arrBuffer = base64ToArrayBuffer(base64Data);

        // It is necessary to create a new blob object with mime-type explicitly set
        // otherwise only Chrome works like it should
        var newBlob = new Blob([arrBuffer], { type: "application/pdf" });

        // IE doesn't allow using a blob object directly as link href
        // instead it is necessary to use msSaveOrOpenBlob
        if (window.navigator && window.navigator.msSaveOrOpenBlob) {
            window.navigator.msSaveOrOpenBlob(newBlob);
            return;
        }

        // For other browsers: 
        // Create a link pointing to the ObjectURL containing the blob.
        var data = window.URL.createObjectURL(newBlob);

        var link = document.createElement('a');
        document.body.appendChild(link); //required in FF, optional for Chrome
        link.href = data; link.target = "_blank";
        link.download = nombrePDF+ ".pdf";//este elemento hace que se descargue automaticamente si lo saco se abrira otra pagina
        link.click();
        window.URL.revokeObjectURL(data);
        link.remove(); 

    }

    function base64ToArrayBuffer(data) {
        var binaryString = window.atob(data);
        var binaryLen = binaryString.length;
        var bytes = new Uint8Array(binaryLen);
        for (var i = 0; i < binaryLen; i++) {
            var ascii = binaryString.charCodeAt(i);
            bytes[i] = ascii;
        }
        return bytes;
    }


    /* Metodos que publicamos del objeto Generales */
return {
        enlazarEnter: enlazarEnter,
        descargarPDF: descargarPDF,
    base64ToArrayBuffer: base64ToArrayBuffer,
        generarAnios:generarAnios
    }

})(window, undefined);




