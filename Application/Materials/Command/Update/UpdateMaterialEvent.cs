using MediatR;

namespace Application.Materials.Command.Update
{
    public class UpdateMaterialEvent: INotification
    {
        public int MaterialId { get; set; }

        public UpdateMaterialEvent(int materialId)
        {
            MaterialId = materialId;
        }
    }
}
