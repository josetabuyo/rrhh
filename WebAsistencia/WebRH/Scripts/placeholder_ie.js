jQuery(document).ready(function () {
    $('[nullValue]').each(function () {
        HandlePlaceholder($(this));
    });

    var _placeholderSupport = function () {
        var t = document.createElement("input");
        t.type = "text";
        return (typeof t.placeholder !== "undefined");
    };

    function HandlePlaceholder(input) {

        var label = $("<div>" + input.attr("nullValue") + "</div>");

        label.css('position', 'absolute');
        label.css('top', '0px');
        label.css('left', "0px");
        label.css('z-index', 5);
        label.css('cursor', 'text');
        label.css('margin-right', 'auto');
        label.css('text-align', 'left');
        label.css('color', '#666');
        label.css('background-color', 'transparent');
        label.css('margin-top', '6px');
        label.css('white-space', 'nowrap');
        label.css('pointer-events', 'none');
        label.css('width', '0px');

        var marginStrPx = input.css('margin-left');
        var marginStr = marginStrPx.replace('px', '');
        marginInt = parseInt(marginStr, 10);

        label.css('margin-left', (9 + marginInt).toString() + 'px');

        var contenedor = $('<div>');
        contenedor.css('position', 'relative');
        contenedor.css('display', input.css('display'));
        contenedor.css('width', input.css('width'));

        input.css('width', '97%');

        input.wrap(contenedor);
        input.after(label);

        if (!(input.val() === "")) label.hide();

        input.focus(function () {
            label.hide();
        });

        label.click(function () {
            label.hide();
            input.focus();
        });

        input.blur(function () {
            if (input.val() === "") label.show();
        });
    }
});

//PlaceHolders IE
var arrInputs = document.getElementsByTagName("input");
for (i = 0; i < arrInputs.length; i++) {
    var curInput = arrInputs[i];
    if (!curInput.type || curInput.type == "" || curInput.type == "text")
        HandlePlaceholder(curInput);
}

var arrTextArea = document.getElementsByTagName("textarea");
for (i = 0; i < arrTextArea.length; i++) {
    var curTextArea = arrTextArea[i];
    HandlePlaceholder(curTextArea);
}

var _placeholderSupport = function () {
    var t = document.createElement("input");
    t.type = "text";
    return (typeof t.placeholder !== "undefined");
};

function HandlePlaceholder(oTextbox) {
    if (!_placeholderSupport) {
        var curPlaceholder = oTextbox.getAttribute("placeholder");
        if (curPlaceholder && curPlaceholder.length > 0) {
            oTextbox.value = curPlaceholder;
            oTextbox.setAttribute("old_color", oTextbox.style.color);
            oTextbox.style.color = "#c0c0c0";
            oTextbox.onfocus = function () {
                this.style.color = this.getAttribute("old_color");
                if (this.value === curPlaceholder)
                    this.value = "";
            };
            oTextbox.onblur = function () {
                if (this.value === "") {
                    this.style.color = "#c0c0c0";
                    this.value = curPlaceholder;
                }
            };
        }
    }
}