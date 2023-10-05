using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            List<UserModel> users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel users = await _userRepository.GetByIdAsync(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Add([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.AddAsync(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {

            UserModel user = await _userRepository.UpdateAsync(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteById(int id)
        {
            bool deleted = await _userRepository.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
