var sidenav=document.querySelector(".side-navbar")

function showNavbar(){
    sidenav.style.left = "0"
}

function closeNavbar(){
    sidenav.style.left = "-60%"
}

function proceedToCheckout() {
  const paymentModal = document.getElementById("paymentModal");
  paymentModal.style.display = "flex";
}

function onPaymentSuccess() {
    document.querySelector('.payment-modal-content').innerHTML = `
        <h3>Thank you for your purchase!</h3>
        <p>We value your feedback. Please take a moment to review your experience.</p>
        <a href="/Review/Submit" class="btn btn-success" style="margin-top:12px;display:inline-block;padding:10px 28px;font-size:1.08em;border-radius:6px;text-decoration:none;">Leave a Review</a>
    `;
}

function closePaymentModal() {
  const paymentModal = document.getElementById("paymentModal");
  paymentModal.style.display = "none";
}

