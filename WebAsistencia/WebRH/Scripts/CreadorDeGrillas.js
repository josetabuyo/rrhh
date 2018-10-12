define(['jquery', 'underscore'], function ($, _) {


    function tableRowFrom(model, row_template) {
        row = row_template.clone()
        row.removeClass('row-template')
        row.show()

        _.each(model, function (attr_value, attr_name) {
            tds = _.filter(row.find('td'), function (td) {
                return td.innerHTML.includes('{{' + attr_name + '}}')
            })

            _.each(tds, function (td) {
                td.innerHTML = td.innerHTML.replace('{{' + attr_name + '}}', attr_value)
            })
        })
       
        return row
    }


    /*
     * Esta funcion recibe
     * id: el selector de jquery para obtener la tabla del html (e.g. #tablaPersonas)
     * registros: un array de objetos del modelo que se quieren cargar en la grilla (e.g. [ { nombre: 'juan', apellido: 'perez'}, 
     *                                                                                      { nombre: 'pedro', apellido: 'mendez'}])
     *
     * la tabla html (cuyo id, es recibido por parametro) debe ser declarada en el .html con 
     * especificando un template de row (señalado con class="row-template"), y luego
     * entre dobles llaves {{ }}, se especifican los atributos del modelo a ser mostrados (e. g. {{nombre}})
     * como en el siguiente ejemplo
     * <table>
     *  <thead>
     *      <th>Nombre de la persona</th>
     *      <th>Apellido de la persona</th>
     *  </thead>
     *  <tbody>
     *      <tr class="row-template">
     *          <td> {{nombre}} </td>
     *          <td> {{apellido}} </td>
     *      </tr>
     *  </tbody>
     * </table>
    */
    function GrillaFrom(id, registros) {
        var body = $(id + ' > tbody')
        
        var row_template = body.find('.row-template')

        //borro los registros
        body.empty()
        //pero salvaguardo el template
        body.append(row_template)

        _.each(registros, function (each) {
            body.append(tableRowFrom(each, row_template))
        })
        
        $(id).append(body)
    }

    return GrillaFrom;

})