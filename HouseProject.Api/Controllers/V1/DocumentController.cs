﻿using Api.Controllers;
using Application.Command.Documents;
using Application.Core.Paginations;
using Application.Core.Sortings;
using Application.Dto;
using Application.Queries.Documents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// SQL
/// </summary>
namespace Api.V1.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("1.0")]
    public class DocumentController : BaseApiController
    {
        /// <summary>
        /// Przykład wykorzystania paginacji, sortowania oraz filtrowania
        /// </summary>
        /// <param name="paginationFilters"></param>
        /// <param name="sortingFilter"></param>
        /// <param name="filterBy"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<DocumentDto>>> GetDocuments([FromQuery] PaginationFilter paginationFilters,
            [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilters.PageNumber, paginationFilters.PageSize);

            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            return HandleResult(await Mediator.Send(new GetDocumentListQuery(validPaginationFilter, validSortingFilter, filterBy)));
        }

        /// <summary>
        /// Zwraca listę pól, po których możemy sortować
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetSortFileds()
        {
            return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
        }

        /// <summary>
        /// Retrieves all documents in OData protocol
        /// </summary>
        /// <returns></returns>
        //[HttpGet("[action]")]
        //public IQueryable<DocumentDto> GetAll()
        //{

        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDto>> GetDocument(int id)
        {
            return HandleResult(await Mediator.Send(new GetDocumentByIdQuery(id)));
        }


        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentDto documentDto)
        {
            return HandleResult(await Mediator.Send(new InsertDocumentCommand(documentDto)));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] DocumentDto documentDto)
        {
            return HandleResult(await Mediator.Send(new UpdateDocumentCommand { DocumentDto = documentDto, Id = id }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            return HandleResult(await Mediator.Send(new RemoveDocumentCommand { Id = id }));
        }
    }
}
