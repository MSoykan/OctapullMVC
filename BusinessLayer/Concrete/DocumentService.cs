using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.Dtos.DocumentDtos;
using EntityLayer.Dtos.DocumentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class DocumentService : IDocumentService {

        private readonly IDocumentRepository documentRepository;
        private readonly IMapper mapper;

        public DocumentService(IDocumentRepository documentRepository, IMapper mapper) {
            this.documentRepository = documentRepository;
            this.mapper = mapper;
        }

        public async Task AddDocument(CreateDocumentDto createDocumentDto) {
            var value = mapper.Map<Document>(createDocumentDto);
            await documentRepository.AddAsync(value);
        }

        public async Task DeleteDocumentById(int documentId) {
            await documentRepository.DeleteAsync(u => u.Id == documentId);
        }

        public async Task<ResultDocumentDto> GetDocumentById(int documentId) {
            var document = await documentRepository.GetAsync(u => u.Id == documentId);
            return mapper.Map<ResultDocumentDto>(document);
        }

        public async Task<List<Document>> GetDocumentList() { // TO DO : CHange return type to result document dto
            return await documentRepository.ListAsync(b => true);
        }

        public async Task UpdateDocument(UpdateDocumentDto updateDocumentDto) {
            var document = mapper.Map<Document>(updateDocumentDto);
            await documentRepository.UpdateAsync(document);
        }
    }
}
