﻿
namespace Business.Dtos.Responses.AccountActivityMapResponses;

public class CreatedAccountActivityMapResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid ActivityMapId { get; set; }
}

