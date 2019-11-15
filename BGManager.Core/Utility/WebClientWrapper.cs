using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BGManager.Core.Utility
{
    public interface IWebClient
    {
        string DownloadString(string url);
    }

    public class WebClientWrapper : IWebClient
    {
        public string DownloadString(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadString(url);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving data from URL. Error: {ex.Message}");
            }
        }
    }
}
