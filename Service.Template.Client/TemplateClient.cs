using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Service.Template.Client.Dto;

namespace Service.Template.Client
{
    public class TemplateClient:ITemplateServiceClient

    {
        private const string SampleEndpoint = "sample";

        private readonly string baseAddress;

        public TemplateClient(string baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        public async Task<List<Sample>> ListAsync(CancellationToken cancellationToken)
        {
            return await Fetch<List<Sample>>($"{baseAddress}/{SampleEndpoint}", cancellationToken);
        }

        public async Task<Sample> GetAsync(long id, CancellationToken cancellationToken)
        {
            return await Fetch<Sample>($"{baseAddress}/{SampleEndpoint}/{id}", cancellationToken);
        }

        private static async Task<T> Fetch<T>(string address, CancellationToken cancellationToken)
        {
            var apiClient = new HttpClient();
            var response = await apiClient.GetAsync(address, cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}