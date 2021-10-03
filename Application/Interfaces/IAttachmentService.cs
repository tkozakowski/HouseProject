using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAttachmentService
    {
        public Task RecoverFiles();

    }
}
