
function activate(e, id) {
    
    let requests = document.querySelectorAll(".request");   //get all requests
    requests.forEach(x => x.classList.remove("active"));    //remove 'active' from all requests
    e.classList.add("active");  //add 'active' to current request


    let details = document.querySelectorAll(".holder");   //get all details
    details.forEach(x => x.classList.remove("show"))    //remove 'show' from all details

    let el = document.getElementById(id);
    el.classList.add("show");    //add 'show' to current detail
    
    document.querySelector("#deleteRequest").removeAttribute("hidden");
    document.querySelector("#delete__inp").setAttribute("value", id);
    console.log(document.querySelector("#delete__inp"));
};


function showDetails(e, id) {

    let requests = document.querySelectorAll(".request");   //get all requests
    requests.forEach(x => x.classList.remove("active"));    //remove 'active' from all requests
    e.classList.add("active");  //add 'active' to current request


    let details = document.querySelectorAll(".holder");   //get all details
    details.forEach(x => x.classList.remove("show"))    //remove 'show' from all details

    let el = document.getElementById(id);
    el.classList.add("show");    //add 'show' to current detail

    document.querySelector("#deleteRequest").removeAttribute("hidden");
    document.querySelector("#delete__inp").setAttribute("value", id);
    console.log(document.querySelector("#delete__inp"));
};


(function() {
    "use strict";
    const btn = document.getElementById("deleteRequest");
    btn.addEventListener("click", () => {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                document.querySelector(".delete__wrap").submit()
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }
        })
    });
})();