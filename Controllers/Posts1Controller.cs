﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reddit.Dtos;
using Reddit.Models;

namespace Reddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Posts1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Posts1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync(); // .Include(p => p.Comments)
        }

        // GET: api/Posts1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id); // .Include(p => p.Comments)

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST: api/Posts1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(PostDto postDto)
        {
            if (postDto == null)
            {
                return NoContent();
            }

            var post = new Post()
            {
                Title = postDto.Title,
                Content = postDto.Content,
                AuthorId = postDto.AuthorId,
                CommunityId = postDto.CommunityId,
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return Ok();

            //var post = postDto.CreatePost();

            //_context.Posts.Add(post);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // PUT: api/Posts1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, PostDto post)
        {
            var postDto = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (postDto == null)
            {
                return NotFound();
            }

            postDto.Title = post.Title;
            postDto.Content = post.Content;
            postDto.AuthorId = post.AuthorId;
            postDto.CommunityId = post.CommunityId;

            _context.Entry(postDto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }


        // DELETE: api/Posts1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
