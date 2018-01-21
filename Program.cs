using BotTools;
using BotTools.Handlers;
using JsonConfig;
using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.Threading;
using Crux.Config;
using BotTools.Utils;
using Crux.Commands;

namespace CruxBot
{
    public interface IDependencyMap
    {
        void Add<T>(T obj) where T : class;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        internal static CommandHandler handler;
        internal static DiscordSocketClient client;
        internal static CancellationTokenSource cancelSrc = new CancellationTokenSource();

        public async Task MainAsync()
        {
            Permissions.Load();

            client = new DiscordSocketClient();

            handler = new CommandHandler(client, ";;");

            await client.SetGameAsync(";;help");


            await client.LoginAsync(TokenType.Bot, Config.token);
            await client.StartAsync();

            client.MessageReceived += BadWordFilter.BadwordFilter.OnChat;
            client.MessageReceived += CruxBot.Anti_Advertising.OnChat;

            await Task.Delay(-1, cancelSrc.Token);
        }
        

        internal static JsonConfig<Config1> Configuration = new JsonConfig<Config1>("Employment List");
    }
}   