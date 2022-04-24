using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMS.News.API.Mappers;
using MMS.News.API.Models;
using MMS.News.BLL.Public.Services;

namespace MMS.News.API.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<NewsModel> Get(int id)
        {
            var news = _newsService.Get(id);

            if (news is null)
                return NotFound();

            return news.ToModel();
        }
        
        [HttpGet("latest")]
        public ActionResult<IEnumerable<NewsModel>> Latest(DateTime? dateAfter = null)
        {
            var news = _newsService
                .GetLatestNews(dateAfter ?? DateTime.Today)
                .Select(_ => _.ToModel());

            return Ok(news);
        }

        [HttpGet("/api/author/{authorId:int}/news")]
        public ActionResult<IEnumerable<NewsModel>> AuthorNews(int authorId)
        {
            var news = _newsService
                .GetAuthorsNews(authorId)
                .Select(_ => _.ToModel());
            
            return Ok(news);
        }

        [HttpGet("by-category")]
        public ActionResult<IEnumerable<NewsModel>> NewsByCategory(string category)
        {
            var news = _newsService
                .GetNewsByCategory(category)
                .Select(_ => _.ToModel());
            
            return Ok(news);
        }
        
        [HttpGet("by-tags")]
        public ActionResult<IEnumerable<NewsModel>> NewsByTags([FromQuery]params int[] tags)
        {
            var news = _newsService
                .GetNewsByTags(tags.ToList())
                .Select(_ => _.ToModel());
            
            return Ok(news);
        }
    }
}
