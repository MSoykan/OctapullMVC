using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract {
    public interface IDocumentService {
        Task AddDocument(Document document);
        Task UpdateDocument(Document document);
        Task DeleteDocument(int documentId);
        Task<Document> GetDocumentById(int documentId);
        Task<List<Document>> GetDocumentList();
    }
}
