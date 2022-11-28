
function activate(e) {
    let requests = document.querySelectorAll(".request");   //get all requests
    requests.forEach(x => x.classList.remove("active"));    //remove 'active' from all requests

    e.classList.add("active");  //add 'active' to current request

    let details = document.querySelectorAll(".holder");   //get all details
    details.forEach(x => x.classList.remove("show"))    //remove 'show' from all details
    document.getElementById(e.id).classList.add("show");    //add 'show' to current detail
};