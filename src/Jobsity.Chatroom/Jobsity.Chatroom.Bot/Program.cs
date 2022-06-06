using Jobsity.Chatroom.Bot;
using Jobsity.Chatroom.Bot.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IChatroomClient, ChatroomClient>();
        services.AddSingleton<ICommandProcessor, CommandProcessor>();
        services.AddSingleton<IRabbitConsumer, RabbitConsumer>();
        services.AddSingleton<IStooqClient, StooqClient>();
        services.AddHttpClient();
    })
    .Build();

await host.RunAsync();
