// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
//search and substr

function next(currenturl) {
    //to store the page number (string)
    var x = 0;
    //to store the page number (number)
    var y = 0;
    var newurl = "";

    //did not find page, means we need to make page=2 
    if (currenturl.search("page") == -1) {
        
        newurl = currenturl + "&page=2";
        document.getElementById("nextlink").setAttribute("href", newurl);

    } else {
    //make page++
        x = currenturl.substr(currenturl.search("page") + 5);
        y = Number(x);
        y++;
        newurl = currenturl.substr(0, currenturl.search("page") + 5) + y;
        document.getElementById("nextlink").setAttribute("href", newurl);
    }
}

function previous(currenturl) {
    //just deduct the page number 
    var x = currenturl.substr(currenturl.search("page") + 5);
    var y = Number(x);
    y--;
    var newurl = currenturl.substr(0, currenturl.search("page") + 5) + y;
    document.getElementById("previouslink").setAttribute("href", newurl);
}