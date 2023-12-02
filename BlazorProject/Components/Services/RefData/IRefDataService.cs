using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Components.Services.RefData;

public interface IRefDataService
{
    Task<JsonResult> GetContextsAsync();
}
