using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Gallery3WinForm
{
    public static class ServiceClient
    {
        //The below method creates a HttpClient object which requests a JSON string from the specific URL and deserialises it into a .Net obect i.e. List<string>
        internal async static Task<List<string>> GetArtistNamesAsync() //This method is internal so it is accessible to all methods in this project but not to other projects. async in this method header means that the web service is being called asyncronhronously meaning the client code calls the service and continues on rather than waiting for completion. 
        {
            using (HttpClient lcHttpClient = new HttpClient())//Create a HttpClient object
                return JsonConvert.DeserializeObject<List<string>> 
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/gallery/GetArtistNames/")); //Use the HttpClient object to request a JSON string from the specified URL and deserialize it into a .NET object. 'await' is used to suspend the the operation of the GetStringAsync method from here on untl the asynchronous call returns a result
        }

        internal async static Task<clsArtist> GetArtistAsync(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsArtist>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/gallery/GetArtist?Name=" + prArtistName));
        }

        internal async static Task<string> InsertArtistAsync(clsArtist prArtist)
        {
            return await InsertOrUpdateAsync(prArtist, "http://localhost:60064/api/gallery/PostArtist", "POST");
        }

        internal async static Task<string> UpdateArtistAsync(clsArtist prArtist)
        {
            return await InsertOrUpdateAsync(prArtist, "http://localhost:60064/api/gallery/PutArtist", "PUT");
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
