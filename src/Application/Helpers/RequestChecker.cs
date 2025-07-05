using Refit;

namespace DefiSeeker.Shared;


public static class RequestChecker
{
    public static bool IsSuccessful<T>(this IApiResponse<T> response)
    {
        return response is not null && response.IsSuccessful && response.Content is not null;
    }
}