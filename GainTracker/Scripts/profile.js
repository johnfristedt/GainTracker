/// <reference path="jquery-2.1.4.js" />

$('#add-category').click(function () {
    $.post('Profile/AddTrackedData', $('#add-tracked-form').serialize(), function (data) {
        location.reload();
    });
});

$('#add-data').click(function () {
    $.post('Profile/AddDataPoint', $('#add-data-form').serialize(), function (data) {
        location.reload();
    });
});