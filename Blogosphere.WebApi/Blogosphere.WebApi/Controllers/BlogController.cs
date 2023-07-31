using AutoMapper;
using Blogosphere.WebApi.Context;
using Blogosphere.WebApi.DTOs;
using Blogosphere.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogosphere.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        readonly AppDbContext _context;
        readonly IMapper _mapper;

        public BlogController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<BlogDto>>> GetBlogs()
        {
            var blogs = await _context.Blogs.ToListAsync();
            var blogDtos = _mapper.Map<List<BlogDto>>(blogs);
            return Ok(blogDtos);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<BlogDto>> GetBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            var blogDto = _mapper.Map<BlogDto>(blog);
            return Ok(blogDto);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> PutBlog(int id, UpdateBlogDto updateBlogDto)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            _mapper.Map(updateBlogDto, blog);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<BlogDto>> PostBlog(CreateBlogDto createBlogDto)
        {
            var blog = _mapper.Map<Blog>(createBlogDto);
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            var blogDto = _mapper.Map<BlogDto>(blog);
            return CreatedAtAction(nameof(GetBlog), new { id = blogDto.Id }, blogDto);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<BlogDto>> PostBlogWithoutLargePic(CreateBlogDtoWithoutLarge createBlogDto)
        {
            var blog = _mapper.Map<Blog>(createBlogDto);
            blog.UserId = 1;
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            var blogDto = _mapper.Map<BlogDto>(blog);
            return CreatedAtAction(nameof(GetBlog), new { id = blogDto.Id }, blogDto);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
