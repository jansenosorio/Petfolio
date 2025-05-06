using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetAll
{
    public class GetAllPetsUseCase
    {
        public ResponseAllPetJson Execute()
        {
            return new ResponseAllPetJson
            {
                Pets =
                [
                    new() {
                        Id = 1,
                        Name = "Fido",
                        Type = Communication.Enums.PetType.Dog
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "Jansen",
                        Type = Communication.Enums.PetType.Dog
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "Osório",
                        Type = Communication.Enums.PetType.Cat
                    },

                ]
            };
        }
    }
}
