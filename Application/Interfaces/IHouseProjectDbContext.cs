using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHouseProjectDbContext
    {
        DbSet<Attachment> Attachments { get; set; }
        DbSet<AttachmentBackup> AttachmentsBackup { get; set; }
        DbSet<Domain.Entities.Document> Documents { get; set; }
        DbSet<Execution> Executions { get; set; }
        DbSet<Finance> Finances { get; set; }
        DbSet<LoanTranche> LoanTranches { get; set; }
        DbSet<Material> Materials { get; set; }
        DbSet<PaymentType> PaymentTypes { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Preparation> Preparations { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<SendApplication> SendApplications { get; set; }
        DbSet<SendType> SendTypes { get; set; }
        DbSet<Stage> Stages { get; set; }
        DbSet<WorkStage> WorkStages { get; set; }

        Task<int> SaveChangesAsync();
    }
}