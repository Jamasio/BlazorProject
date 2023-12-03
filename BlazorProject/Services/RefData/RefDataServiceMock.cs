using BlazorProject.Services.RefData.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Services.RefData;

public class RefDataServiceMock : IRefDataService
{
    private static List<ContextModel> contexts = new List<ContextModel>
    {
        new ContextModel { Key = "ProductA", Description = "This is context 1" },
        new ContextModel { Key = "ProductB", Description = "This is context 2" }
    };

    private static List<CategoryModel> categories = new List<CategoryModel>
    {
       new CategoryModel { Key = "Category1", Description = "This is category 1", ContextKey = "ProductA" },
       new CategoryModel { Key = "Category2", Description = "This is category 2", ContextKey = "ProductB" }
    };

    private static List<ValueModel> values = new List<ValueModel>
    {
       new ValueModel { Key = "VALUE1", Value = "Value1", Description = "This is value 1", ContextKey = "ProductA", CategoryKey = "Category1" },
       new ValueModel { Key = "VALUE2", Value = "Value2", Description = "This is value 2", ContextKey = "ProductA", CategoryKey = "Category1" },
       new ValueModel { Key = "VALUE3", Value = "Value3", Description = "This is value 3", ContextKey = "ProductA", CategoryKey = "Category1" },
       new ValueModel { Key = "VALUE2", Value = "Value2", Description = "This is value 2", ContextKey = "ProductB", CategoryKey = "Category2" },
       new ValueModel { Key = "VALUE3", Value = "Value3", Description = "This is value 3", ContextKey = "ProductB", CategoryKey = "Category2" },
       new ValueModel { Key = "VALUE4", Value = "Value4", Description = "This is value 4", ContextKey = "ProductB", CategoryKey = "Category2" },
    };

    #region Contexts
    public Task<JsonResult> GetContextsAsync()
    {
        return Task.FromResult(new JsonResult(contexts));
    }
    public Task<bool> EditContextAsync(ContextModel? updatedContext)
    {
        var existingContext = contexts.FirstOrDefault( c => c.Key == updatedContext?.Key );
        
        if (existingContext != null )
        {
            existingContext.Description = updatedContext?.Description;
        }
        return Task.FromResult(existingContext != null);
    }
    #endregion

    #region Categories
    public Task<JsonResult> GetContextCategoriesAsync(string? contextKey)
    {
        var matchedCategories = categories.Where( k => k.ContextKey == contextKey).ToList();

        return Task.FromResult(new JsonResult(matchedCategories));
    }
    #endregion

    #region Values
    public Task<JsonResult> GetValuesAsync(string? contextKey, string? categoryKey)
    {
        var matchedValues = values.Where( v => v.ContextKey == contextKey && v.CategoryKey == categoryKey ).ToList();

        return Task.FromResult(new JsonResult(matchedValues));
    }
    #endregion
}
