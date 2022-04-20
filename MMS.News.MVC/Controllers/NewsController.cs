using Microsoft.AspNetCore.Mvc;
using MMS.News.BLL.Public.Services;

namespace MMS.News.MVC.Controllers;

public class NewsController : Controller
{
    private INewsService _newsService;
    private readonly int _latestNewsDaysLimit;

    public NewsController(INewsService newsService, int latestNewsDaysLimit = 1)
    {
        _newsService = newsService;
        _latestNewsDaysLimit = latestNewsDaysLimit;
    }

    public IActionResult Latest()
    {
        var latestNews = _newsService.GetLatestNews(
            DateTime.Today - TimeSpan.FromDays(_latestNewsDaysLimit)
        );

        return View(latestNews);
    }
}