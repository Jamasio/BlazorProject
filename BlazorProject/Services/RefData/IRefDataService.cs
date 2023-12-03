﻿using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Services.RefData;

public interface IRefDataService
{
    Task<JsonResult> GetContextsAsync();

    Task<JsonResult> GetContextCategoriesAsync(string? contextKey);
}
