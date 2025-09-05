using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using OxVidco.Models;
using System.Diagnostics;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Linq;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace OxVidco.Services
{
    public class UpdateService
    {
        // Ganti dengan ID file update.json di Google Drive
        private const string UpdateFileId = "YOUR_GOOGLE_DRIVE_FILE_ID";
        private const string UpdateUrl = $"https://drive.google.com/uc?export=download&id={UpdateFileId}";
        private readonly HttpClient _httpClient;
        private readonly CookieContainer _cookies = new CookieContainer();
        private readonly HttpClientHandler _handler;

        public UpdateService()
        {
            _handler = new HttpClientHandler
            {
                CookieContainer = _cookies,
                UseCookies = true,
                AllowAutoRedirect = true
            };
            
            _httpClient = new HttpClient(_handler);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        }

        public async Task<UpdateInfo?> CheckForUpdatesAsync(Version currentVersion)
        {
            try
            {
                // Coba baca dari file lokal terlebih dahulu
                var localJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update.json");
                if (File.Exists(localJsonPath))
                {
                    var json = await File.ReadAllTextAsync(localJsonPath);
                    if (!string.IsNullOrEmpty(json))
                    {
                        var updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(json);
                        return updateInfo?.Version != null && updateInfo.Version > currentVersion ? updateInfo : null;
                    }
                }

                // Jika tidak ada file lokal, coba download dari Google Drive
                // Hanya jika UpdateFileId sudah diatur dengan benar
                if (!string.IsNullOrEmpty(UpdateFileId) && UpdateFileId != "YOUR_GOOGLE_DRIVE_FILE_ID")
                {
                    try 
                    {
                        var json = await DownloadFileFromGoogleDrive(UpdateFileId);
                        if (!string.IsNullOrEmpty(json))
                        {
                            var updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(json);
                            return updateInfo?.Version != null && updateInfo.Version > currentVersion ? updateInfo : null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Gagal memeriksa pembaruan dari Google Drive: {ex.Message}");
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                // Log error
                Debug.WriteLine($"Error checking for updates: {ex.Message}");
                return null;
            }
        }

        private async Task<string> DownloadFileFromGoogleDrive(string fileId)
        {
            var url = $"https://drive.google.com/uc?export=download&id={fileId}";
            
            using var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            
            // Cek jika ada warning page
            var content = await response.Content.ReadAsStringAsync();
            if (content.Contains("Virus scan warning"))
            {
                // Handle virus scan warning
                var doc = new HtmlDocument();
                doc.LoadHtml(content);
                var form = doc.DocumentNode.SelectSingleNode("//form[@id='download-form']");
                if (true)
                {
                    var action = form.GetAttributeValue("action", "");
                    if (!string.IsNullOrEmpty(action))
                    {
                        // Dapatkan cookies dari response sebelumnya
                        var cookies = _handler.CookieContainer.GetCookies(new Uri("https://drive.google.com"));
                        
                        // Buat request baru dengan cookies
                        using var request = new HttpRequestMessage(HttpMethod.Get, action);
                        request.Headers.Add("Cookie", string.Join("; ", cookies.Select(c => $"{c.Name}={c.Value}")));
                        
                        using var newResponse = await _httpClient.SendAsync(request);
                        newResponse.EnsureSuccessStatusCode();
                        return await newResponse.Content.ReadAsStringAsync();
                    }
                }
            }
            
            return content;
        }
    }
}
