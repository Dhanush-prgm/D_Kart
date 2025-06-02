var sidenav = document.querySelector(".side-navbar")

function showNavbar() {
    sidenav.style.left = "0"
}

function closeNavbar() {
    sidenav.style.left = "-60%"
}

var productContainer = document.getElementById("products")
var search=document.getElementById("search")
var productList=productContainer.querySelectorAll("div")

search.addEventListener("keyup",function(){
    var enteredValue=event.target.value.toUpperCase()

    for(count=0;count<productList.length;count++){  
        var productname=productList[count].querySelector("p").textContent
        if(productname.toUpperCase().indexOf(enteredValue)<0){
            productList[count].style.display="none"
        }
        else{
            productList[count].style.display="block"
        }
    }
})

// Select all "Add to Cart" buttons
const addToCartButtons = document.querySelectorAll(".add-to-cart");

// Add click event listeners to each button
addToCartButtons.forEach((button) => {
  button.addEventListener("click", () => {
    // Get product details from the DOM
    const productBox = button.parentElement;
    const productName = productBox.querySelector("p").textContent;
    const productImage = productBox.querySelector("img").src;

    // Create a product object
    const product = {
      id: Date.now(), // Unique ID for the product
      name: productName,
      image: productImage,
    };

    // Retrieve existing cart data from localStorage
    let cart = JSON.parse(localStorage.getItem("cart")) || [];

    // Add the new product to the cart
    cart.push(product);

    // Save the updated cart back to localStorage
    localStorage.setItem("cart", JSON.stringify(cart));

    // Show confirmation (optional)
    alert(`${productName} has been added to your cart.`);
  });
});


//function redirectToDetails(productName) {
//    window.location.href = '/ProductDetails/' + encodeURIComponent(productName);
//}


