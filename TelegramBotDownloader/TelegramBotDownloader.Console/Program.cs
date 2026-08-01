using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string? botToken = config["TelegramBotToken"];
const string url =
    "https://nl202.cdnsqu.com/s/FHLOdY7fV6PzRp8Z_EFUFAWUFBQUFBQUFBQUFBUlZTUmdBUG9BSzRqbTBDdUk1dEJE.Q_S9b8G6jyRnDswkuzTrVM-Am2fKpnuBX4u8og/mr.robot.lostfilm-nf19/s01e03_720.mp4";

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
    await SendVideoFromDirectUrl(bot, message.Chat.Id, url);
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