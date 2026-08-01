using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotDownloader.Infrastructure.Facades;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string? botToken = config["TelegramBotToken"];
const string pageUrl = "https://rezka.ag/films/action/3079-besslavnye-ublyudki-2009-latest.html";

if (string.IsNullOrEmpty(botToken))
    throw new InvalidOperationException("Telegram Bot Token not set");

var bot = new TelegramBotClient(new TelegramBotClientOptions(
    token: botToken,
    baseUrl: "http://localhost:8081"
));

bot.OnMessage += OnMessage;
Console.WriteLine("Press any key to exit...");
Console.ReadLine();

async Task OnMessage(Message message, UpdateType type)
{
    try
    {
        var filmParserFacade = new RezkaFilmParserFacade();
        string url = await filmParserFacade.GetFilmSrc(pageUrl, "360p");

        Console.WriteLine(url);

        await SendVideoFromDirectUrl(bot, message.Chat.Id, url);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

async Task SendVideoFromDirectUrl(ITelegramBotClient botClient, long chatId, string videoUrl, string caption = "")
{
    using var httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(30) };

    using var response = await httpClient.GetAsync(videoUrl, HttpCompletionOption.ResponseHeadersRead);
    response.EnsureSuccessStatusCode();

    await using var stream = await response.Content.ReadAsStreamAsync();

    var inputFile = InputFile.FromStream(stream, "video.mp4");

    await botClient.SendVideo(
        chatId: chatId,
        video: inputFile,
        caption: caption,
        supportsStreaming: true
    );
}