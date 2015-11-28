$(document).ready(function(){
	
	// Click function to open Lightbox and hide Click button 
	$('.trigger-button').click(function(){
		$('.lightbox').css('display', 'block');
		$('.close-button').css('display', 'block');
		$(this).css('display', 'none');
	});
	
	// Click function to hide Lightbox and hide Close button
	$('.close-button').click(function(){
		$(this).css('display', 'none');
		$('.lightbox').css('display', 'none');
		$('.trigger-button').css('display', 'block');
	});

});