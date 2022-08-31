using System;
using Microsoft.Extensions.DependencyInjection;

namespace GoogleApi.Extensions;

/// <summary>
/// Service Collection Extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="HttpEngine{TRequest,TResponse}"/> and related services to the <see cref="IServiceCollection"/> and configures
    /// a named <see cref="System.Net.Http.HttpClient"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <returns>An <see cref="IServiceCollection"/> that can be used to chain the extensions.</returns>
    /// <remarks>
    /// </remarks>
    public static IServiceCollection AddGoogleApiClients(this IServiceCollection services)
    {
        if (services == null) 
            throw new ArgumentNullException(nameof(services));

        services
            .AddHttpClient(nameof(GoogleApi), HttpClientFactory.ConfigureDefaultHttpClient)
            .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.GetDefaultHttpClientHandler());

        services
            .AddApi<GoogleMaps.DirectionsApi>()
            .AddApi<GoogleMaps.DistanceMatrixApi>()
            .AddApi<GoogleMaps.ElevationApi>()
            .AddApi<GoogleMaps.GeolocationApi>()
            .AddApi<GoogleMaps.Geocode.AddressGeocodeApi>()
            .AddApi<GoogleMaps.Geocode.LocationGeocodeApi>()
            .AddApi<GoogleMaps.Geocode.PlaceGeocodeApi>()
            .AddApi<GoogleMaps.Geocode.PlusCodeGeocodeApi>()
            .AddApi<GoogleMaps.Roads.SnapToRoadApi>()
            .AddApi<GoogleMaps.Roads.NearestRoadsApi>()
            .AddApi<GoogleMaps.Roads.SpeedLimitsApi>()
            .AddApi<GoogleMaps.StreetViewApi>()
            .AddApi<GoogleMaps.StaticMapsApi>()
            .AddApi<GoogleMaps.TimeZoneApi>();

        services
            .AddApi<GooglePlaces.DetailsApi>()
            .AddApi<GooglePlaces.PhotosApi>()
            .AddApi<GooglePlaces.AutoCompleteApi>()
            .AddApi<GooglePlaces.QueryAutoCompleteApi>()
            .AddApi<GooglePlaces.Search.FindSearchApi>()
            .AddApi<GooglePlaces.Search.NearBySearchApi>()
            .AddApi<GooglePlaces.Search.TextSearchApi>();

        services
            .AddApi<GoogleSearch.WebSearchApi>()
            .AddApi<GoogleSearch.ImageSearchApi>()
            .AddApi<GoogleSearch.VideoSearch.ChannelsApi>()
            .AddApi<GoogleSearch.VideoSearch.PlaylistsApi>()
            .AddApi<GoogleSearch.VideoSearch.VideosApi>();

        services
            .AddApi<GoogleTranslate.DetectApi>()
            .AddApi<GoogleTranslate.LanguagesApi>()
            .AddApi<GoogleTranslate.TranslateApi>();

        return services;
    }

    /// <summary>
    /// Adds the <see cref="HttpEngine{TRequest,TResponse}"/> and related services to the <see cref="IServiceCollection"/> and configures
    /// a named <see cref="System.Net.Http.HttpClient"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <returns>An <see cref="IServiceCollection"/> that can be used to chain the extensions.</returns>
    /// <remarks>
    /// </remarks>
    public static IServiceCollection AddGoogleApiClientsNoHandler(this IServiceCollection services)
    {
        if (services == null) 
            throw new ArgumentNullException(nameof(services));

        services
            .AddHttpClient(nameof(GoogleApi), HttpClientFactoryNoHandler.ConfigureDefaultHttpClient);

        services
            .AddApiNoHandler<GoogleMaps.DirectionsApi>()
            .AddApiNoHandler<GoogleMaps.DistanceMatrixApi>()
            .AddApiNoHandler<GoogleMaps.ElevationApi>()
            .AddApiNoHandler<GoogleMaps.GeolocationApi>()
            .AddApiNoHandler<GoogleMaps.Geocode.AddressGeocodeApi>()
            .AddApiNoHandler<GoogleMaps.Geocode.LocationGeocodeApi>()
            .AddApiNoHandler<GoogleMaps.Geocode.PlaceGeocodeApi>()
            .AddApiNoHandler<GoogleMaps.Geocode.PlusCodeGeocodeApi>()
            .AddApiNoHandler<GoogleMaps.Roads.SnapToRoadApi>()
            .AddApiNoHandler<GoogleMaps.Roads.NearestRoadsApi>()
            .AddApiNoHandler<GoogleMaps.Roads.SpeedLimitsApi>()
            .AddApiNoHandler<GoogleMaps.StreetViewApi>()
            .AddApiNoHandler<GoogleMaps.StaticMapsApi>()
            .AddApiNoHandler<GoogleMaps.TimeZoneApi>();

        services
            .AddApiNoHandler<GooglePlaces.DetailsApi>()
            .AddApiNoHandler<GooglePlaces.PhotosApi>()
            .AddApiNoHandler<GooglePlaces.AutoCompleteApi>()
            .AddApiNoHandler<GooglePlaces.QueryAutoCompleteApi>()
            .AddApiNoHandler<GooglePlaces.Search.FindSearchApi>()
            .AddApiNoHandler<GooglePlaces.Search.NearBySearchApi>()
            .AddApiNoHandler<GooglePlaces.Search.TextSearchApi>();

        services
            .AddApiNoHandler<GoogleSearch.WebSearchApi>()
            .AddApiNoHandler<GoogleSearch.ImageSearchApi>()
            .AddApiNoHandler<GoogleSearch.VideoSearch.ChannelsApi>()
            .AddApiNoHandler<GoogleSearch.VideoSearch.PlaylistsApi>()
            .AddApiNoHandler<GoogleSearch.VideoSearch.VideosApi>();

        services
            .AddApiNoHandler<GoogleTranslate.DetectApi>()
            .AddApiNoHandler<GoogleTranslate.LanguagesApi>()
            .AddApiNoHandler<GoogleTranslate.TranslateApi>();

        return services;
    }

    private static IServiceCollection AddApi<TClient>(this IServiceCollection services)
        where TClient : class
    {
        services
            .AddHttpClient<TClient>(HttpClientFactory.ConfigureDefaultHttpClient)
            .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.GetDefaultHttpClientHandler())
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));

        return services;
    }
    private static IServiceCollection AddApiNoHandler<TClient>(this IServiceCollection services)
        where TClient : class
    {
        services
            .AddHttpClient<TClient>(HttpClientFactory.ConfigureDefaultHttpClient)
            .ConfigurePrimaryHttpMessageHandler(() => null);

        return services;
    }
}