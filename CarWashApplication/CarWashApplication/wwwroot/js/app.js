/* Section 1 Slider automatic */

let slideIndex = 0;
showSlides();

function showSlides() {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    let dots = document.getElementsByClassName("dot");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
    setTimeout(showSlides, 7000);
}


/* Section 6 slider Div*/

const container1 = document.querySelector('.section6-slider-1');
document.querySelector('.slider1').addEventListener('input', (e) => {
    container1.style.setProperty('--position', `${e.target.value}%`);
})
const container2 = document.querySelector('.section6-slider-2');
document.querySelector('.slider2').addEventListener('input', (e) => {
    container2.style.setProperty('--position', `${e.target.value}%`);
})
const container3 = document.querySelector('.section6-slider-3');
document.querySelector('.slider3').addEventListener('input', (e) => {
    container3.style.setProperty('--position', `${e.target.value}%`);
})
const container4 = document.querySelector('.section6-slider-4');
document.querySelector('.slider4').addEventListener('input', (e) => {
    container4.style.setProperty('--position', `${e.target.value}%`);
})

/* Section 7 Counter */

$.fn.jQuerySimpleCounter = function (options) {
    var settings = $.extend({
        start: 0,
        end: 100,
        easing: 'swing',
        duration: 400,
        complete: ''
    }, options);

    var thisElement = $(this);

    $({ count: settings.start }).animate({ count: settings.end }, {
        duration: settings.duration,
        easing: settings.easing,
        step: function () {
            var mathCount = Math.ceil(this.count);
            thisElement.text(mathCount);
        },
        complete: settings.complete
    });
};


$('#number1').jQuerySimpleCounter({ end: 11035, duration: 300000 });
$('#number2').jQuerySimpleCounter({ end: 12361, duration: 300000 });
$('#number3').jQuerySimpleCounter({ end: 10273, duration: 300000 });
$('#number4').jQuerySimpleCounter({ end: 3748, duration: 300000 });


