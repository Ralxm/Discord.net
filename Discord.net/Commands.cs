using System;
using System.Collections.Generic;
using System.Text;
using Discord.Net;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using Discord.Commands;
using System.Linq;

namespace Discord.net
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("Ralxm")] 
        public async Task Ralxm()
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "326742854003064833") 
            {
                await Context.Channel.SendFileAsync(@"C:\Users\rafae\Desktop\stuff.jpg");
            }
        }
        [Command("Braiker")]
        public async Task Braiker(string user, [Remainder] string text)
        {
            string a = Convert.ToString(Context.Message.Author.Id);
            if (a == "407927599856222209")
            {
                await Context.Channel.SendMessageAsync(user + " " + text + "\nhttps://media.tenor.com/images/ecb0f2f371e09ccf04533f86fd96819f/tenor.gif|");
            }
        }
        [Command("help")] 
        public async Task Help()
        {
            var builder = new EmbedBuilder();
            builder.WithTitle("`Ralxmita Help Center`");
            builder.WithDescription("`!gifhelp`\n" + 
                "`!sudo` (mensagem)\n" +
                "`!horas` (alguém)\n" +
                "`!userinfo`\n" + 
                "`!serverinfo`\n" + 
                "e alguns easter eggs"
                );
            builder.WithColor(Color.Green);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
        [Command("rhelp")]
        public async Task RHelp()
        {
            var builder = new EmbedBuilder();
            builder.WithTitle("!sudo (mensagem)\n" +
                "!gif (@alguem) (tipo)\n" +
                "!horas (@alguem)\n" +
                "!apagar (quantidade)");
            builder.WithColor(Color.Green);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
        [Command("gifhelp")]
        public async Task GifHelp()
        {
            await Context.Message.DeleteAsync();
            const int delay = 3000;
            var builder = new EmbedBuilder();
            builder.WithTitle("!gif (tipo)\n");
            builder.WithDescription(
                "-burro\n" +
                "-gay\n" +
                "-sexy\n" +
                "-palhaço\n" +
                "-jumpscare");
            builder.WithColor(Color.Green);
            IUserMessage m = await Context.Channel.SendMessageAsync("", false, builder.Build());
            await Task.Delay(delay);
            await m.DeleteAsync();
        }
        [Command("sudo")]
        public async Task Sudo([Remainder] string text)
        {
            await Context.Message.DeleteAsync();

            if (text.Length <256)
            {
                var builder = new EmbedBuilder();
                builder.WithTitle(text);
                builder.WithColor(Color.Green);
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
            else
            {
                var builder = new EmbedBuilder();
                builder.WithDescription(text);
                builder.WithColor(Color.Green);
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
            
        }
        [Command("gif")]
        public async Task Gif(string user, string type)
        {
            await Context.Message.DeleteAsync();
            switch (type)
            {
                case "gay":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://giphy.com/gifs/Ck1Pib39Dl5TSzFB3S");
                    break;
                case "burro":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://giphy.com/gifs/what-confused-cross-eyed-q5ZGrl0J65ivu");
                    break;
                case "dumbass":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://giphy.com/gifs/ifc-lol-comedy-l2JhOVyjSHGejoXXq");
                    break;
                case "sexy":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://tenor.com/view/donut-banana-sexy-food-gif-14097048");
                    break;
                case "dumb":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://giphy.com/gifs/what-confused-cross-eyed-q5ZGrl0J65ivu");
                    break;
                case "clown":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://giphy.com/gifs/mr-rogers-x0npYExCGOZeo");
                    break;
                case "palhaço":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://giphy.com/gifs/mr-rogers-x0npYExCGOZeo");
                    break;
                case "palhaco":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://giphy.com/gifs/mr-rogers-x0npYExCGOZeo");
                    break;
                case "jumpscare":
                    await Context.Channel.SendMessageAsync("Hey " + user + "\nhttps://giphy.com/gifs/qFWb8QVwuRA88");
                    break;
            }
        }
        [Command("horas")]
        public async Task Horas(string user)
        {
            await Context.Message.DeleteAsync();
            DateTime now = DateTime.Now;

            int hora = now.Hour;
            int minuto = now.Minute;

            await Context.Channel.SendMessageAsync("Já viste que horas são " + user + "? " + Convert.ToString(hora + ":" + minuto));
            await Context.Channel.SendMessageAsync("https://tenor.com/view/clown-bye-gotosleep-gif-10649961");
        }
        [Command("apagar")]
        public async Task Apagar(int amount)
        {
            if (Context.User is SocketGuildUser user)
            {
                if (user.Roles.Any(r => r.Name == "A ZONA"))
                {
                    IEnumerable<IMessage> messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
                    await ((ITextChannel)Context.Channel).DeleteMessagesAsync(messages);
                    const int delay = 3000;
                    if (amount == 1)
                    {
                        IUserMessage m = await ReplyAsync($"Foi apagada uma mensagem");
                        await Task.Delay(delay);
                        await m.DeleteAsync();
                    }
                    else
                    {
                        IUserMessage m = await ReplyAsync($"Foram apagadas {amount} mensagens");
                        await Task.Delay(delay);
                        await m.DeleteAsync();
                    }
                }
                else
                {
                    var builder = new EmbedBuilder();
                    builder.WithTitle("Não tens permissão");
                    builder.WithColor(Color.Green);
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
            }
        }
        [Command("bulk")]
        public async Task bulk(int amount)
        {
            IEnumerable<IMessage> messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
            await ((ITextChannel)Context.Channel).DeleteMessagesAsync(messages);
            const int delay = 3000;
            if (amount == 1)
            {
                IUserMessage m = await ReplyAsync($"Foi apagada uma mensagem");
                await Task.Delay(delay);
                await m.DeleteAsync();
            }
            else
            {
                IUserMessage m = await ReplyAsync($"Foram apagadas {amount} mensagens");
                await Task.Delay(delay);
                await m.DeleteAsync();
            }
        }
        [Command("mute")]
        public async Task Mute(IGuildUser userr)
        {
            if (Context.User is SocketGuildUser user)
            {
                if (user.Roles.Any(r => r.Name == "A ZONA"))
                {
                    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "MUTED");
                    await (userr as IGuildUser).AddRoleAsync(role);
                    var usuario = userr;
                    await Context.Channel.SendMessageAsync("TÁ CALADO PÁ");
                }
            }
        }
        [Command("unmute")]
        public async Task Unmute(IGuildUser userr)
        {
            if (Context.User is SocketGuildUser user)
            {
                if (user.Roles.Any(r => r.Name == "A ZONA"))
                {
                    var role = Context.Guild.Roles.FirstOrDefault(z => z.Name == "MUTED");
                    await (userr as IGuildUser).RemoveRoleAsync(role);
                    await Context.Channel.SendMessageAsync("DESMUTADOOO");
                }
            }
        }
        [Command("ping")]
        public async Task Ping()
        {
            
        }
    }
}
