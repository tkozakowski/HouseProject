using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Materials.Command.Add
{
    public class AddMaterialCommand: IRequest<Result<Unit>>
    {
        public AddMaterialDto AddMaterialDto { get; set; }
        public IFormFile Photo { get; set; }
    }
}
