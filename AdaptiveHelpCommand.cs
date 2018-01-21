using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotTools.Handlers;
using Discord.WebSocket;
using CruxBot;
using BotTools.Interfaces;
using Discord;

namespace CruxBot
{
    class AdaptiveHelpCommand : IDiscordCommand
    {
        public string Name => "Help";

        public string Help => "Shows this message, lol";

        public string Syntax => "";

        public string Permission => "default";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            Task.Run(async () =>
            {
                EmbedBuilder eb = new EmbedBuilder();
                EmbedFooterBuilder ef = new EmbedFooterBuilder();

                ef.Text = "Command_Help";
                eb.WithFooter(footer: ef);
                eb.WithCurrentTimestamp();
                eb.Color = Color.Blue;

                foreach (var Command in CommandHandler.Commands)
                {
                    eb.AddField($"Command: ;;{Command.Name}", $"Summary: {Command.Help}");
                }

                await msg.Author.SendMessageAsync("", embed: eb);
            });
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        }
    }
}
