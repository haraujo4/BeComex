using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interface.Services;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoboController : ControllerBase
    {
        private readonly IRoboActionServices _services;
        public RoboController(IRoboActionServices services)
        {
            _services = services;
        }
        
        [HttpGet]
        public IEnumerable<Robo> GetRoboPosition()
        {
            var result = _services.GetRoboAction();
            return result;
        }
        
        [HttpPost]
        public async Task<bool> SendAction([FromBody] RoboDTO action, int LastActionOrder, string lastAction)
        {
            var result = await _services.SendAction(action, LastActionOrder, lastAction);
            return result;
        }
        
    }
}