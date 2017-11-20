using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using BotTools.Utils;
using BotTools.Interfaces;
using System.Reflection;
using BotTools.Extensions;
using System.Text.RegularExpressions;

namespace BotTools.Handlers
{

    public class CommandHandler
    {
        public static IEnumerable<IDiscordCommand> Commands;
        //private Regex parameterRegex = new Regex(@"""  """, RegexOptions.Compiled);
        private DiscordSocketClient client;
        private bool logChat;
        public string prefix;


        public CommandHandler(DiscordSocketClient _client, string cmdPrefix, bool _logChat = true)
        {
            logChat = _logChat;
            client = _client;
            prefix = cmdPrefix;

            Commands = from t in Assembly.GetExecutingAssembly().GetTypes()
                       where t.GetInterfaces().Contains(typeof(IDiscordCommand)) && t.GetConstructor(Type.EmptyTypes) != null
                       select Activator.CreateInstance(t) as IDiscordCommand;

            Console.WriteLine("\n");
            foreach (var command in Commands)
                Logger.LogInfo($"Registered command: {command.Name}", ConsoleColor.Green);
            Console.WriteLine("\n");

            client.MessageReceived += Client_MessageReceivedAsync;
        }

        private async Task Client_MessageReceivedAsync(SocketMessage msg)
        {
            try
            {
                if (msg.Author.Id == client.CurrentUser.Id)
                    Events.TriggerOnBotSendMessage(msg.Content);

                if (!await HandleCommandAsync(msg))
                {
                    // message was not a command
                    if (logChat && msg.Author.Id != client.CurrentUser.Id)
                        Logger.LogChat(msg.Author.Username, msg.Content);
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"A error occurned: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        public async Task<bool> HandleCommandAsync(SocketMessage socketmsg)
        {
            SocketUserMessage userMsg = socketmsg as SocketUserMessage;
            if (userMsg == null)
                return false;

            if (userMsg.Content.StartsWith(prefix))
            {
                string[] parameters = GetParameters(userMsg, out string cmdName);

                if (!CommandExist(cmdName, out IDiscordCommand command))
                {
                        await userMsg.Channel.SendMessageAsync($"`{cmdName}` is not a valid command");

                        return false;
                }
                else if (!userMsg.Author.HasPermission(command.Permission.ToLower().Trim()))
                {
                        Logger.LogWarning($"denied permission for {prefix}{cmdName} for user {userMsg.Author.Username}");
                        await userMsg.Channel.SendMessageAsync($"You do not have permission to use: `{prefix}{cmdName}`");

                        return false;
                }

                Events.TriggerOnCommandExecuted(userMsg, userMsg.Author, cmdName, parameters);
                await Commands.SingleOrDefault(c => c.Name.ToLower() == cmdName).ExecuteAsync(userMsg, parameters);
                return true;
            }

            return false;
        }

        public string[] GetParameters(SocketUserMessage m, out string cmdName)
        {
            string[] parameters = { };
            cmdName = "null";

            // this regex is from https://github.com/RocketMod/Rocket/blob/master/Rocket.Core/Commands/RocketCommandManager.cs in Execute()
            parameters = Regex.Matches(m.Content, @"[\""](.+?)[\""]|([^ ]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture).Cast<Match>().Select(x => x.Value.Trim('"').Trim()).ToArray();

            if (parameters.Length != 0) cmdName = parameters[0].Replace(prefix, "");
            parameters = parameters.Skip(1).ToArray();

            return parameters;
        }

        public bool CommandExist(string commandName)
        {
            return Commands.SingleOrDefault(c => c.Name.ToLower().Trim() == commandName) != null;
        }

        public bool CommandExist(string commandName, out IDiscordCommand cmd)
        {
            cmd = Commands.SingleOrDefault(c => c.Name.ToLower().Trim() == commandName);
            return cmd != null;
        }
    }
}
