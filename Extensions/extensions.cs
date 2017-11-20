using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using BotTools.Utils;

namespace BotTools.Extensions
{
    public static class extensions
    {
        public static bool HasPermission(this SocketUser user, string permission)
        {
            return PermissionHelper.HasPermission(user, permission);
        }
    }
}
