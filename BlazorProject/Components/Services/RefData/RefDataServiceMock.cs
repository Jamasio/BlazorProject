using BlazorProject.Components.Services.RefData.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Components.Services.RefData;

public class RefDataServiceMock : IRefDataService
{
    private List<ContextModel> contexts = new List<ContextModel>
    {
        new ContextModel { Key = "ProductA", Description = "This is context 1" },
        new ContextModel { Key = "ProductB", Description = "This is context 2" } 
    };

    private List<CategoryModel> categories = new List<CategoryModel>
    {
       new CategoryModel { Key = "Category1", Description = "This is category 1", ContextKey = "ProductA" },
       new CategoryModel { Key = "Category2", Description = "This is category 2", ContextKey = "ProductB" }
    };

    private List<ValueModel> values = new List<ValueModel>
    {
       new ValueModel { Key = "VALUE1", Value = "Value1", Description = "This is value 1", ContextKey = "ProductA", CategoryKey = "Category1" },
       new ValueModel { Key = "VALUE2", Value = "Value2", Description = "This is value 2", ContextKey = "ProductA", CategoryKey = "Category1" },
       new ValueModel { Key = "VALUE3", Value = "Value3", Description = "This is value 3", ContextKey = "ProductA", CategoryKey = "Category1" },
       new ValueModel { Key = "VALUE2", Value = "Value2", Description = "This is value 2", ContextKey = "ProductB", CategoryKey = "Category2" },
       new ValueModel { Key = "VALUE3", Value = "Value3", Description = "This is value 3", ContextKey = "ProductB", CategoryKey = "Category2" },
       new ValueModel { Key = "VALUE4", Value = "Value4", Description = "This is value 4", ContextKey = "ProductB", CategoryKey = "Category2" },
    };
    public Task<JsonResult> GetContextsAsync()
    {
        return Task.FromResult(new JsonResult(contexts));
    }
}
