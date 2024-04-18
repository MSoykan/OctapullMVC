using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class DocumentService : IDocumentService {
        public Task AddDocument(Document document) {
            throw new NotImplementedException();
        }

        public Task DeleteDocument(int documentId) {
            throw new NotImplementedException();
        }

        public Task<Document> GetDocumentById(int documentId) {
            throw new NotImplementedException();
        }

        public Task<List<Document>> GetDocumentList() {
            throw new NotImplementedException();
        }

        public Task UpdateDocument(Document document) {
            throw new NotImplementedException();
        }
    }
}
