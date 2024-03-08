using System;
namespace Business.Dtos.Requests.AccountActivityMapRequests
{
	public class UpdateAccountActivityMapRequest
	{
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid ActivityMapId { get; set; }
    }
}

