using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById

{
    public class GetPetByIdUseCase
    {

        public ResponsePetJson Execute(int id)
        {
            return new ResponsePetJson
            {
                Id = id,
                Name = "Fido",
                Birthday = new DateTime(year: 2023, month: 10, day: 1),
                Type = Communication.Enums.PetType.Dog,
           
            };
        }
    }
}
    