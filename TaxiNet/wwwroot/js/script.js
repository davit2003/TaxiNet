var swiper = new Swiper('.swiper-container', {
    pagination: {
        el: '.swiper-pagination',
        type: 'progressbar',
    },
    loop: true,
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});

let mymenu = document.getElementsByClassName("hiddenmenu")[0];
let menuopenbutton = document.getElementsByClassName("openbutton")[0];
let phototoopen = document.getElementById("photo");
let photooverlay = document.getElementsByClassName("photo-overlay")[0];

window.addEventListener("resize", function(){
    if(window.screen.innerWidth > 770){
        menuopenbutton.style.display = "none";
    }
})

function openimage(x){
    photooverlay.style.display = "flex";
    phototoopen.src = x.firstElementChild.src;
    console.log(x.firstElementChild.src);
}

function closephoto(){
    photooverlay.style.display = "none";
}

function menuopen(x) {
    x.style.display = 'none';
    mymenu.style.right = "0px";
}

function menuclose(x) {
    menuopenbutton.style.display = "flex";
    mymenu.style.right = "-200px";
}
function change(x){
    let boxes = document.getElementsByClassName("boxes");
    for(let i = 0; i < boxes.length; i++){
        if(boxes[i].dataset.content != x && x != "All")
            boxes[i].style.display = "none";
        else boxes[i].style.display = "block";
    }
}