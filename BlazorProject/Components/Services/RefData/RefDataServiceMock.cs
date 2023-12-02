using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Components.Services.RefData;

public class RefDataServiceMock : IRefDataService
{
    public Task<JsonResult> GetContextsAsync()
    {
        return null;
    }
}
