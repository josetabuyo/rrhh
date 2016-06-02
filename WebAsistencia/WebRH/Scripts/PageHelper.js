var PageHelper = {
    deshabilitarInput: function () {
        this.overlay = $("<div id='overlay_helper' style='position: absolute; left: 0px; right:0px; top:0px; bottom: 0px;'>");
        $("html").append(this.overlay);
    },
    habilitarInput: function () {
        this.overlay.remove();
    }
};