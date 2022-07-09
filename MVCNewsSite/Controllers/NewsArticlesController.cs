using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCNewsSite.Data;
using MVCNewsSite.Models;

namespace MVCNewsSite.Controllers
{
    public class NewsArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewsArticles
        public async Task<IActionResult> Index()
        {
              return _context.NewsArticles != null ? 
                          View(await _context.NewsArticles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NewsArticles'  is null.");
        }

        // GET: NewsArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewsArticles == null)
            {
                return NotFound();
            }

            var newsArticle = await _context.NewsArticles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsArticle == null)
            {
                return NotFound();
            }

            return View(newsArticle);
        }

        // GET: NewsArticles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsArticles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Headline,Extract,Encoding,Text,PublishDate,ByLine,TweetText,Source,State,ClientQuote,CreatedDate,LastModifiedDate,HtmlTitle,HtmlMetaDescription,HtmlMetaKeywords,HtmlMetaLangauge,Tags,Priority,Format,PhotoHtmlAlt,PhotoOrientation,PhotoWidth,PhotoHeight,PhotoUrl")] NewsArticle newsArticle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsArticle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsArticle);
        }

        // GET: NewsArticles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewsArticles == null)
            {
                return NotFound();
            }

            var newsArticle = await _context.NewsArticles.FindAsync(id);
            if (newsArticle == null)
            {
                return NotFound();
            }
            return View(newsArticle);
        }

        // POST: NewsArticles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Headline,Extract,Encoding,Text,PublishDate,ByLine,TweetText,Source,State,ClientQuote,CreatedDate,LastModifiedDate,HtmlTitle,HtmlMetaDescription,HtmlMetaKeywords,HtmlMetaLangauge,Tags,Priority,Format,PhotoHtmlAlt,PhotoOrientation,PhotoWidth,PhotoHeight,PhotoUrl")] NewsArticle newsArticle)
        {
            if (id != newsArticle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsArticle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsArticleExists(newsArticle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newsArticle);
        }

        // GET: NewsArticles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewsArticles == null)
            {
                return NotFound();
            }

            var newsArticle = await _context.NewsArticles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsArticle == null)
            {
                return NotFound();
            }

            return View(newsArticle);
        }

        // POST: NewsArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewsArticles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NewsArticles'  is null.");
            }
            var newsArticle = await _context.NewsArticles.FindAsync(id);
            if (newsArticle != null)
            {
                _context.NewsArticles.Remove(newsArticle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsArticleExists(int id)
        {
          return (_context.NewsArticles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
