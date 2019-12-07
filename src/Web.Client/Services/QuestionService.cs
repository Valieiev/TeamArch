using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Shared;

namespace Web.Client.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly HttpClient _httpClient;

        public QuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<QuestionViewModel> Create(QuestionViewModel model)
        {
            return await _httpClient.PostJsonAsync<QuestionViewModel>($"api/Question/Create", model);
        }

        public async Task<QuestionList> GetQuestion(int usertaskId)
        {
            return await _httpClient.GetJsonAsync<QuestionList>($"api/Question/GetQuestion?usertaskId={usertaskId}");
        }
    }

    public interface IQuestionService
    {
        Task<QuestionList> GetQuestion(int usertaskId);
        Task<QuestionViewModel> Create(QuestionViewModel model);
    }
}
