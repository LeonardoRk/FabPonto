$(document).ready(function() {
    $(".login").click(function() {
        show_modal();
    });
    $("button[type=submit]").click(function () {
        $(this).attr("data-dismiss", "modal");
        hide_modal();
    });

    function hide_modal() {
        $("#login-modal").modal('toogle');
    }
    function show_modal() {
        $("#login-modal").modal('show');
    }
});
