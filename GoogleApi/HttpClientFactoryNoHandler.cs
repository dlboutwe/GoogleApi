using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GoogleApi;

/// <summary>
/// Provide a default global httpClient and a factory a factory method
/// </summary>
public static class HttpClientFactoryNoHandler
{
    /// <summary>
    /// Create Default Http Client.
    /// </summary>
    /// <returns>The <see cref="HttpClient"/>.</returns>
    public static HttpClient CreateDefaultHttpClient()
    {
        var httpClient = new HttpClient();

        HttpClientFactoryNoHandler.ConfigureDefaultHttpClient(httpClient);

        return httpClient;
    }

    /// <summary>
    /// Configure Default Http Client.
    /// </summary>
    /// <param name="httpClient"></param>
    public static void ConfigureDefaultHttpClient(HttpClient httpClient)
    {
        if (httpClient == null)
            throw new ArgumentNullException(nameof(httpClient));

        httpClient.Timeout = TimeSpan.FromSeconds(30);

        httpClient.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}