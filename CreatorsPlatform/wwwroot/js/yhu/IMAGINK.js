window.addEventListener('load', function () {
    var myCarousel = document.querySelector('#SmallTourCarousel');
    var carousel = new bootstrap.Carousel(myCarousel, {
        interval: false,
    });
});