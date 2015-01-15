// JavaScript Document

$2(document) .ready(function() {
	
	$2('#slideshow') .css("overflow","hidden");
	$2("ul#slides") .cycle ({
		fx: 'fade',
		pause: 1,
		prev: '#prev',
		next: '#next',
		speed: 1000,
		timeout: 4000,
		
	});
	
	$2("#slideshow") .hover(function(){
		$2("ul#nav") .fadeIn();
		
	},
	
	function(){
		$2("ul#nav") .fadeOut();
		
	});
    
});

