using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Shared;

namespace Web.Client.Services
{
    public class TaskService : ITaskService
    {

        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TasksViewModel> Create(TasksViewModel model)
        {
            return await _httpClient.PostJsonAsync<TasksViewModel>($"api/Task/Create",model);
        }

        public async Task<TaskList> GetList()
        {
            return await _httpClient.GetJsonAsync<TaskList>($"api/Task/GetTasks"); 
        }


    }

    public interface ITaskService
    {
        Task<TaskList> GetList();
        Task<TasksViewModel> Create(TasksViewModel model);
    }
}
