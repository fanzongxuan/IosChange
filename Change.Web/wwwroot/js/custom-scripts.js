(function ($) {
    "use strict";
    var mainApp = {

        initFunction: function () {
            /*MENU 
            ------------------------------------*/
            $('#main-menu').metisMenu();

            $(window).bind("load resize", function () {
                if ($(".top-navbar")[0].scrollWidth <764) {                  
                    $('div.sidebar-collapse').addClass('collapse')
                } else {
                    $('div.sidebar-collapse').removeClass('collapse')
                }
            });
        },

        initialization: function () {
            mainApp.initFunction();

        }

    }

    $(document).ready(function () {
        mainApp.initFunction();
        $("#sideNav").click(function () {
            if ($(this).hasClass('closed')) {
                $('.navbar-side').animate({ left: '0px' });
                $(this).removeClass('closed');
                $('#page-wrapper').animate({ 'margin-left': '260px' });

            }
            else {
                $(this).addClass('closed');
                $('.navbar-side').animate({ left: '-260px' });
                $('#page-wrapper').animate({ 'margin-left': '0px' });
            }
        });

        $("#main-menu").find("li").click(function () {
            if ($(this).find('ul').length) {
                return;
            }
            $(this).find("a").addClass('active-menu');
        });
    });

}(jQuery));
