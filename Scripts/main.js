const searchBtn = document.querySelector('.search');
const cartBtn = document.querySelector('.cart');
const closeSearchBtn = document.querySelector('.navSearch .close');
const closeCartBtn = document.querySelector('.navCart .close');
const overlay = document.querySelector('.overlay');
const navSearch = document.querySelector('.navSearch');
const navCart = document.querySelector('.navCart');

function closeNav() {
    navSearch.classList.remove('active');
    navCart.classList.remove('active');
    overlay.classList.remove('active');
}

searchBtn.addEventListener('click', (e) => {
    e.stopPropagation();
    navSearch.classList.add('active');
    overlay.classList.add('active');
})

cartBtn.addEventListener('click', (e) => {
    e.stopPropagation();
    navCart.classList.add('active');
    overlay.classList.add('active');
})


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

let slide_index = 0
let slide_play = true
let slides = document.querySelectorAll('.carousel__item')

hideAllSlide = () => {
    slides.forEach(e => {
        e.classList.remove('active')
    })
}

showSlide = () => {
    hideAllSlide()
    slides[slide_index].classList.add('active')
}

nextSlide = () => slide_index = slide_index + 1 === slides.length ? 0 : slide_index + 1

prevSlide = () => slide_index = slide_index - 1 < 0 ? slides.length - 1 : slide_index - 1


document.querySelector('.carousel__item').addEventListener('mouseover', () => slide_play = false)


document.querySelector('.carousel__item').addEventListener('mouseleave', () => slide_play = true)


document.querySelector('.right-arrow').addEventListener('click', () => {
    nextSlide()
    showSlide()
})

document.querySelector('.left-arrow').addEventListener('click', () => {
    prevSlide()
    showSlide()
})

showSlide()