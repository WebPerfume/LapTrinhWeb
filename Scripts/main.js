//Open-Close Message button form
const openFormButton = document.querySelector('.open-button');
const closeFormButton = document.querySelector('.chat-popup .btn.cancel');
const myForm = document.getElementById("myForm")

openFormButton.addEventListener('click', (e) => {
    myForm.style.display = "block";
})

closeFormButton.addEventListener('click', () => {
    myForm.style.display = "none";
})




//Get the button Back to Top
var mybutton = document.getElementById("myBtn");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () {
    if (
        document.body.scrollTop > 20 ||
        document.documentElement.scrollTop > 20
    ) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
};



// When the user clicks on the button, scroll to the top of the document
mybutton.addEventListener('click', () => {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
})


$(document).ready(function () {

    $('.over__lay').addClass('active');


    let $carousel = $(".carousel__wrap");
    $carousel.flickity({
        //Options
        cellAlign: "left",
        contain: true,
        wrapAround: true,
        prevNextButtons: false,
        pageDots: false,
        autoPlay: true,
        friction: 0.8,
    });

    //prev , next button
    $(".left-arrow").on("click", function () {
        $carousel.flickity("next");
    });
    $(".right-arrow").on("click", function () {
        $carousel.flickity("previous");
    });

    let $carousel2 = $(".saleUp__wrap");
    $carousel2.flickity({
        //Options
        cellAlign: "left",
        contain: true,
        wrapAround: true,
        prevNextButtons: false,
        pageDots: false,
        autoPlay: true,
        friction: 0.8,
    });

    let headerTop = $('.header__top');
    let headerBottom = $('.header__bottom');
    $(window).scroll(function () {
        let scrollY = $(window).scrollTop();
        if (scrollY > headerBottom.outerHeight()) {
        headerBottom.addClass("active");

            
        } else {
         headerBottom.removeClass("active");
        }
    });


    //GSAP
    let textOvelay = $(".welcome_overlay");
    let mainOverlay = $('.welcome');
    let body = $('body');


    tlClick = new gsap.timeline();
    tlFirst = new gsap.timeline();

    tlFirst.to(textOvelay, 2, { x: "100%", ease: Power1.easeInOut });
    $(window).click(function () {
        
        tlFirst.timeScale(2).reverse();
        tlClick.to(mainOverlay, 2, {
 
            y: "-100%",
            ease: Power4.easeInOut,
            delay: 0.6,
        });
    });
    gsap.set(".mouse", { xPercent: -50, yPercent: -50 });

    const box = document.querySelector(".mouse");
    const pos = { x: window.innerWidth / 2, y: window.innerHeight / 2 };
    const mouse = { x: pos.x, y: pos.y };
    const speed = 0.35;

    const xSet = gsap.quickSetter(box, "x", "px");
    const ySet = gsap.quickSetter(box, "y", "px");

    window.addEventListener("mousemove", (e) => {
        mouse.x = e.x;
        mouse.y = e.y;
    });

    gsap.ticker.add(() => {
        // adjust speed for higher refresh monitors
        const dt = 1.0 - Math.pow(1.0 - speed, gsap.ticker.deltaRatio());

        pos.x += (mouse.x - pos.x) * dt;
        pos.y += (mouse.y - pos.y) * dt;
        xSet(pos.x);
        ySet(pos.y);
    });
})

