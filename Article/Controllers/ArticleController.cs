using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Article.Entities;
using Article.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Article.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]

    public class ArticleController : ControllerBase
    {

        private ArticlesDbContext _context;
        private IRepository<Articles, int> repository;
        bool autoSave = true;

        public ArticleController(IRepository<Articles, int> repository)
        {
            this.repository = repository;
        }

        public ArticleController(ArticlesDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetArticle()
        {
            var response = repository.GetListAsync();
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var removeArticle = repository.DeleteAsync(id, autoSave);

            return Ok(removeArticle);
        }
        [HttpPost]
         
        public async Task<ActionResult> AddArticle(Articles articles)
        {
            var response = repository.AddAsync(articles, autoSave);

            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateArticle(Articles articles)
        {
            var response = repository.UpdateAsync(articles, autoSave);

            return Ok(response);
        }
        public async Task<ActionResult> SearchArticle(Articles articles)
        {
            var response = repository.AsQueryable()
                .Where(x => x.Title == articles.Title ||
                x.WriterName == articles.WriterName ||
                x.WriterSurname == articles.WriterSurname ||
                x.Content.Equals(articles.Content)).ToList();
            return Ok(response);
        }

    }
}
