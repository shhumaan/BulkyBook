using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            if(id == null)
            {
                //this is for create
                return View(coverType);
            }
            //this is for edit
            coverType = _unitOfWork.CoverType.Get(id.GetValueOrDefault());
            if(coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                //its server side validation check //double authentication
                if(coverType.Id == 0)
                {
                    _unitOfWork.CoverType.Add(coverType); //adding data to the db
                    
                }
                else
                {
                    _unitOfWork.CoverType.Update(coverType); //updating data to the db
                }
                _unitOfWork.Save(); //saving Changes
                return RedirectToAction(nameof(Index));// back to coverType page
            }
            return View(coverType);//returning the object if there is an error in object or object is not matching with the state of the model
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.CoverType.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.CoverType.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting"});
            }
            _unitOfWork.CoverType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion

    }
}
