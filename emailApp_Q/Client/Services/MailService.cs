using emailApp_Q.Client.Features;
using emailApp_Q.Shared;
using emailApp_Q.Shared.RequestFeatures;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace emailApp_Q.Client.Services
{
    public class MailService : IMailService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public MailService(HttpClient httpClient)
        {
            _client = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task CreateEmail(Mail mail)
        {
            var content = JsonSerializer.Serialize(mail);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PostAsync("api/Mail", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task<Mail> GetById(int mailId)
        {
            var response = await _client.GetAsync($"api/Mail/{mailId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var mail = JsonSerializer.Deserialize<Mail>(content, _options);
            return mail;
        }

        public async Task<List<Importance>> GetImportances()
        {
            var response = await _client.GetAsync("api/Importance");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var importances = JsonSerializer.Deserialize<List<Importance>>(content, _options);
            return importances;
        }

        public async Task<PagingResponse<Mail>> GetMails(MailParameters mailParameters)
        {
            var queryStringParam = new Dictionary<String, String>
            {
                ["pageNumber"] = mailParameters.PageNumber.ToString(),
                ["pageSize"] = mailParameters.PageSize.ToString(),
                ["searchTerm"] = mailParameters.SearchTerm == null ? "" : mailParameters.SearchTerm
            };

            var response = await _client.GetAsync(QueryHelpers.AddQueryString("api/Mail", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var pagingResponse = new PagingResponse<Mail>
            {
                Items = JsonSerializer.Deserialize<List<Mail>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            };

            return pagingResponse;
        }
    }
}
