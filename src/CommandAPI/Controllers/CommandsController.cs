
using System.Collections.Generic;
using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase{


        private readonly ICommandAPIRepo _repository;

        public CommandsController(ICommandAPIRepo repository){
            _repository =  repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands(){
                
            //return new string[] {"this", "is", "hard", "coded"};

            var CommandItems = _repository.GetAllCommands();

            if( CommandItems == null){
                return NotFound();
            }

            return Ok(CommandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Command>> GetCommandById(int id)
        {
                
            //return new string[] {"this", "is", "hard", "coded"};

            var CommandItems = _repository.GetCommandById(id);

            if( CommandItems == null)
            {
                return NotFound();
            }

            return Ok(CommandItems);
        }

    }
}