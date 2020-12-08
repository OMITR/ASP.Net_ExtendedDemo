using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsApiController : ControllerBase
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public ActorsApiController(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActorViewModel>))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ActorViewModel>> GetActors()
        {
            var actors = _mapper.Map<IEnumerable<Actor>, IEnumerable<ActorViewModel>>(_context.Actors.ToList());
            return Ok(actors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ActorViewModel))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var actor = _mapper.Map<ActorViewModel>(_context.Actors.FirstOrDefault(m => m.ActorId == id));
            if (actor == null) return NotFound();
            return Ok(actor);
        }

        [HttpPost]
        public ActionResult<InputActorViewModel> PostActor(InputActorViewModel inputModel)
        {

            var actor = _context.Add(_mapper.Map<Actor>(inputModel)).Entity;
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = actor.ActorId }, _mapper.Map<InputActorViewModel>(inputModel));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, EditActorViewModel editModel)
        {
            try
            {
                var actor = _mapper.Map<Actor>(editModel);
                actor.ActorId = id;

                _context.Update(actor);
                _context.SaveChanges();

                return Ok(_mapper.Map<EditActorViewModel>(actor));
            }
            catch (DbUpdateException)
            {
                if (!ActorExists(id))
                    return BadRequest();
                else
                    throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<DeleteMovieViewModel> DeleteMovie(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null) 
                return NotFound();
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            return Ok(_mapper.Map<DeleteMovieViewModel>(actor));
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.ActorId == id);
        }
    }
}
