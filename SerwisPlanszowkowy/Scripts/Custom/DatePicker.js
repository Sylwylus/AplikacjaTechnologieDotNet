$(document).ready(function () {

    $("#StartDate").datepicker({
        dateFormat: 'dd-mm-yy',
        minDate: 0,
        maxDate: 365,
        onSelect: function (selected) {
            $("#EndDate").datepicker("option", "minDate", selected)
        }
    });
    $("#EndDate").datepicker({
        dateFormat: 'dd-mm-yy',
        minDate: 0,
        maxDate: 365,
    });
    $(".datepicker").keypress(function (event) { event.preventDefault(); });

})