﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSep.Dal.Entities;
using ApiSep.Library.Models.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace ApiSep.Ui.Form.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private ApiSepEntities ApiSepContext { get; } = new ApiSepEntities();
        
        // GET api/users/5  
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            var result = ApiSepContext.Users.FirstOrDefault(p => p.Id == id);
            return result != null ? UserDto.FromModel(result) : null;
        }

        // POST api/users  
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

                string message = "Username: " + UserDto.Username + ", Firstname: " + UserDto.Firstname + ", Lastname: " + UserDto.Lastname;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "userQueue",
                    basicProperties: null,
                    body: body);
            }
        }

        // PUT api/user/5  
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto UserDto)
        {
            var result = ApiSepContext.Users.FirstOrDefault(p => p.Id == UserDto.Id);
            if (result != null)
            {
                result.Username = UserDto.Username;
                result.Firstname = UserDto.Firstname;
                result.Lastname = UserDto.Lastname;
                result.DateOfBirth = UserDto.DateOfBirth;
                ApiSepContext.SaveChanges();
            }
        }

        // DELETE api/users/5  
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var result = ApiSepContext.Users.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                ApiSepContext.Users.Remove(result);
                ApiSepContext.SaveChanges();
            }
        }

        
    }
}
