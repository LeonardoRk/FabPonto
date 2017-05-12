$(document).ready(function() {

    var $formLogin = $('#login-form');
    var $formRegister = $('#register-form');
    var $divForms = $('#div-forms');
    var $modalAnimateTime = 300;

    $(".login").click(function() {
        showModal();
    });

    function registerUrl() {
        var $locationUrlRegister = "http://localhost:5001/User/Register";
        var $locationUrlLogin = "http://localhost:5001/Login";
        if (($locationUrlRegister.localeCompare(window.location.href) === 0) || ($locationUrlLogin.localeCompare(window.location.href) === 0)) {
            showModal();
        }
    }
    registerUrl();

    function showModal() {
        $("#login-modal").modal('show');
    }

    $('#login_register_btn').click( function() {

        modalAnimate($formLogin, $formRegister);
    });

    $('#register_login_btn').click( function() {
         modalAnimate($formRegister, $formLogin);
    });

    function modalAnimate ($oldForm, $newForm) {
        var $oldH = $oldForm.height();
        var $newH = $newForm.height();
        $divForms.css("height",$oldH);
        $oldForm.fadeOut($modalAnimateTime, function(){
            $divForms.animate({height: $newH}, $modalAnimateTime, function(){
                $newForm.fadeIn($modalAnimateTime);
            });
        });
    }
});