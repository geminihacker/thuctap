function w3_open() {
    document.getElementsByClassName("w3-sidenav")[0].style.width = "100%";
    document.getElementsByClassName("w3-sidenav")[0].style.display = "block";
}
function w3_close() {
    document.getElementsByClassName("w3-sidenav")[0].style.display = "none";
}
//////////
function w3_open1() {
    document.getElementById("main").style.marginLeft = "25%"
    document.getElementsByClassName("w3-sidenav")[0].style.width = "25%";
    document.getElementsByClassName("w3-sidenav")[0].style.display = "block";
    document.getElementsByClassName("w3-opennav")[0].style.display = 'none';
}
function w3_close1() {
    document.getElementById("main").style.marginLeft = "0%";
    document.getElementsByClassName("w3-sidenav")[0].style.display = "none";
    document.getElementsByClassName("w3-opennav")[0].style.display = "inline-block";
}
/////////////
function w3_click(id) {
    document.getElementById(id).classList.toggle("w3-show");
}
function w3_open_nav(x) {
    if (document.getElementById(x).style.display == "block") {
        w3_close_nav(x);
    } else {
        //w3_close_nav("tutorials");
        //w3_close_nav("references");
        //w3_close_nav("examples");
        //w3_close_nav("translate");
        //w3_close_nav("search");
        document.getElementById(x).style.display = "block";
        if (document.getElementById("navbtn_" + x)) {
            document.getElementById("navbtn_" + x).getElementsByTagName("i")[0].style.display = "none";
            document.getElementById("navbtn_" + x).getElementsByTagName("i")[1].style.display = "inline";
        }
        if (x == "nav_search") {
            if (document.getElementById("gsc-i-id1")) { document.getElementById("gsc-i-id1").focus(); }
        }
    }
}
function w3_close_nav(x) {
    document.getElementById(x).style.display = "none";
    if (document.getElementById(x)) {
        document.getElementById(x).getElementsByTagName("i")[0].style.display = "inline";
        document.getElementById(x).getElementsByTagName("i")[1].style.display = "none";
    }
}
function myFunction(id) {
    var x = document.getElementById(id);
    if (x.className.indexOf("w3-show") == -1) 
        x.className += " w3-show";
    else 
        x.className = x.className.replace(" w3-show", "");
}

