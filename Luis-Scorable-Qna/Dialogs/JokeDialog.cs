using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Scorable.Dialogs
{
    [Serializable]
    public class JokeDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            // Confirmation that we're in the JokeDialog, forwarded from the LUIS dialog
            string response = string.Empty;
            using (var client = new WebClient())
            {
                response = client.DownloadString($"http://numbersapi.com/random/math");
            }
            string message = response;
            context.PostAsync(message);


            context.Done<object>(null);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
           
        }
    }
}