using BookShop.DataAccess;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using BookShop.Models.ViewModels;
using BookShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace BookShopWebb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;        

        public CompanyController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
        public IActionResult Index()
        {           
           return View();
        }        

        //GET
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            
            if (id == null || id == 0)
            {                            
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(company);                
            }            
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {  
                if(company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                    TempData["success"] = "Product created successfully!";
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                    TempData["success"] = "Product updated successfully!";
                } 
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            return View(company);
        } 

        #region API CAll
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new {data=companyList});
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyFromDb = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (companyFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }            
            _unitOfWork.Company.Remove(companyFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
