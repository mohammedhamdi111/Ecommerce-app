using EcommerceApplication.Core.Models;
using EcommerceApplication.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace EcommerceApplication.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IToastNotification toastNotification;
        public ProductController(IUnitOfWork unitOfWork, IToastNotification toastNotification)
        {
            this.unitOfWork = unitOfWork;
            this.toastNotification = toastNotification;
        }

        public async Task<IActionResult> GetAll()
        {
            List<Product> products = unitOfWork.Products.FindAll(x => x.Id > 0, new[] { "Category" }).ToList();

            return View(products);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Product product)
        {

            if (ModelState.IsValid)
            {
                product.CreatedDate= DateTime.Now;
                await unitOfWork.Products.AddAsync(product);
                unitOfWork.Complete();
                toastNotification.AddSuccessToastMessage("Added Successfully");
                return RedirectToAction(nameof(GetAll));
            }
            ModelState.AddModelError(string.Empty, "Invalid inputs");

            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0 || id == null)
                return NotFound();
            Product product = unitOfWork.Products.GetById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            unitOfWork.Products.Update(product);
            unitOfWork.Complete();
            toastNotification.AddSuccessToastMessage("Updated Successfully");
            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product product = await unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            unitOfWork.Products.Delete(product);
            unitOfWork.Complete();
            toastNotification.AddSuccessToastMessage("Deleted Successfully");
            return RedirectToAction(nameof(GetAll));
        }







    }
}
