(function($){
    $(function(){


        // Owl Carousel
        if($.fn.owlCarousel){
            $('.owl-carousel').owlCarousel({
                singleItem: true,
                autoPlay: true,
                stopOnHover: true,
                navigation: true,
                navigationText: ["<i class='fa fa-chevron-left'></i>","<i class='fa fa-chevron-right'></i>"],
                pagination: false,
                autoHeight: true
            });
        };


        // Floating Labels
        $('.control-alt .form-control').on('keyup change', function (e) {
            var input = $(e.currentTarget);

            if ($.trim(input.val()) !== '') {
                input.addClass('filled');
            } else {
                input.removeClass('filled');
            }
        });
        $('.control-alt .form-control').each(function () {
            var input = $(this);

            if ($.trim(input.val()) !== '') {
                input.addClass('filled');
            }
        });


        // Slideup Button
        $('.slide-toggle').on('click', function(){
            $(this).parent().toggleClass('open');
        });


        // Hide Announcements
        $('#announcements .btn-close').on('click', function(e){
            $(this).parent().fadeOut(300);
            e.preventDefault();
        });


    });
})(jQuery);