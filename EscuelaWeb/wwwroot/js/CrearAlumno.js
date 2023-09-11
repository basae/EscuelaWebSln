$(function () {
    $("#Genero").change(function () {
        if ($(this).val() == "1") {
            $("#frmCrearAlumno label").removeClass("femenino");
            $("#frmCrearAlumno label").addClass("masculino");
        }
        else {
            $("#frmCrearAlumno label").removeClass("masculino");
            $("#frmCrearAlumno label").addClass("femenino");
        }
    });
    $("#frmCrearAlumno").submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/Alumno/Create",
            method: "POST",
            data: $("#frmCrearAlumno").serialize(),
            beforeSend: function () {
                alert($("#frmCrearAlumno").serialize());
            },
            success: function (response) {                
                alert(response)
            },
            error: function (e) {
                alert("ocurrio un error" + e.responseText);
            }
        });
    });
});