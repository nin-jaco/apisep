using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using ApiSep.Dal;
using ApiSep.DAL.Interfaces;
using ApiSep.Library.Models.dto;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace ApiSep.Ui.Form.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDtoController : ControllerBase
    {
        private IApiSepContext _apiSepContext = new ApiSepContext();

        // GET: api/UserDto
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            var list = new List<UserDto>();
            var results = _apiSepContext.Users.ToList();
            if (results.Any())
            {
                foreach (var result in results)
                {
                    list.Add(UserDto.FromModel(result));
                }
            }

            return list;
        }

        // GET: api/UserDto/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<UserDto> Get(int id)
        {
            var result = _apiSepContext.Users.FirstOrDefault(p => p.Id == id);
            return result != null ? UserDto.FromModel(result) : null;
        }

        // POST api/UserDto  
        [HttpPost]
        public void Post([FromBody]UserDto UserDto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "userQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);



                var message = JsonSerializer.Serialize(UserDto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "userQueue",
                    basicProperties: null,
                    body: body);
            }
        }

        // PUT api/UserDto/5  
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto UserDto)
        {
            var result = _apiSepContext.Users.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                result.Username = UserDto.Username;
                result.Firstname = UserDto.Firstname;
                result.Lastname = UserDto.Lastname;
                result.DateOfBirth = UserDto.DateOfBirth;
                _apiSepContext.SaveChanges();
            }
        }

        // DELETE: api/UserDto/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var result = _apiSepContext.Users.FirstOrDefault(p => p.Id == id);
            if (result != null) _apiSepContext.Users.Remove(result);
            _apiSepContext.SaveChanges();
        }
    }
}
