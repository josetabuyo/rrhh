var InscripcionManual = {
    iniciar: function () {
        var _this = this;
        Perfil.traerPerfiles();

        $('#text_fecha_inscripcion').datepicker();
        $('#text_fecha_inscripcion').datepicker('option', 'dateFormat', 'dd/mm/yy');

        var provincias = Backend.sync.BuscarProvincias('{}');

        var modalidadesDeInscripcion = Backend.sync.BuscarModalidadDeInscripcion('{}');

        $.each(provincias, function () {
            $('.cmb_provincia').append('<option value="' + this.Id + '">' + this.Nombre + '</option>');
        });

        var localidades = Backend.sync.BuscarLocalidades('{IdProvincia:0}');
        $.each(localidades, function () {
            $('.cmb_localidad').append('<option value="' + this.Id + '">' + this.Nombre + '</option>');
        });

        $.each(modalidadesDeInscripcion, function () {
            $('#combo_modalidad').append('<option value="' + this.Id + '">' + this.Descripcion + '</option>');
        });

        $('#cmb_provincia_personal').change(function () {
            var localidades = Backend.sync.BuscarLocalidades('{IdProvincia: ' + this.selectedIndex + '}');
            $('#cmb_localidad_personal').empty();
            $.each(localidades, function () {
                $('#cmb_localidad_personal').append('<option value=' + this.Id + '>' + this.Nombre + '</option>');
            });
        });

        $('#cmb_provincia_legal').change(function () {
            var localidades = Backend.sync.BuscarLocalidades('{IdProvincia: ' + this.selectedIndex + '}');
            $('#cmb_localidad_legal').empty();
            $.each(localidades, function () {
                $('#cmb_localidad_legal').append('<option value=' + this.Id + '>' + this.Nombre + '</option>');
            });
        });

        $('#btn_inscripcion_manual').click(function () {

            if (validar()) {

                if (!validateEmail($('#text_mail').val())) {
                    alertify.error('Formato del mail invalido.');
                    return false;
                }

                if ($('#informeGrafico_00').val() == '') {
                    alertify.alert("", 'Debe ingresar al menos 1 número de INFORME GRÁFICO');
                    return;
                }


                //var anonimoPerfil = {};
                //anonimoPerfil.Id = $('#combo_perfiles').val();

                var postulacionManual = {};
                postulacionManual.Perfil = $('#combo_perfiles').val();
                postulacionManual.FechaInscripcion = $('#text_fecha_inscripcion').val();
                postulacionManual.DNIInscriptor = $('#text_dni_inscriptor').val();
                postulacionManual.Modalidad = $('#combo_modalidad').val();

                var inputs = $('.informesGraficos');
                var informes = [];
                var textoConcatenado = "";

                $.each(inputs, function (key, value) {
                    if (value.value != '') {
                        informes.push(value.value);
                        textoConcatenado += value.value + ', ';
                    }
                });

                postulacionManual.NumerosDeInformeGDE = informes;


                var datosPersonales = {};
                //var DomicilioPersonal = {};
                //var DomicilioLegal = {};


                datosPersonales.Nombre = $('#text_nombre').val();
                datosPersonales.Apellido = $('#text_apellido').val();
                datosPersonales.DNI = $('#text_dni').val();

                datosPersonales.DomicilioCallePersonal = $('#text_domicilio_calle_personal').val();
                datosPersonales.DomicilioNroPersonal = $('#text_domicilio_nro_personal').val();
                datosPersonales.DomicilioPisoPersonal = $('#text_domicilio_piso_personal').val();
                datosPersonales.DomicilioDeptoPersonal = $('#text_domicilio_depto_personal').val();
                datosPersonales.DomicilioCpPersonal = $('#text_domicilio_cp_personal').val();
                datosPersonales.DomicilioProvinciaPersonal = $('#cmb_provincia_personal').val();
                datosPersonales.DomicilioLocalidadPersonal = $('#cmb_localidad_personal').val();

                datosPersonales.DomicilioCalleLegal = $('#text_domicilio_calle_legal').val();
                datosPersonales.DomicilioNroLegal = $('#text_domicilio_nro_legal').val();
                datosPersonales.DomicilioPisoLegal = $('#text_domicilio_piso_legal').val();
                datosPersonales.DomicilioDeptoLegal = $('#text_domicilio_depto_legal').val();
                datosPersonales.DomicilioCpLegal = $('#text_domicilio_cp_legal').val();
                datosPersonales.DomicilioProvinciaLegal = $('#cmb_provincia_legal').val();
                datosPersonales.DomicilioLocalidadLegal = $('#cmb_localidad_personal').val();

                datosPersonales.Telefono = $('#text_telefono').val();
                datosPersonales.Mail = $('#text_mail').val();

                var folio = {};
                folio.FichaInscripcion = $('#text_folio_ficha_inscripcion').val();
                folio.FotografiaCarnet = $('#text_folio_foto_carnet').val();
                folio.FotocopiaDNI = $('#text_folio_dni').val();
                folio.Titulo = $('#text_folio_titulo').val();
                folio.CV = $('#text_folio_cv').val();
                folio.DocumentacionRespaldo = $('#text_folio_respaldo').val();

                var postulacionJSON = JSON.stringify(postulacionManual);
                var datosPersonalesJSON = JSON.stringify(datosPersonales);
                var folioJSON = JSON.stringify(folio);

                var nroPostulacion = Backend.sync.GuardarPostulacionManual({ postulacion: postulacionManual }, { datosPersonales: datosPersonales }, { folio: folio });
                    $('#numero_postulacion').html(nroPostulacion);
                    alertify.alert("", 'Se ha inscripto correctamente. El número de postulación es: ' + nroPostulacion);
                    PrintElem();  
                }
        });

        function validar() {
            var resultado = true;
            $('.validarTexto').each(function () {
                if (this.textContent == '') {
                    alertify.error('Complete ' + this.previousElementSibling.textContent);
                    resultado = false;
                }
            });

            $('.validar').each(function () {
                if (this.value == '') {
                    alertify.error('Complete ' + this.parentNode.previousElementSibling.textContent);
                    resultado = false;
                }
            });

            $('.validarNumero').each(function () {
                if (isNaN(this.value) || this.value == '') {
                    alertify.error('El folio de ' + this.parentNode.previousElementSibling.textContent + ' debe ser un número.');
                    resultado = false;
                }
            });

            $('.validarPie').each(function () {
                if (this.value == '') {
                    alertify.error('Complete ' + this.parentNode.textContent);
                    resultado = false;
                }
            });

            return resultado;
        }

        function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }
       
    }
}


