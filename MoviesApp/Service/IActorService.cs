using MoviesApp.Service.DTO.Mappers;
using System.Collections.Generic;

namespace MoviesApp.Service
{
    public interface IActorService
    {
        ActorDto GetActor(int actorId);
        IEnumerable<ActorDto> GetAllActors();
        ActorDto UpdateActor(ActorDto actorDto);
        ActorDto AddActor(ActorDto acttorDto);
        ActorDto DeleteActor(int id);
    }
}
