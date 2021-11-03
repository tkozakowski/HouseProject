using MediatR;

namespace Application.Materials.Notification.Add
{
    public class AddMaterialEvent : INotification
    {
        public AddMaterialEvent(int id)
        {
            ExecutionId = id;
        }
        public int ExecutionId { get; set; }

    }
}
