using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }
    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult DbConnection()
    {
        bool isAdmin = User.IsInRole("Admin");
        bool isAuthenticated = User.Identity.IsAuthenticated;
        string name = User.Identity.Name;
        string authType = User.Identity.AuthenticationType;
        string id = _userManager.GetUserId(User);

        ViewBag.Message = $"User {name} is authenticated? {isAuthenticated} using type {authType} and is an Admin? {isAdmin} ID from Identity {id}";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}