using CVWebsite.Interfaces;
using CVWebsite.Models;
using CVWebsite.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CVWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
            var comments = _commentRepository.GetComments();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(comments);
        }


        [HttpGet("{commentId}")]
        [ProducesResponseType(200, Type = typeof(Comment))]
        [ProducesResponseType(400)]
        public IActionResult GetBook(int commentId)
        {
            if (!_commentRepository.CommentExists(commentId))
                return NotFound();

            var comment = _commentRepository.GetComment(commentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(comment);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Comment))]
        [ProducesResponseType(400)]
        public IActionResult PostComment([FromBody] Comment comment)
        {
            _commentRepository.CreateComment(comment);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("succesfully created");
        }


        [HttpPut("{id}")]
        public IActionResult PutComment(int id, [FromBody] Comment updatedComment)
        {
            _commentRepository.UpdateComment(id);
            if (_commentRepository == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //_commentRepository.Email = updatedComment.Email;
            //_commentRepository.FirstName = updatedComment.FirstName;
            //_commentRepository.LastName = updatedComment.LastName;
            //_commentRepository.Message = updatedComment.Message;
            return Ok(_commentRepository);
        }


        //[HttpDelete("{id}")]
        //public IActionResult DeleteComment(int id)
        //{
        //    _commentRepository.FirstOrDefault(c => c.Id == id);
        //    if (_commentRepository == null)
        //    {
        //        return NotFound();
        //    }
        //    _comments.Remove(comment);
        //    return NoContent();
        //}
    }
}
