using EntityLayer.Concrete;
using EntityLayer.Dtos.DocumentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract {
    public interface IDocumentService {
        Task AddDocument(CreateDocumentDto createDocumentDto);
        Task UpdateDocument(UpdateDocumentDto updateDocumentDto);
        Task DeleteDocumentById(int documentId);
        Task<ResultDocumentDto> GetDocumentById(int documentId);
        Task<List<Document>> GetDocumentList();
    }
}
