﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TanksRebirth.Net;

namespace TanksRebirth.Internals.Common.Utilities;

public static class WebUtils {
    private static HttpClient _client = new(new HttpClientHandler { SslProtocols = SslProtocols.Tls12 });

    public static byte[] DownloadWebFile(string url, out string fileName)
    {
        var data = m_DownloadWebFile(url).GetAwaiter().GetResult();

        fileName = data.Item2;
        return data.Item1;
    }
    private static async Task<(byte[], string)> m_DownloadWebFile(string url)
    {
        var file = await _client.GetByteArrayAsync(url);

        // GameHandler.ClientLog.Write($"WebRequest sent to '{url}'", LogType.Debug); make a logger.. of course.

        var name = System.IO.Path.GetFileName(url).Split('?')[0];

        return (file, name);
    }

    public static async Task<bool> RemoteFileExistsAsync(string url)
    {
        var request = new HttpRequestMessage
        {
                Method = HttpMethod.Head,
                RequestUri = new(url),
        };
        
        var response = await _client.SendAsync(request);
        
        return response.StatusCode is HttpStatusCode.OK;
    }
    
    public static bool RemoteFileExists(string url)
    {
        try 
        {
            return RemoteFileExistsAsync(url).GetAwaiter().GetResult();
        }
        catch
        {
            return false;
        }
    }
}
