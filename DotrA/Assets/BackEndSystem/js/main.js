$(document).ready(function(e) {

	"use strict";

	[].slice.call( document.querySelectorAll( 'select.cs-select' ) ).forEach( function(el) {
		new SelectFx(el);
	});

	e('.selectpicker').selectpicker;


	

	e('.search-trigger').on('click', function(event) {
		event.preventDefault();
		event.stopPropagation();
		e('.search-trigger').parent('.header-left').addClass('open');
	});

	e('.search-close').on('click', function(event) {
		event.preventDefault();
		event.stopPropagation();
		e('.search-trigger').parent('.header-left').removeClass('open');
	});

	e('.equal-height').matchHeight({
		property: 'max-height'
	});

	// var chartsheight = $('.flotRealtime2').height();
	// $('.traffic-chart').css('height', chartsheight-122);


	// Counter Number
	e('.count').each(function () {
		e(this).prop('Counter',0).animate({
			Counter: e(this).text()
		}, {
			duration: 3000,
			easing: 'swing',
			step: function (now) {
				e(this).text(Math.ceil(now));
			}
		});
	});


	 
	 
	// Menu Trigger
	e('#menuToggle').on('click', function(event) {
		var windowWidth = e(window).width();   		 
		if (windowWidth<1010) { 
			e('body').removeClass('open'); 
			if (windowWidth<760){ 
				e('#left-panel').slideToggle(); 
			} else {
				e('#left-panel').toggleClass('open-menu');  
			} 
		} else {
			e('body').toggleClass('open');
			e('#left-panel').removeClass('open-menu');  
		} 
			 
	}); 

	 
	//$(".menu-item-has-children.dropdown").each(function() {
	//	$(this).on('click', function() {
	//		var $temp_text = $(this).children('.dropdown-toggle').html();
	//		$(this).children('.sub-menu').prepend('<li class="subtitle">' + $temp_text + '</li>'); 
	//	});
	//});


	// Load Resize 
	e(window).on("load resize", function(event) { 
		var windowWidth = e(window).width();  		 
		if (windowWidth<1010) {
			e('body').addClass('small-device'); 
		} else {
			e('body').removeClass('small-device');  
		}
	});
});