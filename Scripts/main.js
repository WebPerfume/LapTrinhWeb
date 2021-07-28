
const searchBtn = document.querySelector('.search');
const cartBtn = document.querySelector('.cart');
const closeSearchBtn = document.querySelector('.navSearch .close');
const closeCartBtn = document.querySelector('.navCart .close');
const overlay = document.querySelector('.overlay');
const navSearch = document.querySelector('.navSearch');
const navCart = document.querySelector('.navCart');


//Close Nav
function closeNav() {
    navSearch.classList.remove('active');
    navCart.classList.remove('active');
    overlay.classList.remove('active');
}

//Open Nav
searchBtn.addEventListener('click', (e) => {
    e.stopPropagation();
    navSearch.classList.add('active');
    overlay.classList.add('active');
})


//Close Nav Button
closeSearchBtn.addEventListener('click', (e) => {
    e.stopPropagation();
    closeNav();
})

closeCartBtn.addEventListener('click', (e) => {
    e.stopPropagation();
    closeNav();
})

window.addEventListener('click', (e) => {
    if (!navSearch.contains(e.target) && !navCart.contains(e.target)) {
        closeNav();
    }
 
})



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



})

