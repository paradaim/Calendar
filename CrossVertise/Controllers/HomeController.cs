using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrossVertise.Models;
using System.Globalization;

namespace CrossVertise.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITaskService _taskService;
    public HomeController(ILogger<HomeController> logger,ITaskService taskService)
    {
        _logger = logger;
        _taskService=taskService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
    public IActionResult Calendar()
    {
        CalendarViewModel calendarViewModel = new CalendarViewModel();
        calendarViewModel.months = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToList();
        calendarViewModel.selectedMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
        return View(calendarViewModel);
    }
    public PartialViewResult _Appointments(string month = "")
    {
        return PartialView("~/Views/Shared/_Appointments.cshtml", _taskService.Appointments(month));
    }
    public PartialViewResult _AppointmentsDetails(string TaskID = "")
    {
        return PartialView("~/Views/Shared/_AppointmentsDetails.cshtml", _taskService.AppointmentsDetails(TaskID));
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
