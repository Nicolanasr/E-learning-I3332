$(document).ready(() => {
    // sidebar control
    $("#sidebarCollapse").click(() => {
        $("#sidebar").toggleClass("-ml-80");
    });

    // form validation
    $(".validateForm").validate();
});
