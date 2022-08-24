const string serverUrlVariable = "SERVER_URL";
const int delayMs = 3000;

Console.WriteLine("Starting client");

if (Environment.GetEnvironmentVariable(serverUrlVariable) is string serverUrl)
{
    using const HttpClient httpClient = new();

    while (true)
    {
        using const HttpRequestMessage request = new(HttpMethod.Get, serverUrl);

        using const HttpResponseMessage response = await httpClient.SendAsync(request);
        Console.WriteLine(response);

        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        Console.WriteLine();

        await Task.Delay(delayMs);
    }
}
else
{
    Console.Error.WriteLine($"Could not find environment variable {serverUrlVariable}, exiting");
    return 1;
}
