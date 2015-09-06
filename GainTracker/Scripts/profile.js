/// <reference path="jquery-2.1.4.js" />

$('#add-category').click(function () {
    $.post('Profile/AddTrackedData', $('#add-tracked-form').serialize(), function (data) {
        location.reload();
    });
});

$('#add-data').click(function () {
    console.log('click');
    $.post('Profile/AddDataPoint', $('#add-data-form').serialize(), function (data) {
        location.reload();
    });
});

function setAddDataId(id) {
    $('#tracked-data-id').val(id);
}