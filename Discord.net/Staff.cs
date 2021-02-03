using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Discord.net
{
    public class Commands2 : ModuleBase<SocketCommandContext>
    {
        [Command("userinfo")]
        public async Task Info()
        {
            DateTime date = DateTime.Now;
            string hora = Convert.ToString(date.Hour);
            string minuto = Convert.ToString(date.Minute);
            string segundo = Convert.ToString(date.Second);
            string day = Convert.ToString(date.Day);
            string month = Convert.ToString(date.Month);

            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (hora.Length == 1)
            {
                hora = "0" + hora;
            }
            if (minuto.Length == 1)
            {
                minuto = "0" + minuto;
            }
            if (segundo.Length == 1)
            {
                segundo = "0" + segundo;
            }


            string ID = Convert.ToString(Context.Message.Author.Id);
            string CreationDate = Convert.ToString(Context.Message.Author.CreatedAt).Substring(0, 19);
            string username = Convert.ToString(Context.Message.Author.Username);
            string Avatar = Convert.ToString(Context.Message.Author.GetAvatarUrl());
            string disc = Convert.ToString(Context.Message.Author.Discriminator);

            string a = string.Empty;
            foreach (SocketRole role in ((SocketGuildUser)Context.Message.Author).Roles)
            {
                a += (role + ", ");
            }
            await Context.Channel.SendMessageAsync(a.Substring(11));

            var builder = new EmbedBuilder();
            builder.WithTitle("`" + username + "`");
            builder.WithDescription(
                "Conta criada em: `" + CreationDate + "`\n" +
                "ID: `" + ID + "`\n" +
                "#: `" + username + "#" + disc + "`\n" +
                "Avatar: [Click here](" + Avatar + ")\n" +
                "Roles: " + a.Substring(11) + "`"
                );
            builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
            builder.WithColor(Color.Green);
            builder.WithThumbnailUrl(Avatar);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }

        [Command("serverinfo")]
        public async Task server()
        {
            DateTime date = DateTime.Now;
            string hora = Convert.ToString(date.Hour);
            string minuto = Convert.ToString(date.Minute);
            string segundo = Convert.ToString(date.Second);
            string day = Convert.ToString(date.Day);
            string month = Convert.ToString(date.Month);

            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (hora.Length == 1)
            {
                hora = "0" + hora;
            }
            if (minuto.Length == 1)
            {
                minuto = "0" + minuto;
            }
            if (segundo.Length == 1)
            {
                segundo = "0" + segundo;
            }

            string CreationDate = Convert.ToString(Context.Guild.CreatedAt);
            string ServerName = Convert.ToString(Context.Guild.Name);
            var builder = new EmbedBuilder();
            builder.WithTitle("`" + ServerName + "`");
            builder.WithDescription(
                "Owner: <@" + Context.Guild.OwnerId + ">\n" +
                "Server criado em: `" + CreationDate.Substring(0, 19) + "`\n" +
                "ID Servidor: `" + Context.Guild.Id + "`\n" +
                "ID Canal: `" + Context.Channel.Id + "`\n" +
                "Membros: `" + Context.Guild.MemberCount + "`\n" +
                "Roles: `" + Context.Guild.Roles.Count + "`\n" +
                "Canais: `" + Context.Guild.Channels.Count + "`\n" +
                "Emotes `" + Context.Guild.Emotes.Count + "`\n" +
                "Icon URL: [Click here](" + Context.Guild.IconUrl + ")"
                );
            builder.WithThumbnailUrl(Context.Guild.IconUrl);
            builder.WithColor(Color.Green);
            builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
        [Command("test")]
        public async Task test(string id, [Remainder] string rest)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                Context.Message.DeleteAsync();
                ulong channelID = Convert.ToUInt64(id);
                var client = Context.Client;
                var channel = client.GetChannel(channelID) as SocketTextChannel;
                await channel.SendMessageAsync(rest);
            }
        }
        [Command("debug")]
        public async Task Debug()
        {
            string b = Convert.ToString(Context.Guild.Id);
            string a = Convert.ToString(Context.Channel.Id);
            Console.WriteLine("guildID: " + b);
            Console.WriteLine("channelID: " + a);
        }

        [Command("user")]
        public async Task Info(string user)
        {
            DateTime date = DateTime.Now;
            string hora = Convert.ToString(date.Hour);
            string minuto = Convert.ToString(date.Minute);
            string segundo = Convert.ToString(date.Second);
            string day = Convert.ToString(date.Day);
            string month = Convert.ToString(date.Month);

            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (hora.Length == 1)
            {
                hora = "0" + hora;
            }
            if (minuto.Length == 1)
            {
                minuto = "0" + minuto;
            }
            if (segundo.Length == 1)
            {
                segundo = "0" + segundo;
            }

            if (user.Contains("<@"))
            {
                user = user.Substring(3);
                int k = user.Length;
                user = user.Substring(0, k - 1);

                var client = Context.Client;
                ulong id = Convert.ToUInt64(user);
                var socketUser = client.GetUser(id);

                string CreationDate = Convert.ToString(socketUser.CreatedAt).Substring(0, 19);
                string disc = Convert.ToString(socketUser.Discriminator);
                string username = Convert.ToString(socketUser.Username);
                string Avatar = Convert.ToString(socketUser.GetAvatarUrl());
                string ID = Convert.ToString(socketUser.Id);

                var builder = new EmbedBuilder();
                builder.WithTitle("`" + username + "`");
                builder.WithDescription(
                    "Conta criada em: `" + CreationDate + "`\n" +
                    "ID: `" + ID + "`\n" +
                    "#: `" + username + "#" + disc + "`\n" +
                    "Avatar: [Click here](" + Avatar + ")\n"
                    );
                builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
                builder.WithColor(Color.Green);
                builder.WithThumbnailUrl(Avatar);
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
            else
            {
                var client = Context.Client;
                ulong id = Convert.ToUInt64(user);
                var socketUser = client.GetUser(id);

                string CreationDate = Convert.ToString(socketUser.CreatedAt).Substring(0, 19);
                string disc = Convert.ToString(socketUser.Discriminator);
                string username = Convert.ToString(socketUser.Username);
                string Avatar = Convert.ToString(socketUser.GetAvatarUrl());
                string ID = Convert.ToString(socketUser.Id);


                var builder = new EmbedBuilder();
                builder.WithTitle("`" + username + "`");
                builder.WithDescription(
                    "Conta criada em: `" + CreationDate + "`\n" +
                    "ID: `" + ID + "`\n" +
                    "#: `" + username + "#" +disc + "`\n" +
                    "Avatar: [Click here](" + Avatar + ")\n"
                    );
                builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
                builder.WithColor(Color.Green);
                builder.WithThumbnailUrl(Avatar);
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
        }
        [Command("age")]
        public async Task Age()
        {
            /*int i = 0;
            int a = Context.Guild.MemberCount;
            var client = Context.Client;
            String[] comps = new String[1000];
            foreach (IGuildUser user in Context.Channel.Id)
            {
                comps[i] = Convert.ToString(user.CreatedAt);
                i++;
                Context.Channel.SendMessageAsync(comps[i]);
            }*/
        }
        [Command("roles")]
        public async Task Roles()
        {
            DateTime date = DateTime.Now;
            string hora = Convert.ToString(date.Hour);
            string minuto = Convert.ToString(date.Minute);
            string segundo = Convert.ToString(date.Second);
            string day = Convert.ToString(date.Day);
            string month = Convert.ToString(date.Month);

            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (hora.Length == 1)
            {
                hora = "0" + hora;
            }
            if (minuto.Length == 1)
            {
                minuto = "0" + minuto;
            }
            if (segundo.Length == 1)
            {
                segundo = "0" + segundo;
            }

            string a = string.Empty;
            foreach (SocketRole role in ((SocketGuild)Context.Guild).Roles)
            {
                a += role.Mention + " ";
            }
            var builder = new EmbedBuilder();
            builder.WithTitle("Roles");
            builder.WithDescription(a);
            builder.WithColor(Color.Green);
            builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
            
        }
    }    
}
