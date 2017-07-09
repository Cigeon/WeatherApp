$(document).ready(function () {

    $('#tbCustomCity').val() = "";

    // Custom city has been changed
    $('#tbCustomCity').on("change", function () {

        // Custom city length
        var cityLength = $('#tbCustomCity').val().length;

        // Disable/enable dropdownlist if custom city selected
        if (cityLength > 0) {
            $('#ddlCity').prop("disabled", true);
        } else {
            $('#ddlCity').prop("disabled", false);
        }
    });
});