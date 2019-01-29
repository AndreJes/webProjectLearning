using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotNetProject.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(2018, 01, 01);
            }
            if(!maxDate.HasValue)
            {
                maxDate = new DateTime(2018, 12, 01);
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minDate.Value, maxDate.Value);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2018, 01, 01);
            }
            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(2018, 12, 01);
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate.Value, maxDate.Value);
            return View(result);
        }
    }
}