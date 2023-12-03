using BlazorProject.Services.RefData.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Services.RefData;

public interface IRefDataService
{
    Task<JsonResult> GetContextsAsync();

    Task<JsonResult> GetContextCategoriesAsync(string? contextKey);

    Task<JsonResult> GetValuesAsync(string? contextKey, string? categoryKey);

    Task<bool> EditContextAsync(ContextModel? updatedContext); 
}
