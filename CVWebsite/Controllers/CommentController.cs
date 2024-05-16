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


        [HttpGet("/api/comments")]
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


        [HttpPut("/api/comment/{commentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateComment(int commentId, [FromBody] Comment updatedComment)
        {
            if (updatedComment == null)
                return BadRequest(ModelState);

            if (commentId != updatedComment.Id)
                return BadRequest(ModelState);

            if (!_commentRepository.CommentExists(commentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            //if (!_commentRepository.UpdateComment(updatedComment))
            //{
            //    ModelState.AddModelError("", "Something went wrong updating comment");
            //    return StatusCode(500, ModelState);
            //}

            return Ok(updatedComment);
        }

        [HttpDelete("/api/comment{commentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(int commentId)
        {
            if (!_commentRepository.CommentExists(commentId))
            {
                return NotFound();
            }

            var commentToDelete = _commentRepository.GetComment(commentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_commentRepository.DeleteComment(commentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
