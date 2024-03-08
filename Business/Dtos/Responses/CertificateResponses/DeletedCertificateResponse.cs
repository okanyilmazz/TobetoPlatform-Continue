namespace Business.Dtos.Responses.CertificateResponses
{
    public class DeletedCertificateResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FolderPath { get; set; }
    }
}