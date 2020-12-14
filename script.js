


function move() {
    var slider = document.getElementById("heightRange");
    var output = document.getElementById("heightLabel").innerText;
    document.getElementById("heightLabel").innerText = slider.value;

    slider.oninput = function () {
        document.getElementById("heightLabel").innerText = slider.value + " cm";

    }
}

function theSlide(sliderLabelVar, labelVar) {
    var slider = document.getElementById(sliderLabelVar);
    var output = document.getElementById(labelVar).innerText;
    //output.innerText = slider.value;
    document.getElementById(labelVar).innerText = slider.value;

    slider.oninput = function () {
        // output.innerText = this.value + " cm";
        document.getElementById(labelVar).innerText = slider.value ;

    }
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

// Get the container element
var btnContainer = document.getElementById("calcTop");

// Get all buttons with class="btn" inside the container
var btns = btnContainer.getElementsByClassName("box");

// Loop through the buttons and add the active class to the current/clicked button
for (var i = 0; i < btns.length; i++) {
    btns[i].addEventListener("click", function () {
        var current = document.getElementsByClassName("active");

        // If there's no active class
        if (current.length > 0) {
            current[0].className = current[0].className.replace(" active", "");
        }

        // Add the active class to the current/clicked button
        this.className += " active";
    });
}
