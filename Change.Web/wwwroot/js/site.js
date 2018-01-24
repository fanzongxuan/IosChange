// Write your JavaScript code.
$(".select2").select2({
    language: "zh-CN",
    theme: "flat"
});

$('.selecttime').datetimepicker({
    format: 'YYYY-MM-DD HH:mm',
    locale: moment.locale('zh-cn')
});

$(".enter-search").keypress(function (e) {
    var keyCode = e.keyCode ? e.keyCode : e.which ? e.which : e.charCode;
    if (keyCode == 13) {
        try {
            $table.bootstrapTable('refreshOptions', { pageNumber: 1 });
        } catch (e) {
            return false;
        }
    }
});

//$(function () {
//    var active_menu = GetQueryString("active_menu")
//    var active_a = $("[href$='active_menu=" + active_menu + "']");
//    $(active_a).addClass('active-menu')
//    var closeUl = $(active_a).closest('ul');
//    if (closeUl.hasClass('nav-second-level')) {
//        closeUl.addClass('in')
//        closeUl.attr("aria-expanded", true)
//        closeUl.removeAttr("style")
//        closeUl.closest('li').addClass('active')
//    }
//})
