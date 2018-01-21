using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace CruxBot
{
    class Anti_Advertising
    {
        internal static Task OnChat(SocketMessage arg)
        {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            Task.Run(async() => 
            {
                if (arg is SocketUserMessage msg && msg.Author.Id != Program.client.CurrentUser.Id)
                {
                    string discordLink = "discord.gg";

                    var content = msg.Content;

                    if(content.Contains(discordLink))
                    {
                        msg.Channel.SendMessageAsync("Don't post discord links!");
                        msg.Channel.SendMessageAsync($";;warn {msg.Author.Mention} Posting discord links");
                    }
                }
            });
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            return Task.CompletedTask;
        }
    }
}
