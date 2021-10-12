using Application.Mappings;
using AutoMapper;
using Domain.Entities.Cosmos;
using System;

namespace Application.CosmosDocuments.Command.Update
{
    public class UpdateCosmosDocumentDto: IMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public decimal? Cost { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int? SendTypeId { get; set; }
        public int? ProjectId { get; set; }
        public int? PreparationId { get; set; }
        public int? PostId { get; set; }
        public int? StageId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCosmosDocumentDto, CosmosDocument>();
        }
    }
}
