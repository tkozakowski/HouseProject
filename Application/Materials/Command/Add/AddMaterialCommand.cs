using Application.Core;
using MediatR;

namespace Application.Materials.Command.Add
{
    public class AddMaterialCommand: IRequest<Result<Unit>>
    {
        public AddMaterialDto AddMaterialDto { get; set; }
    }
}
