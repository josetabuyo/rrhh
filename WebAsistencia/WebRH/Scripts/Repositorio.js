var Repositorio = {
    buscar: function (nombre_repositorio, criterio, success, error) {
        if (!criterio) criterio = {};
        Backend.ejecutar("Buscar" + nombre_repositorio, [criterio], success, error);
    }
};