/// <reference path="jquery-2.1.3.js" />


var m = $('.sidebar-collapse');

for (var i = 0; i < m.length; i++) {
    var visible = localStorage.getItem('sidebar-collapse-' + i);
    if (visible == 'true') {
        $(m[i]).show();
    }
    else if (visible == 'false') {
        $(m[i]).hide();
    }

    localStorage.setItem('sidebar-collapse-' + i, null);
}

$('.control-toggle').click(function (e) {
    e.preventDefault();
    $(this).children('.dropdown-arrow').toggleClass('dropdown-arrow-open');
    $($(this).attr('data-target')).slideToggle('fast');
});

$('.sidebar-toggle').click(function (e) {
    e.preventDefault();
    $(this).children('.dropdown-arrow').toggleClass('dropdown-arrow-open');
    $($(this).attr('data-target')).toggle('fast');
});

$('.sidebar-link').click(function (e) {
    var menus = $('.sidebar-collapse');

    for (var i = 0; i < menus.length; i++) {
        console.log('sidebar-collapse-' + i);
        localStorage.setItem('sidebar-collapse-' + i, ($(menus[i]).is(':visible')));
    }

    //console.log(menus);


});