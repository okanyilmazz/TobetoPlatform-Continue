using System;
namespace Business.Dtos.Requests.AccountActivityMapRequests
{
	public class CreateAccountActivityMapRequest
	{
        public Guid AccountId { get; set; }
        public Guid ActivityMapId { get; set; }
    }
}

