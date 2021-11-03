using Application.Executions.Command.Update;
using MediatR;

namespace Application.Materials.Command.Add
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
