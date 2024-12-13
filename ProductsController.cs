using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Office Furniture", Price = 500000, ImageUrl = "https://www.seatingworldindia.com/webp-images/products/Tables.jpg.webp" },
                new Product { Id = 2, Name = "Cloths", Price = 3000, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1FzLunZKLsMURBQZyufucaHxMExbGtnP_kA&s" },
                new Product { Id = 3, Name = "Mobile", Price = 15000, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcScAGCn8FlrZ_QK0YuINa1QoRIJ40HJn0Z4jA&s" },
                new Product { Id = 4, Name = "Buss Pass", Price = 1300, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ21KYx9q0INte_L3iCf4oUhhi83zrJmMXSOw&s" },
                new Product { Id = 5, Name = "Laptop", Price = 30000, ImageUrl = "https://images.jdmagicbox.com/quickquotes/images_main/2017-flagship-dell-premium-inspiron-15-6-led-backlit-hd-laptop-intel-dual-core-i3-7100u-2-4ghz-8gb-ram-128gb-ssd-dvdrw-wlan-bluetooth-hdmi-webcam-3-in-1-card-reader-maxxaudio-win-10-113434439-e1jeu.jpg" },
                 new Product { Id = 6, Name = "Pickles", Price = 500, ImageUrl ="https://images-cdn.ubuy.co.in/6662e3918096a8681829db18-vlasic-kosher-dill-pickles-dill-baby.jpg" }
            };
            //var products = _context.Product.ToList();
            return View(products);
        }
        
        [HttpGet]
        public IActionResult AddToCart()
        {
            return Content("GET request works!");
        }


        [HttpPost]
        public IActionResult AddToCart(int id, string name, decimal price)
        {
            // Ensure the method logic is valid
            var selectedProduct = new Product
            {
                Id = id,
                Name = name,
                Price = price
            };

            return RedirectToAction("Payment", "Products", new { id = selectedProduct.Id, name = selectedProduct.Name, price = selectedProduct.Price });

        }

        public IActionResult Payment(Product product)
        {
            var paymentModes = new List<string> { "Paytm", "PhonePe", "GooglePay" };
            ViewBag.PaymentModes = paymentModes;
            return View(product);
        }

        [HttpPost]
        public IActionResult PaymentConfirmed(Payment payment)
        {
            var gst = payment.TotalAmount * 0.18M; // GST 18%
            var totalAmountWithGST = payment.TotalAmount + gst;

            ViewBag.TotalAmountWithGST = totalAmountWithGST;
            return View("PaymentSuccess");
        }


        [HttpGet]
        public IActionResult Login(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login()
        {
            var Login = _context.Login;
            _context.SaveChanges();
            return RedirectToAction("Index");
            // return View();
        }
        [HttpGet]
        public IActionResult UserForm(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserForm()
        {
            var UserForm = _context.UserForm;
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
    
    }

    
}

