//window.smoothScroll = function (target) {
//    var scrollContainer = target;
//    do { //find scroll container
//        scrollContainer = scrollContainer.parentNode;
//        if (!scrollContainer) return;
//        scrollContainer.scrollTop += 1;
//    } while (scrollContainer.scrollTop == 0);

//    var targetY = 0;
//    do { //find the top of target relatively to the container
//        if (target == scrollContainer) break;
//        targetY += target.offsetTop;
//    } while (target = target.offsetParent);

//    scroll = function (c, a, b, i) {
//        i++; if (i > 30) return;
//        c.scrollTop = a + (b - a) / 30 * i;
//        setTimeout(function () { scroll(c, a, b, i); }, 20);
//    }
//    // start scrolling
//    scroll(scrollContainer, scrollContainer.scrollTop, targetY, 0);
//}

function viewBud() {
    var element = document.getElementById("section2");
    alert("This is Working");
    element.scrollIntoView();

}

function addActive() {
    // Get the container element
    var btnContainer = document.getElementById("bottom_sidebar");

    // Get all buttons with class="btn" inside the container
    var btns = btnContainer.getElementsByClassName("_inner_links");

    // Loop through the buttons and add the active class to the current/clicked button
    for (var i = 0; i < btns.length; i++) {
        btns[i].addEventListener("click", function () {
            var current = document.getElementsByClassName("active");

            // If there's no active class
            if (current.length > 0) {
                current[0].className = current[0].className.replace("active", "");
            }

            // Add the active class to the current/clicked button
            this.className += " active";
        });
    }
}