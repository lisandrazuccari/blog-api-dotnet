using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using BlogAPI.Data;

namespace BlogAPI.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class BlogPostsController : ControllerBase
   {
        private readonly BlogDbContext _context;
        private readonly ILogger<BlogPostsController> _logger;

        public BlogPostsController(BlogDbContext context, ILogger<BlogPostsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetAllPosts()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetPost(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);

            if (post == null)
            {
                _logger.LogWarning("Blog post with ID {id} not found", id);
                return NotFound();
            }

                return post;
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreatePost(BlogPost post)
        {
            try
            {
                post.PublishedDate = DateTime.UtcNow;

                _context.BlogPosts.Add(post);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created blog post with ID {id}", post.Id);

                return CreatedAtAction(
                    nameof(GetPost),
                    new { id = post.Id},
                    post
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating blog post");
                return StatusCode(500, "An error occured while creating the blog post");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, BlogPost post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            try
            {
                _context.Entry(post).State = EntityState.Modified;
                
                _context.Entry(post).Property(x => x.PublishedDate).IsModified = false;

                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!await PostExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(post);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Deleted blog post with ID {id}", id);

            return NoContent();
        }

        private async Task<bool> PostExists(int id)
        {
            return await _context.BlogPosts.AnyAsync(e => e.Id == id);
        }
    }
}