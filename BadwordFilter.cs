using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beautiful_Bot;

namespace BadWordFilter
{
    public class BadwordFilter
    {
        internal static List<string> badWords = new List<string> {"nigga", "nigger", "nazi", "niggas", "niggers"};
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
