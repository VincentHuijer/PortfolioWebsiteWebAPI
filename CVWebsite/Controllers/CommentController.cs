using CVWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CVWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly List<Comment> _comments;

        public CommentController()
        {
            // Initialize comments
            _comments = new List<Comment>
            {
                new Comment { Id = 1, Email = "example1@example.com", FirstName = "John", LastName = "Doe", PostDate = DateTime.Now, Message = "First comment" },
                new Comment { Id = 2, Email = "example2@example.com", FirstName = "Jane", LastName = "Doe", PostDate = DateTime.Now, Message = "Second comment" }
            };
        }

    
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
            return _comments.ToList();
        }

    
        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        [HttpPost]
        public IActionResult PostComment([FromBody] Comment comment)
        {
            comment.Id = _comments.Count + 1;
            comment.PostDate = DateTime.Now;
            _comments.Add(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

  
        [HttpPut("{id}")]
        public IActionResult PutComment(int id, [FromBody] Comment updatedComment)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            comment.Email = updatedComment.Email;
            comment.FirstName = updatedComment.FirstName;
            comment.LastName = updatedComment.LastName;
            comment.Message = updatedComment.Message;
            return Ok(comment);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            _comments.Remove(comment);
            return NoContent();
        }
    }
}
