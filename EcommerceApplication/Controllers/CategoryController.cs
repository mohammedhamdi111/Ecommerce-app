using EcommerceApplication.Core.Models;
using EcommerceApplication.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System.Data;

namespace EcommerceApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IToastNotification _toastNotification;

        public CategoryController(IUnitOfWork unitOfWork, IToastNotification toastNotification)
        {
            this.unitOfWork = unitOfWork;
            _toastNotification = toastNotification;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            List<Category> categories = unitOfWork.Categories.GetAll().ToList();
            return View(categories);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(Category category)
        {

            if (ModelState.IsValid)
            {
                await unitOfWork.Categories.AddAsync(category);
                unitOfWork.Complete();
                _toastNotification.AddSuccessToastMessage("Added Successfully");
                return RedirectToAction("Categories");
            }
            ModelState.AddModelError(string.Empty, "Invalid inputs");

            return View(category);
        }

        public IActionResult Edit(int id)
        {

            Category CurrentCategory = unitOfWork.Categories.GetById(id);
            if (CurrentCategory == null)
            {
                return RedirectToAction(nameof(Categories));
            }
            return View(CurrentCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Update(category);
                unitOfWork.Complete();
            }
            _toastNotification.AddSuccessToastMessage("Updated Successfully");
            return RedirectToAction(nameof(Categories));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Category CategoryDeleted = await unitOfWork.Categories.GetByIdAsync(id);
            if (CategoryDeleted == null)
            {
                return NotFound();
            }
            unitOfWork.Categories.Delete(CategoryDeleted);
            unitOfWork.Complete();
            _toastNotification.AddSuccessToastMessage("Deleted Successfully");
            return RedirectToAction(nameof(Categories));
        }
      
        
       
      

       



    }
}
