using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Shared;

namespace Web.Client.Services
{
    public class CodePartService : ICodePartService
    {
        private readonly HttpClient _httpClient;

        public CodePartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CodePartViewModel> Create(CodePartViewModel model)
        {
            return await _httpClient.PostJsonAsync<CodePartViewModel>($"api/CodePart/Create", model);
        }

        public async Task<CodePartList> GetList()
        {
            return await _httpClient.GetJsonAsync<CodePartList>($"api/CodePart/GetList");
        }
    }
    public interface ICodePartService
    {
        Task<CodePartList> GetList();
        Task<CodePartViewModel> Create(CodePartViewModel model);
    }
}
