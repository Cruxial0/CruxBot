using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruxBot
{
    class FreestyleEasy
    {
        public static Random random = new Random();
        public static void FreestyleEZ()
        {
            var TCfreestyle = Program.client.GetChannel(383276102853984266) as SocketTextChannel;

            switch (random.Next(1, 15 + 1))
            {
                case 1:
                    TCfreestyle.SendMessageAsync("Panda");
                    break;

                case 2:
                    TCfreestyle.SendMessageAsync("Lemon");
                    break;

                case 3:
                    TCfreestyle.SendMessageAsync("Code");
                    break;

                case 4:
                    TCfreestyle.SendMessageAsync("Shore");
                    break;

                case 5:
                    TCfreestyle.SendMessageAsync("Shot");
                    break;

                case 6:
                    TCfreestyle.SendMessageAsync("Sea");
                    break;

                case 7:
                    TCfreestyle.SendMessageAsync("World");
                    break;

                case 8:
                    TCfreestyle.SendMessageAsync("Toaster");
                    break;

                case 9:
                    TCfreestyle.SendMessageAsync("Head");
                    break;

                case 10:
                    TCfreestyle.SendMessageAsync("Roof");
                    break;

                case 11:
                    TCfreestyle.SendMessageAsync("Wall");
                    break;

                case 12:
                    TCfreestyle.SendMessageAsync("Brain");
                    break;

                case 13:
                    TCfreestyle.SendMessageAsync("Bed");
                    break;

                case 14:
                    TCfreestyle.SendMessageAsync("Door");
                    break;

                case 15:
                    TCfreestyle.SendMessageAsync("Filter");
                    break;

                case 16:
                    TCfreestyle.SendMessageAsync("Smile");
                    break;

                case 17:
                    TCfreestyle.SendMessageAsync("Senile");
                    break;

                case 18:
                    TCfreestyle.SendMessageAsync("Air");
                    break;

                case 19:
                    TCfreestyle.SendMessageAsync("Break");
                    break;

                case 20:
                    TCfreestyle.SendMessageAsync("Vine");
                    break;

                case 21:
                    TCfreestyle.SendMessageAsync("Blood");
                    break;

                case 22:
                    TCfreestyle.SendMessageAsync("Style");
                    break;

                case 23:
                    TCfreestyle.SendMessageAsync("File");
                    break;

                case 24:
                    TCfreestyle.SendMessageAsync("Game");
                    break;

                case 25:
                    TCfreestyle.SendMessageAsync("Mail");
                    break;

                case 26:
                    TCfreestyle.SendMessageAsync("Bike");
                    break;

                case 27:
                    TCfreestyle.SendMessageAsync("Sleeve");
                    break;

                case 28:
                    TCfreestyle.SendMessageAsync("Rat");
                    break;

                case 29:
                    TCfreestyle.SendMessageAsync("Addict");
                    break;

                case 30:
                    TCfreestyle.SendMessageAsync("Clock");
                    break;

                case 31:
                    TCfreestyle.SendMessageAsync("Number");
                    break;

                case 32:
                    TCfreestyle.SendMessageAsync("Storm");
                    break;

                case 33:
                    TCfreestyle.SendMessageAsync("Steam");
                    break;

                case 34:
                    TCfreestyle.SendMessageAsync("Origin");
                    break;

                case 35:
                    TCfreestyle.SendMessageAsync("Relief");
                    break;

                case 36:
                    TCfreestyle.SendMessageAsync("Sack");
                    break;

                case 37:
                    TCfreestyle.SendMessageAsync("Shark");
                    break;

                case 38:
                    TCfreestyle.SendMessageAsync("Dog");
                    break;

                case 39:
                    TCfreestyle.SendMessageAsync("Cat");
                    break;

                case 40:
                    TCfreestyle.SendMessageAsync("Mask");
                    break;

                case 41:
                    TCfreestyle.SendMessageAsync("Sword");
                    break;

                case 42:
                    TCfreestyle.SendMessageAsync("Fox");
                    break;

                case 43:
                    TCfreestyle.SendMessageAsync("Rock");
                    break;

                case 44:
                    TCfreestyle.SendMessageAsync("Apple");
                    break;

                case 45:
                    TCfreestyle.SendMessageAsync("Hack");
                    break;
            }
        }
    }
}
