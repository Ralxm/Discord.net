using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using Discord.Commands;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().RunBotAsync().GetAwaiter().GetResult();
        }

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();

            string token = "NzY0NDQ3OTEwMDMyNDQxMzk0.X4GZmA.BRJUC5mzhhGIkMLVbeQEa2DaVms";

            Game status = new Game("everything", ActivityType.Watching, ActivityProperties.None);
            await _client.SetActivityAsync(status);
            await _client.SetStatusAsync(UserStatus.DoNotDisturb);
            _client.Log += _client_Log;
            await RegisterCommandAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage args)
        {
            try
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

                var message = args as SocketUserMessage;
                var context = new SocketCommandContext(_client, message);
                var client = context.Client;
                if (message.Author.IsBot) return;

                string[] lines = { "", day + "/" + month + "/2021" + " --- " + hora + ":" + minuto + ":" + segundo, context.Guild + " - " + context.Channel.Name, "Mensagem: " + message, "Por: " + context.User.Username + " - " + context.Message.Author.Discriminator + " - " + context.Message.Author.Id };
                if (context.Guild != null)
                {
                    int argPos = 0;

                    if (message.HasStringPrefix("!", ref argPos))
                    {
                        var result = await _commands.ExecuteAsync(context, argPos, _services);
                        var channel = client.GetChannel(806527599407923200) as SocketTextChannel;
                        if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);

                        System.IO.File.AppendAllLines(@"C:\Users\rafae\Desktop\discord\Commandlogs.txt", lines);

                        var builder = new EmbedBuilder();
                        builder.WithTitle(context.User.Username + "\n" + context.Guild.Name + " - " + context.Channel.Name);
                        builder.WithThumbnailUrl(context.Message.Author.GetAvatarUrl());
                        builder.WithDescription("||" + context.Channel.Id + "||\n" + Convert.ToString(message));
                        builder.WithAuthor(Convert.ToString(context.User.Id));
                        builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
                        builder.WithColor(Color.Red);
                        await channel.SendMessageAsync("", false, builder.Build());
                    }
                    else
                    {
                        var channel = client.GetChannel(806527562973052988) as SocketTextChannel;
                        System.IO.File.AppendAllLines(@"C:\Users\rafae\Desktop\discord\logs.txt", lines);
                        var builder = new EmbedBuilder();
                        builder.WithTitle(context.User.Username + "\n" + context.Guild.Name + " - " + context.Channel.Name);
                        builder.WithThumbnailUrl(context.Message.Author.GetAvatarUrl());
                        builder.WithDescription("||" + context.Channel.Id + "||\n" + Convert.ToString(message));
                        builder.WithAuthor(Convert.ToString(context.User.Id));
                        builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
                        builder.WithColor(Color.Red);
                        await channel.SendMessageAsync("", false, builder.Build());
                    }
                    if (message.Content.Contains("ralxm"))
                    {
                        context.Message.AddReactionAsync(Emote.Parse("<:ralxm:805825542574178324>"));
                        context.Message.AddReactionAsync(Emote.Parse("<:ralxm1:805825561926565928>"));
                        context.Message.AddReactionAsync(Emote.Parse("<:ralxm2:805825574555090985>"));
                        context.Message.AddReactionAsync(Emote.Parse("<:ralxm3:805825584638459955>"));
                        context.Message.AddReactionAsync(Emote.Parse("<:ralxm4:805825594683817984>"));
                        context.Message.AddReactionAsync(Emote.Parse("<:ralxm5:805825604984373328>"));
                    }
                    if (message.Content.Contains("quak"))
                    {
                        const int delay = 5100;
                        await Task.Delay(delay);
                        context.Message.AddReactionAsync(Emote.Parse("<:pepegay:805830775593107466>"));
                    }
                }
                else
                {
                    System.IO.File.AppendAllLines(@"C:\Users\rafae\Desktop\discord\dms.txt", lines);

                    string user = Convert.ToString(context.User.Id);

                    if (user.Contains("688502797951434913")) //FRANCISCA
                    {
                        var channel = client.GetChannel(806136030612815913) as SocketTextChannel;
                        await channel.SendMessageAsync("<@!326742854003064833>");
                        var builder = new EmbedBuilder();
                        builder.WithTitle(context.User.Username + "\n" + context.Guild.Name + " - " + context.Channel.Name);
                        builder.WithThumbnailUrl(context.Message.Author.GetAvatarUrl());
                        builder.WithDescription("||" + context.Channel.Id + "\n" + Convert.ToString(message));
                        builder.WithAuthor(Convert.ToString(context.User.Id));
                        builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
                        builder.WithColor(Color.Red);
                        await channel.SendMessageAsync("", false, builder.Build());
                    }
                    else if (user.Contains("336465356304678913")) //TRICKED
                    {
                        var channel = client.GetChannel(806137115292860427) as SocketTextChannel;
                        await channel.SendMessageAsync("<@!326742854003064833>");
                        var builder = new EmbedBuilder();
                        builder.WithTitle("DMs - " + context.User.Username);
                        builder.WithThumbnailUrl(context.Message.Author.GetAvatarUrl());
                        builder.WithDescription("Mensagem: " + message);
                        builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
                        builder.WithColor(Color.Red);
                        await channel.SendMessageAsync("", false, builder.Build());
                    }
                    else if (user.Contains("488658426126139395")) //ZÉ GUILHERME
                    {
                        var channel = client.GetChannel(806137745964924938) as SocketTextChannel;
                        await channel.SendMessageAsync("<@!326742854003064833>");
                        var builder = new EmbedBuilder();
                        builder.WithTitle("DMs - " + context.User.Username);
                        builder.WithThumbnailUrl(context.Message.Author.GetAvatarUrl());
                        builder.WithDescription("Mensagem: " + message);
                        builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
                        builder.WithColor(Color.Red);
                        await channel.SendMessageAsync("", false, builder.Build());
                    }
                    else //RESTO
                    {
                        var channel = client.GetChannel(806132395950342175) as SocketTextChannel;
                        await channel.SendMessageAsync("<@!326742854003064833>");
                        var builder = new EmbedBuilder();
                        builder.WithTitle("DMs - " + context.User.Username);
                        builder.WithThumbnailUrl(context.Message.Author.GetAvatarUrl());
                        builder.WithDescription("Mensagem: " + message);
                        builder.WithFooter("by Ralxmita " + day + "/" + month + "/" + "2021 " + hora + ":" + minuto + ":" + segundo);
                        builder.WithColor(Color.Red);
                        await channel.SendMessageAsync("", false, builder.Build());
                    }
                }
            }
            catch
            {

            }
        }
    }
}
