requirejs(['../common'], function (common) {
    requirejs(['jquery', 'backend', 'Modernizr', 'creadorDeGrillas', 'eval/comitesPorPeriodo', 'barramenu2', 'jquery-ui'], function ($, Backend, Modernizr, CreadorDeGrillas, ComitesPorPeriodo) {

        Backend.start(function () {
            Backend.GetAllComites().onSuccess(function (comites) {
                Backend.GetEstadosEvaluacionesPeriodosActivos().onSuccess(function (ues) {
                    Backend.GetAgentesEvaluablesParaComites().onSuccess(function (evals) {
                        Backend.GetPeriodosEvaluacion().onSuccess(function (periodos) {

                            //localStorage.setItem("estadosEvaluaciones", JSON.stringify(ues));
                            var agrupados = ComitesPorPeriodo(ues, periodos, evals, comites)
                            CreadorDeGrillas('#tabla_periodos', agrupados)

                            //activo los tooltips
                            $('[data-toggle="tooltip"]').tooltip()




                            function getPageName() {
                                var
                                    pathName = window.location.pathname,
                                    pageName = "";
                                if (pathName.indexOf("/") != -1) {
                                    pageName = pathName.split("/").pop();
                                } else {
                                    pageName = pathName;
                                }
                                return pageName;
                            }


                            function navigateToPage() {
                                var pageName = getPageName();
                                //$.get(pageName, function (response) {

                                    $('[role="tabpanel"]').hide()
                                    $(pageName).show()

                                    /*var
                                        markup = $("<div>" + response + "</div>"),
                                        fragment = markup.find(".fragment").html();*/
                                    //$("#content-host").html(fragment);
                                //});
                            }

                            $('[target_scr]').click(function (e) {
                                if (Modernizr.history) {
                                    e.preventDefault();
                                    //var pageName = $(this).attr("href");
                                    var pageName = this.attributes.target_scr.value
                                    window.history.pushState(null, "", pageName);
                                    navigateToPage(pageName);
                                }
                            });


                            $(window).on('popstate', function (e) {

                                this._popStateEventCount++;

                                if (this._popStateEventCount == 1) {
                                    return;
                                }

                                navigateToPage();
                            });







                            /*
                            //agrego el handler de los componentes que cambian de pantalla
                            $('[target_scr]').click(function () {

                                var pantalla = this.attributes.target_scr.value
                                mostrarPantalla(pantalla);
                            })

                            var mostrarPantalla = function (pantalla) {
                                $('[role="tabpanel"]').hide()
                                $(pantalla).show()
                            }
                            */
                        })
                    })
                })
            })
        })
    })
})
