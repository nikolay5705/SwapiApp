using SWAPI.Models;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;

namespace SWAPI.Services.Peoples
{
    public interface IPeopleService
    {
        public Task<List<PersonDto>> GetPeopleAsync();
    }
}
