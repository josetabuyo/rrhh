var PantallaEtapaDeTableroControl = {

    InicializarPantalla: function (tablero) {
     var _this = this;
     _this.tablero = tablero;
     _this.DibujarTabla(tablero);
    },

    DibujarTabla: function (tablero) {
        var _this = this;
        $("#tabla_postulaciones").empty();
        var divGrilla = $('#tabla_postulaciones');

        var columnas = [];
        //columnas.push(new Columna("Perfil", { generar: function (un_tablero) { return un_tablero.IdPerfil } }));
        columnas.push(new Columna("DescDePerfil", { generar: function (un_tablero) { return un_tablero.DescripcionPerfil } }));
        columnas.push(new Columna("Comite", { generar: function (un_tablero) { return un_tablero.NumeroComite } }));
        columnas.push(new Columna("A. Postulados", { generar: function (un_tablero) { return un_tablero.Postulados } }));
        columnas.push(new Columna("B. Inscriptos", { generar: function (un_tablero) { return un_tablero.Inscriptos } }));

        this.GrillaDePostulaciones = new Grilla(columnas);
        this.GrillaDePostulaciones.AgregarEstilo("cuerpo_tabla_perfil tr td");
        this.GrillaDePostulaciones.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDePostulaciones.SetOnRowClickEventHandler(function (un_tablero) { });


        this.GrillaDePostulaciones.CargarObjetos(tablero);
        this.GrillaDePostulaciones.DibujarEn(divGrilla);
        _this.BuscadorDeTabla();
        $("#btn_generar_anexo").attr("style", "display:inline");
       
    },

    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['DescDePerfil']
        };

        var featureList = new List('contenedorTabla', options);
    },



    FiltrarPorComite: function () {
        var tablero = this.tablero;
        var tablero_filtrado =  [];
        var comite = $('#filtrar_comite').val();
        if (comite === "") {
            tablero_filtrado = tablero;
        } else {
            for (var i = 0; i < tablero.length; i++) {
                if (tablero[i].NumeroComite == comite) {
                    tablero_filtrado.push(tablero[i]);
                };
            };
        };
        this.DibujarTabla(tablero_filtrado);
    },

    fnExcelReport: function () {
        var tab_text = "<table border='2px'><tr bgcolor='#94D6FC'>";
        var textRange; var j=0;
        tab = document.getElementById('tabla_postulaciones'); // id of table

        for (j = 0; j < tab.children[0].rows.length; j++) 
        {
            tab_text = tab_text + tab.children[0].rows[j].innerHTML + "</tr>";
        }

        tab_text=tab_text+"</table>";
        tab_text= tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
        tab_text= tab_text.replace(/<img[^>]*>/gi,""); // remove if u want images in your table
        tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params


        var ua = window.navigator.userAgent;
        var msie = ua.indexOf("MSIE "); 

        if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
        {
            txtArea1.document.open("txt/html","replace");
            txtArea1.document.write(tab_text);
            txtArea1.document.close();
            txtArea1.focus(); 
            sa=txtArea1.document.execCommand("SaveAs",true,"Say Thanks to Sumit.xls");
        }  
        else                 //other browser not tested on IE 11
            sa = window.open('data:application/vnd.ms-excel;base64,' + this.base64_encode(tab_text));

        return (sa);
    },

    base64_encode: function (data) {
          var b64 = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
          var o1, o2, o3, h1, h2, h3, h4, bits, i = 0,
            ac = 0,
            enc = '',
            tmp_arr = [];

          if (!data) {
            return data;
          }

          do { // pack three octets into four hexets
            o1 = data.charCodeAt(i++);
            o2 = data.charCodeAt(i++);
            o3 = data.charCodeAt(i++);

            bits = o1 << 16 | o2 << 8 | o3;

            h1 = bits >> 18 & 0x3f;
            h2 = bits >> 12 & 0x3f;
            h3 = bits >> 6 & 0x3f;
            h4 = bits & 0x3f;

            // use hexets to index into b64, and append result to encoded string
            tmp_arr[ac++] = b64.charAt(h1) + b64.charAt(h2) + b64.charAt(h3) + b64.charAt(h4);
          } while (i < data.length);

          enc = tmp_arr.join('');

          var r = data.length % 3;

          return (r ? enc.slice(0, r - 3) : enc) + '==='.slice(r || 3);
    }


}


