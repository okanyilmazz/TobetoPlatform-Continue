﻿namespace Business.Dtos.Responses.MediaNewResponses;

public class DeletedMediaNewResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
}