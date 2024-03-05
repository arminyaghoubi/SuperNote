using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace SuperNote.WebApi.Endpoints.Notes.GetAll;

public class GetAllNoteRequest
{
    [FromRoute]
    [DefaultValue(1)]
    public int PageNumber { get; set; }
    [FromRoute]
    [DefaultValue(15)]
    public int PageSize { get; set; }
}
