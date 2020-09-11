using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contacts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderMate_Server.Controllers
{
    [Route("api/userComment")]
    [ApiController]
    public class User_CommentController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public User_CommentController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUserComments()
        {
            try
            {
                var userComments = _repository.User_Comment.GetAllComments();
                _logger.LogInfo($"Returned all userComments from db.");

                var userCommentsResult = _mapper.Map<IEnumerable<User_CommentDto>>(userComments);
                return Ok(userCommentsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllUserComments action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "User_CommentById")]
        public IActionResult GetUser_CommentById(int id)
        {
            try
            {
                var userComment = _repository.User_Comment.GetUserCommentById(id);

                if (userComment == null)
                {
                    _logger.LogError($"userComment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned userComment with id: {id}");

                    var userCommentResult = _mapper.Map<User_CommentDto>(userComment);
                    return Ok(userCommentResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUser_CommentById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetUser_CommentWithDetails(int id)
        {
            try
            {
                var userComment = _repository.User_Comment.GetUserCommentWithDetails(id);

                if (userComment == null)
                {
                    _logger.LogError($"userComment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"userComment with details for id: {id}");

                    var userCommentResult = _mapper.Map<User_CommentDetailsDto>(userComment);
                    return Ok(userCommentResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUser_CommentWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateUser_Comment([FromBody] User_CommentForCreationDto userComment)
        {
            try
            {
                if (userComment == null)
                {
                    _logger.LogError("userComment object sent from client is null.");
                    return BadRequest("userComment object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid userComment object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var userCommentEntity = _mapper.Map<UserComment>(userComment);

                _repository.User_Comment.CreateUserComment(userCommentEntity);
                _repository.Save();

                var createdUser_Comment = _mapper.Map<User_CommentDto>(userCommentEntity);

                return CreatedAtRoute("User_CommentById", new { id = createdUser_Comment.UserCommentId }, createdUser_Comment);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser_Comment action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser_Comment(int id, [FromBody] User_CommentForUpdateDto userComment)
        {
            try
            {
                if (userComment == null)
                {
                    _logger.LogError("userComment object sent from client is null.");
                    return BadRequest("userComment object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid userComment object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var userCommentEntity = _repository.User_Comment.GetUserCommentById(id);
                if (userCommentEntity == null)
                {
                    _logger.LogError($"userComment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(userComment, userCommentEntity);

                _repository.User_Comment.UpdateUserComment(userCommentEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUser_Comment action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser_Comment(int id)
        {
            try
            {
                var userComment = _repository.User_Comment.GetUserCommentById(id);
                if (userComment == null)
                {
                    _logger.LogError($"userComment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.User_Comment.DeleteUserComment(userComment);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUser_Comment action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
