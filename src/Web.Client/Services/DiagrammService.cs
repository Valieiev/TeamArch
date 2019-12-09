using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Shared;

namespace Web.Client.Services
{
    public class DiagrammService : IDiagrammService
    {
        private readonly HttpClient _httpClient;

        public DiagrammService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DiagrammViewModel> Create(DiagrammViewModel model)
        {
            return await _httpClient.PostJsonAsync<DiagrammViewModel>($"api/Diagramm/Create", model);
        }

        public async Task<DiagrammViewModel> GetDiagramm(int id)
        {
            return await _httpClient.GetJsonAsync<DiagrammViewModel>($"api/Diagramm/GetDiagramm?id={id}");
        }

        public async Task<DiagrammList> GetDiagrammList(int usertaskId)
        {
            return await _httpClient.GetJsonAsync<DiagrammList>($"api/Diagramm/GetDiagrammList?usertaskId={usertaskId}");
        }
    }

    public interface IDiagrammService
    {
        Task<DiagrammList> GetDiagrammList(int usertaskId);
        Task<DiagrammViewModel> GetDiagramm(int id);
        Task<DiagrammViewModel> Create(DiagrammViewModel model);
    }
}
