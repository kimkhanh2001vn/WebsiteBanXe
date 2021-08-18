jQuery(document).ready(function($) {

	

	var primary_color = '#ffaa00';

	

	//Function to convert rgb format to a hex color

	function rgb2hex(rgb){

	 rgb = rgb.match(/^rgba?[\s+]?\([\s+]?(\d+)[\s+]?,[\s+]?(\d+)[\s+]?,[\s+]?(\d+)[\s+]?/i);

	 return (rgb && rgb.length === 4) ? "#" +

	  ("0" + parseInt(rgb[1],10).toString(16)).slice(-2) +

	  ("0" + parseInt(rgb[2],10).toString(16)).slice(-2) +

	  ("0" + parseInt(rgb[3],10).toString(16)).slice(-2) : '';

	}

	

	$('.color-palate .palate').click(function(){



	var thiscolor = $(this).css('background-color');

	

	primary_color = rgb2hex(thiscolor);

	primary_color = primary_color.replace("#", "");

	

    var linkcss = 'http://wp.efforttech.net/newwp/konstructo/wp-content/themes/konstructo/';



    $('link[rel*=jquery]').remove();



    $('head').append('<link rel="stylesheet jquery" href="'+linkcss+'css/color.php?main_color='+primary_color+'" type="text/css" />');



    return false;



  });



  



  if ($.cookie('boxed') == "yes") {



            $("body").addClass("boxed");



        }







  if ($.cookie('boxed') == "no") {



    $("body").removeClass("boxed");



  }



});







jQuery(document).ready(function($) {



	"use strict";



    $('.color-trigger').on('click', function () {

        $(this).parent().toggleClass('visible-palate');

    });

	

	$('.color-palate .colors-list .palate').on('click', function() {

		var newThemeColor = $(this).attr('data-theme-file');

		var targetCSSFile = $('link[id="theme-color-file"]');

	   $(targetCSSFile).attr('href',newThemeColor);

	   $('.color-palate .colors-list .palate').removeClass('active');

        $(this).addClass('active');

	});

	

	

	var layoutChangerBtn = $(".color-palate .box-version li");

	var body = $("body");

	layoutChangerBtn.on("click", function(e) {

        var $this = $(this);

        if ( $this.hasClass("box") ) {

            body.addClass("box-layout");

        } else {

        	body.removeClass("box-layout");

    	};

	});





	var directionChanger = $(".color-palate .rtl-version li");

	var wrapper = $(".page-wrapper");

	directionChanger.on("click", function(e) {

        var $this = $(this);

        if ( $this.hasClass("rtl") ) {

            wrapper.addClass("rtl-theme");

        } else {

        	wrapper.removeClass("rtl-theme");

    	};

	});

	



}(jQuery));











jQuery(document).ready(function($) {



	$(".switcher .fa-cog").click(function(e) { 



	e.preventDefault();



	$(".switcher").toggleClass("active");



	});



});