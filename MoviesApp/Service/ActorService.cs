using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Service.DTO.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApp.Service
{
    public class ActorService : IActorService
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public ActorService(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDto AddActor(ActorDto actorDto)
        {
            var actor = _context.Add(_mapper.Map<Actor>(actorDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<ActorDto>(actor);
        }

        public ActorDto DeleteActor(int actorId)
        {
            var actor = _context.Actors.Find(actorId);
            if (actor == null)
            {
                return null;
            }

            _context.Actors.Remove(actor);
            _context.SaveChanges();

            return _mapper.Map<ActorDto>(actor);
        }

        public ActorDto GetActor(int actorId)
        {
            return _mapper.Map<ActorDto>(_context.Actors.FirstOrDefault(m => m.ActorId == actorId));
        }

        public IEnumerable<ActorDto> GetAllActors()
        {
            return _mapper.Map<IEnumerable<Actor>, IEnumerable<ActorDto>>(_context.Actors.ToList());
        }

        public ActorDto UpdateActor(ActorDto actorDto)
        {
            if (actorDto.ActorId == null)
            {
                return null;
            }

            try
            {
                var actor = _mapper.Map<Actor>(actorDto);

                _context.Update(actor);
                _context.SaveChanges();

                return _mapper.Map<ActorDto>(actor);
            }
            catch(DbUpdateException)
            {
                if(!ActorExists((int) actorDto.ActorId))
                    return null;
                else
                    return null;
            }
        }

        private bool ActorExists(int actorId)
        {
            return _context.Actors.Any(e => e.ActorId == actorId);
        }
    }
}
