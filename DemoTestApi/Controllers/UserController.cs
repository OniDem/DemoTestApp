using Core.DTO.User;
using Core.Entity;
using DemoTestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        UserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public async Task<UserEntity?> Reg(RegUserRequest request)
        {
            if (ModelState.IsValid)
            {
                _logger.Log(LogLevel.Trace, "Aboba");
                return await _userService.Reg(request);
            }
            return null;
        }

        [HttpPost]
        public async Task<UserEntity?> Auth(AuthUserRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _userService.Auth(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<UserEntity?> AddToShift(AddToShiftRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _userService.AddToShift(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<UserEntity?> Refuse(RefuseUserRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _userService.Refuse(request);
            }
            return null;
        }
    }
}
