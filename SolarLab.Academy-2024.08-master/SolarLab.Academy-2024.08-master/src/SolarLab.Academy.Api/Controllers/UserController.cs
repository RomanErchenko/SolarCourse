using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.AppServices.User.Service;
using SolarLab.Academy.Contracts.Adverts;

namespace SolarLab.Academy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {

            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserShortDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {

            var result = await _userService.Getall(cancellationToken);


            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody]UserDto user, CancellationToken cancellationToken)
        {
            var us = await _userService.AddUser(user, cancellationToken);
            return Ok(us);

        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(Guid id,[FromBody]UserUpdate userUpdate, CancellationToken cancellationToken)
        {
          await _userService.UpdateUser(id,userUpdate,cancellationToken);
            return Ok();
        
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
             await _userService.DeleteUser(id, cancellationToken);
            return Ok();
        }
    }
}
