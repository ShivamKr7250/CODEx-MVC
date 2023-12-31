﻿using ClosedXML.Excel;
using CODEx.DataAccess.Repository.IRepository;
using CODEx.Model;
using CODEx.Model.View_Models;
using CODEx.Utility;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace CODEx.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class RegistrationFormController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegistrationFormController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<RegistrationForm> objRegistrationList = _unitOfWork.RegistrationForm.GetAll().ToList();
            return View(objRegistrationList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegistrationForm obj)
        {
            Random random = new Random();
            int registrationId = random.Next(1000, 9999);
            if (ModelState.IsValid)
            {
                obj.TeamId = $"MINI2024{registrationId}";
                _unitOfWork.RegistrationForm.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Registration Created Successfully";
                return RedirectToAction("TeamId", "RegistrationForm", new { teamId = obj.Id });
            }
            return View();
        }


        public IActionResult TeamId(int teamId)
        {
            RegistrationForm uniqueId = _unitOfWork.RegistrationForm.Get(x => x.Id == teamId);
            return View(uniqueId);

            //var uniqueId = _unitOfWork.RegistrationForm.Get(x => x.Id == registrationId);
            //return View(uniqueId);
        }

        public IActionResult ExportToExcel()
        {
            // Get the data from the model.
            var data = _unitOfWork.RegistrationForm.GetAll().ToList();

            // Create a new Excel workbook.
            using (var workbook = new XLWorkbook())
            {
                // Create a new worksheet.
                var worksheet = workbook.Worksheets.Add("Registration Details");

                // Add the data to the worksheet.
                int row = 1;
                foreach (var registration in data)
                {
                    worksheet.Cell(row, 1).Value = registration.TeamId;
                    worksheet.Cell(row, 2).Value = registration.TeamName;
                    worksheet.Cell(row, 3).Value = registration.College;
                    worksheet.Cell(row, 4).Value = registration.Department;
                    worksheet.Cell(row, 5).Value = registration.TeamLeaderNanme;
                    worksheet.Cell(row, 6).Value = registration.LeaderNumber;
                    worksheet.Cell(row, 7).Value = registration.LeaderEmail;
                    worksheet.Cell(row, 8).Value = registration.Member2Name;
                    worksheet.Cell(row, 9).Value = registration.Member2Number;
                    worksheet.Cell(row, 10).Value = registration.Member3Name;
                    worksheet.Cell(row, 12).Value = registration.Member3Number;
                    worksheet.Cell(row, 12).Value = registration.Member4Name;
                    worksheet.Cell(row, 13).Value = registration.Member4Number;
                    worksheet.Cell(row, 14).Value = registration.Theme;
                    worksheet.Cell(row, 15).Value = registration.Category;
                    worksheet.Cell(row, 16).Value = registration.ProblemStatment;
                    

                    row++;
                }

                // Save the workbook to a MemoryStream.
                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);

                    // Return the MemoryStream as a FileContentResult.
                    return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RegistrationDetails.xlsx");
                }
            }
        }

        
    }
}
