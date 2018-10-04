define(['jquery', 'underscore'], function ($, _) {


    function tableRowFrom(model, row_template) {
        row = row_template.clone()

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

    function GrillaFrom(id, registros, options) {
        var body = $(id + ' > tbody')

        var row_template = body.find('.row-template')
        row_template.removeClass('row-template')

        _.each(registros, function (each) {
            body.append(tableRowFrom(each, row_template))
        })
        row_template.hide();
        $(id).append(body)
    }

    return GrillaFrom;

})