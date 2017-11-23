using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruxBot;

namespace BadWordFilter
{
    public class BadwordFilter
    {
        internal static List<string> badWords = new List<string> {"nigga", "nigger", "nazi", "niggas", "niggers", "n1gg3r", "n1gger", "nigg3r", "n!gger", "nigg£r", "nigg€r", "n!gg£r", "n!gg€r" };
        internal static Task OnChat(SocketMessage arg)
        {
            Task.Run(async () =>
            {
                if (arg is SocketUserMessage msg && msg.Author.Id != Program.client.CurrentUser.Id)
                {
                    var message = msg.Content.ToLower();
                    if (badWords.Any(x => message.Contains(x)))
                    {
                        await msg.Channel.SendMessageAsync($"{msg.Author.Mention}, watch your language!!");
                        var msg1 = await msg.Channel.SendMessageAsync($";;warn {msg.Author.Mention} Using bad words");
                        await msg.DeleteAsync();
                        await msg1.DeleteAsync();
                    }
                }
            });
            return Task.CompletedTask;
        }
    }
}
