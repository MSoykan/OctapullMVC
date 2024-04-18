using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Dtos.DocumentDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OctapullAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase {

        private readonly IDocumentService documentService;
        IMapper mapper;

        public DocumentController(IDocumentService documentService, IMapper mapper) {
            this.documentService = documentService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> DocumentList() {
            var values = await documentService.GetDocumentList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(int id) {
            var values = await documentService.GetDocumentById(id);
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDocumentById(int id) {
            await documentService.DeleteDocumentById(id);
            return Ok("Document with id " + id + " has been deleted succesfully");
        }
        [HttpPost]
        public async Task<IActionResult> AddDocument(CreateDocumentDto createDocumentDto) {
            await documentService.AddDocument(createDocumentDto);
            return Ok("Document has been added succesfully.Document Added: \n" + createDocumentDto.ToString());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDocument(UpdateDocumentDto updateDocumentDto) {
            await documentService.UpdateDocument(updateDocumentDto);
            return Ok("Document with id " + updateDocumentDto.Id + " has been updated succesfully. New use: " + updateDocumentDto.ToString());
        }
    }
}
