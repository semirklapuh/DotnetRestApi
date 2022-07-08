using System.Collections.Generic;
using netCoreCourse.Data;
using netCoreCourse.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using netCoreCourse.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace netCoreCourse.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly INetRepo _repository;
        public readonly IMapper _mapper;

        public CommandsController(INetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Command>> getAllCommands()
        {
            var commandItems = _repository.getAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "getCommandById")]
        public ActionResult<CommandReadDto> getCommandById(int id)
        {
            var commandItem = _repository.getCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }


        [HttpPost]
        public ActionResult<CommandReadDto> createCommand(CommandCreateDto cmd)
        {
            var commandModel = _mapper.Map<Command>(cmd);

            _repository.createCommand(commandModel);

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(getCommandById), new { Id = commandReadDto.Id }, commandReadDto);

            //return Ok(commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult updateCommand(int id, CommandUpdateDto cmd)
        {
            var commandModelRepo = _repository.getCommandById(id);
            if (commandModelRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(cmd, commandModelRepo);

            _repository.updateCommand(commandModelRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult partialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelRepo = _repository.getCommandById(id);
            if (commandModelRepo == null)
            {
                return NotFound();
            }

            var commandToPatc = _mapper.Map<CommandUpdateDto>(commandModelRepo);

            patchDoc.ApplyTo(commandToPatc, ModelState);
            if (!TryValidateModel(commandToPatc))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatc, commandModelRepo);

            _repository.updateCommand(commandModelRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult deleteCommand(int id)
        { 
            var commandModelRepo = _repository.getCommandById(id);
            if (commandModelRepo == null)
            {
                return NotFound();
            }
            
            _repository.deleteCommand(commandModelRepo);

            return NoContent();
        }

    }
}