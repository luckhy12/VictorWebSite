
	/* CUSTOMIZER 
	======================================== */

	$(document).ready(function(){

		$customizerBlock = '<div class="customizer open">' + 
								'<span class="after-icon">' + 
									'<i class="icon fa fa-cog"></i>' + 
								'</span>' + 
								'<h2>Theme Color</h2>' + 
								'<div data-color="1FB7A6" style="background-color: #1FB7A6" class="color active"></div>' + 
								'<div data-color="1ABC9C" style="background-color: #1ABC9C" class="color"></div>' + 
								'<div data-color="2C3E50" style="background-color: #2C3E50" class="color"></div>' + 
								'<div data-color="2ECC71" style="background-color: #2ECC71" class="color"></div>' + 
								'<div data-color="7F8C8D" style="background-color: #7F8C8D" class="color"></div>' + 
								'<div data-color="8E44AD" style="background-color: #8E44AD" class="color"></div>' + 
								'<div data-color="9B59B6" style="background-color: #9B59B6" class="color"></div>' + 
								'<div data-color="16A085" style="background-color: #16A085" class="color"></div>' + 
								'<div data-color="27AE60" style="background-color: #27AE60" class="color"></div>' + 
								'<div data-color="50C8B4" style="background-color: #50C8B4" class="color"></div>' + 
								'<div data-color="2980B9" style="background-color: #2980B9" class="color"></div>' + 
								'<div data-color="3498DB" style="background-color: #3498DB" class="color"></div>' + 
								'<div data-color="34495E" style="background-color: #34495E" class="color"></div>' + 
								'<div data-color="687475" style="background-color: #687475" class="color"></div>' + 
								'<div data-color="C0392B" style="background-color: #C0392B" class="color"></div>' + 
								'<div data-color="D35400" style="background-color: #D35400" class="color"></div>' + 
								'<div data-color="E67E22" style="background-color: #E67E22" class="color"></div>' + 
								'<div data-color="E74C3C" style="background-color: #E74C3C" class="color"></div>' + 
								'<div data-color="F1C40F" style="background-color: #F1C40F" class="color"></div>' + 
								'<div data-color="F39C12" style="background-color: #F39C12" class="color"></div>' + 
								'<div class="clear"></div>' + 
								'<h2>Header Background</h2>' + 
								'<div data-bg="skyline" class="texture skyline active" style="background-image: url(images/sample/texture/skyline.png)"></div>' +
								'<div id="bg-container-clean">' +
									'<div data-bg="texture-1" class="texture" style="background-image: url(images/sample/texture/texture-1.png)"></div>' + 
									'<div data-bg="texture-2" class="texture" style="background-image: url(images/sample/texture/texture-2.png)"></div>' + 
									'<div data-bg="texture-3" class="texture" style="background-image: url(images/sample/texture/texture-3.png)"></div>' + 
									'<div data-bg="texture-4" class="texture" style="background-image: url(images/sample/texture/texture-4.png)"></div>' + 
									'<div data-bg="texture-5" class="texture" style="background-image: url(images/sample/texture/texture-5.png)"></div>' + 
									'<div data-bg="texture-6" class="texture" style="background-image: url(images/sample/texture/texture-6.png)"></div>' +  
									'<div class="clear"></div>' + 
								'</div>' +
								'<div id="bg-container-dark">' +
									'<div data-bg="texture-1-dark" class="texture nb" style="background-image: url(images/sample/texture/texture-1-dark.png)"></div>' + 
									'<div data-bg="texture-2-dark" class="texture nb" style="background-image: url(images/sample/texture/texture-2-dark.png)"></div>' + 
									'<div data-bg="texture-3-dark" class="texture nb" style="background-image: url(images/sample/texture/texture-3-dark.png)"></div>' + 
									'<div data-bg="texture-4-dark" class="texture nb" style="background-image: url(images/sample/texture/texture-4-dark.png)"></div>' + 
									'<div data-bg="texture-5-dark" class="texture nb" style="background-image: url(images/sample/texture/texture-5-dark.png)"></div>' + 
									'<div data-bg="texture-6-dark" class="texture nb" style="background-image: url(images/sample/texture/texture-6-dark.png)"></div>' + 
									'<div class="clear"></div>' + 
								'</div>' +
								'<h2>Clean | Dark Version</h2>' +
								'<div data-type="dark" style="background-color: #333" class="version-type dark"></div>' +
								'<div data-type="clean" style="background-color: #FFF" class="version-type clean active"></div>' +
								'<div class="clear"></div>' + 
							'</div>';

		$('body').append($customizerBlock);

		setTimeout(function() {
			$('.customizer').removeClass('open');
		}, 6000);

		$('.customizer .color', document.body).on('click', function(){
			$('.customizer .color', document.body).removeClass('active');
			$this = $(this);
			$this.addClass('active');
			$color = $this.data('color');
			$("#color-set", document.head).length ? $('#color-set', document.head).attr({'href':'css/template/color/' + $color + '.css'}) 
												  : $(document.head).append('<link id="color-set" rel="stylesheet" href="css/template/color/' + $color + '.css">') ;
		});

		$('.customizer .version-type', document.body).on('click', function(){
			$('.customizer .version-type', document.body).removeClass('active');
			$this = $(this);
			$this.addClass('active');
			$type = $this.data('type');
			var logo = $('#logo-header');

			if($type=='dark') {
				if($("#type-set", document.head).length==false) {
					$(document.head).append('<link id="type-set" rel="stylesheet" href="css/template/color/DARK.css">');
					$('.customizer').addClass('dark');
					$('#bg-container-clean').css({'display':'none'});
					$('#bg-container-dark').css({'display':'block'});
					logo.attr('src', logo.attr('src').replace(".png", "-light.png"));
				}
			} else {
				$('.customizer').removeClass('dark');
				$('#type-set', document.head).remove();
				$('#bg-container-clean').css({'display':'block'});
				$('#bg-container-dark').css({'display':'none'});
				$('.cover', '#header-page').attr('style', '');
				logo.attr('src', logo.attr('src').replace("-light.png", ".png"));
			}
		});

		$('.customizer .texture', document.body).on('click', function(){
			$('.customizer .texture', document.body).removeClass('active');
			$this = $(this);
			$this.addClass('active');
			$texture = $this.data('bg');
			if($texture=='skyline'){
				$('.cover', '#header-page').attr('style', '');
			} else{
				$('.cover', '#header-page').css({'background-image':'url(images/sample/texture/' + $texture + '.png)'});

			}
		});

		$('.customizer .after-icon').on('click', function(){
			$(this).parent().toggleClass('open');
		});

		$('head').append('');

	});

	/* Remove loading div  -------------------------------------------------------------- */
	$(document).ready(function() {
        $(".loading-content").delay(3000).fadeOut(function(){
			$('body').css({'overflow': 'auto'})
					 .css({'overflow-x': 'hidden'});
			$(this).remove();
		})
	});