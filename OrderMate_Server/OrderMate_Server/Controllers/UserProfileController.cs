using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contacts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OrderMate_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public UserProfileController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
        }



        [HttpGet]
        //[Authorize(Roles ="Admin")]
        [Route("forAdmin")]
        public string getForAdmin()
        {
            return "method for admin";
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]
        [Route("Foremployee")]
        public string getForEmployee()
        {
            return "method for employee";
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin")]
        [Route("ForAdminOrEmployee")]
        public string getForAdminOrEmployee()
        {
            return "method for adminoremployee";
        }



    }
}