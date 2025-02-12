using KHRMS.Core;
using KHRMS.Infrastructure;
using KHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace KHRMS
{

    /// <summary>
    /// API Controller for managing Employee Documents Information.
    /// Provides endpoints to Create, Read, Update, and Delete employee documents records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDocumentController(IEmployeeDocumentService employeeDocumentService) : ControllerBase

    {
        private readonly IEmployeeDocumentService _employeeDocumentService = employeeDocumentService;
        private readonly List<string> _allowedExtensions = new List<string> { ".doc", ".docx", ".xaml" };

        [HttpGet("GetAllDocumentsInfo")]
        public async Task<ActionResult<IEnumerable<EmployeeDocumentInfo>>> GetAll()
        {
            var documents = await _employeeDocumentService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<EmployeeDocumentInfo>>
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

        [HttpGet("GetDocument/{id}")]
        public async Task<ActionResult<EmployeeDocumentInfo>> GetDocument(long id)
        {
            var document = await _employeeDocumentService.GetByIdAsync(id);
            if (document == null)
            {
                return NotFound(new ApiResponse<EmployeeDocumentInfo>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Document not found.",
                    Data = null
                });
            }
            return Ok(new ApiResponse<EmployeeDocumentInfo>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Employee document information retrieved successfully.",
                Data = document
            });
        }



        /// <summary>
        /// Creates a new employee payment information record.
        /// </summary>
        /// <param name="document">Employee Document Info object</param>
        [HttpPost("CreateDocument")]
        public async Task<ActionResult> Create([FromBody] EmployeeDocumentInfo document)
        {
            if (document == null)
                return BadRequest("Invalid document data.");
            // Validate file extension
            if (!_allowedExtensions.Contains(document.DocumentExtension.ToLower()))
            {
                return BadRequest("Only .docx, .doc, and .xaml .pdf files are allowed.");
            }
            // Validate Base64 content is not empty
            if (document.DocumentContent == null || document.DocumentContent.Length == 0)
            {
                return BadRequest("Document content cannot be empty.");
            }
            await _employeeDocumentService.AddAsync(document);
            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
        }




        /// <summary>
        /// Deletes an employee payment information record by ID.
        /// </summary>
        /// <param name="id">Employee Payment Info ID</param>     
        /// 
        [HttpDelete("DeleteDocument/{id}")]
        public async Task<ActionResult> DeleteDocument(long id)
        {
            var document = await _employeeDocumentService.GetByIdAsync(id);
            if (document == null)
                return NotFound();

            await _employeeDocumentService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Document deleted successfully.",
                Data = true
            });
        }
    }
}



