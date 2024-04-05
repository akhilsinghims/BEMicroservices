using BE.MVC.Models.DTO;
using Newtonsoft.Json;

namespace BE.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task Transfer(TransferDto transferDto)
        {

            //Banking
            //https://localhost:44344/

            var uri = "https://localhost:44344/api/banking";
            var transferContent=new StringContent(JsonConvert.SerializeObject(transferDto),
                System.Text.Encoding.UTF8,"application/json");

            var response=await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();


            //Transfer
            //https://localhost:7112
        }
    }
}
