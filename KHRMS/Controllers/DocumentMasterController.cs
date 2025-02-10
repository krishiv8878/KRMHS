using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace KHRMS
{

    /// <summary>
    /// API Controller for managing Employee Documents Information.
    /// Provides endpoints to Create, Read, Update, and Delete employee documents records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentMasterController(IDocumentMasterService documentMasterService) : ControllerBase

    {
        private readonly IDocumentMasterService _documentMasterService = documentMasterService;

        [HttpGet("GetAllDocumentsInfo")]
        public async Task<ActionResult<IEnumerable<DocumentMaster>>> GetAll()
        {
            var documents = await _documentMasterService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<DocumentMaster>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee Documents information retrieved successfully.",
                Data = documents
            });
        }

        /// <summary>
        /// Retrieves employee document information by ID.
        /// </summary>
        /// <param name="id">Employee Document Info ID</param>

        [HttpGet("GetDocumentInfoProfileById/{id}")]
        public async Task<ActionResult<DocumentMaster>> GetById(long id)
        {
            var document = await _documentMasterService.GetByIdAsync(id);
            if (document == null)
            {
                return NotFound(new ApiResponse<DocumentMaster>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Employee document information not found.",
                    Data = null
                });
            }
            return Ok(new ApiResponse<DocumentMaster>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee document information retrieved successfully.",
                Data = document
            });
        }

        /// <summary>
        /// Creates a new employee document information record.
        /// </summary>
        /// <param name="entity">Employee Document Info object</param>

        [HttpPost("CreateDocumentInfo")]
        public async Task<ActionResult> Create([FromBody] DocumentMaster document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Invalid data.",
                    Data = false
                });
            }
            await _documentMasterService.AddAsync(document);
            return CreatedAtAction(nameof(GetById), new { id = document.Id }, document);
        }




        [HttpPut("UpdateDocumentInfo/{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] DocumentMaster document)
        {          
            if (!ModelState.IsValid || id != document.Id)
            {
                return BadRequest(new ApiResponse<bool>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Invalid data.",
                    Data = false
                });
            }
            await _documentMasterService.UpdateAsync(document);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee document information updated successfully.",
                Data = true
            });
        }

        /// <summary>
        /// Deletes an employee payment information record by ID.
        /// </summary>
        /// <param name="id">Employee Payment Info ID</param>

        [HttpDelete("DeleteDocumenttInfo/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _documentMasterService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee document information deleted successfully.",
                Data = true
            });
        }
      
    }
}



