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
    public class Commands3 : ModuleBase<SocketCommandContext>
    {
        [Command("rsay")]
        public async Task RSay([Remainder] string text)
        {
            Context.Message.DeleteAsync();
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                await Context.Channel.SendMessageAsync(text);
            }
        }
        [Command("dm")]
        public async Task Dm(string te, [Remainder] string text)
        {
            string b = Convert.ToString(Context.Message.Author.Id);
            if (b == "326742854003064833")
            {
                var client = Context.Client;
                if (te.Contains("#"))
                {
                    string[] a = te.Split("#");
                    var userr = client.GetUser(a[0], a[1]);
                    userr.SendMessageAsync(text);
                }
                else
                {
                    var user = client.GetUser(Convert.ToUInt64(te));
                    user.SendMessageAsync(text);
                }
            }
            else{}
        }
        [Command("tororo")]
        public async Task Tororo([Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                Context.Message.DeleteAsync();
                var client = Context.Client;
                var channel = client.GetChannel(693074896577757204) as SocketTextChannel;
                await channel.SendMessageAsync(text);
            }
        }
        [Command("awaken")]
        public async Task Awaken([Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                Context.Message.DeleteAsync();
                var client = Context.Client;
                var channel = client.GetChannel(801952275533922366) as SocketTextChannel;
                await channel.SendMessageAsync(text);
            }
        }
        [Command("awakenm")]
        public async Task AwakenM([Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                Context.Message.DeleteAsync();
                var client = Context.Client;
                var channel = client.GetChannel(731188434043011092) as SocketTextChannel;
                await channel.SendMessageAsync(text);
            }
        }
        [Command("name")]
        public async Task Name([Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                Context.Message.DeleteAsync();
                var client = Context.Client;
                var channel = client.GetChannel(701833606280118285) as SocketTextChannel;
                await channel.SendMessageAsync(text);
            }

        }
        [Command("namemeth")]
        public async Task NameMeth([Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                Context.Message.DeleteAsync();
                var client = Context.Client;
                var channel = client.GetChannel(766775143623950346) as SocketTextChannel;
                await channel.SendMessageAsync(text);
            }
        }
        [Command("picareta")]
        public async Task Picareta([Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                Context.Message.DeleteAsync();
                var client = Context.Client;
                var channel = client.GetChannel(212912492400082946) as SocketTextChannel;
                await channel.SendMessageAsync(text);
            }
        }
        [Command("olibeirete")]
        public async Task Olibeirete([Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            {
                Context.Message.DeleteAsync();
                var client = Context.Client;
                var channel = client.GetChannel(680484024896061473) as SocketTextChannel;
                await channel.SendMessageAsync(text);
            }
        }
        [Command("repeat")]
        public async Task Repeat(int num, [Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833")
            { 
                for (int i = 0; i <= num; i++)
                {
                    await Context.Channel.SendMessageAsync(text);
                }
            }
        }
    }
}
