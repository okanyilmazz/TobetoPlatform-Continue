using Entities.Concretes;

namespace Business.Dtos.Responses.CertificateResponses
{
    public class CreatedCertificateResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FolderPath { get; set; }

    }
}