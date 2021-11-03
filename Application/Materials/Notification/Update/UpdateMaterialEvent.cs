using MediatR;

namespace Application.Materials.Notification.Update
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
