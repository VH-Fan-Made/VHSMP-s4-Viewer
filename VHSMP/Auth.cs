using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api;

namespace VHSMP
{
    internal class Auth
    {
        private static List<string> scopes = new List<string> { "chat:read", "whispers:read", "whispers:edit", "chat:edit", "channel:moderate" };
        private static TwitchAPI api = new TwitchAPI(); 
        private static TwitchAPI? api2 = null;
        public static TwitchAPI getAPI()
        {
            return api2;
        }

        public static async Task MainAsync()
        {
            Console.WriteLine("Twitch user access token example.");

            // ensure client id, secret, and redrect url are set
            validateCreds();

            // create twitch api instance
            api.Settings.ClientId = Properties.Settings.Default.TwitchClientId;

            // start local web server
            var server = new WebServer(Properties.Settings.Default.TwitchRedirectUri);

            // print out auth url
            var URL = getAuthorizationCodeUrl(Properties.Settings.Default.TwitchClientId, Properties.Settings.Default.TwitchRedirectUri, scopes);
            Console.WriteLine($"Please authorize here:\n{URL}");
            Process app = openApp(URL);

            // listen for incoming requests
            var auth = await server.Listen();

            // exchange auth code for oauth access/refresh
            var resp = await api.Auth.GetAccessTokenFromCodeAsync(auth.Code, Properties.Settings.Default.TwitchClientSecret, Properties.Settings.Default.TwitchRedirectUri);

            // update TwitchLib's api with the recently acquired access token
            api.Settings.AccessToken = resp.AccessToken;

            // get the auth'd user
            var user = (await api.Helix.Users.GetUsersAsync()).Users[0];

            // print out all the data we've got
            Console.WriteLine($"Authorization success!\n\nUser: {user.DisplayName} (id: {user.Id})\nAccess token: {resp.AccessToken}\nRefresh token: {resp.RefreshToken}\nExpires in: {resp.ExpiresIn}\nScopes: {string.Join(", ", resp.Scopes)}");

            // refresh token
            var refresh = await api.Auth.RefreshAuthTokenAsync(resp.RefreshToken, Properties.Settings.Default.TwitchClientSecret);
            api.Settings.AccessToken = refresh.AccessToken;

            // confirm new token works
            user = (await api.Helix.Users.GetUsersAsync()).Users[0];

            // print out all the data we've got
            Properties.Settings.Default.TwitchClientRefreshToken = refresh.RefreshToken;
            Properties.Settings.Default.TwitchClientAccessToken = refresh.AccessToken;
            Properties.Settings.Default.Save();
            Console.WriteLine($"Authorization success!\n\nUser: {user.DisplayName} (id: {user.Id})\nAccess token: {refresh.AccessToken}\nRefresh token: {refresh.RefreshToken}\nExpires in: {refresh.ExpiresIn}\nScopes: {string.Join(", ", refresh.Scopes)}");

            // prevent console from closing
            // Console.ReadLine();
            api2 = api;
            while (!app.HasExited) { 
                app.Close();
                app.Kill();
            }
        }

        private static string getAuthorizationCodeUrl(string clientId, string redirectUri, List<string> scopes)
        {
            var scopesStr = String.Join('+', scopes);

            return "https://id.twitch.tv/oauth2/authorize?" +
                   $"client_id={clientId}&" +
                   $"redirect_uri={System.Web.HttpUtility.UrlEncode(redirectUri)}&" +
                   "response_type=code&" +
                   $"scope={scopesStr}";
        }

        private static void validateCreds()
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.TwitchClientId))
                throw new Exception("client id cannot be null or empty");
            if (String.IsNullOrEmpty(Properties.Settings.Default.TwitchClientSecret))
                throw new Exception("client secret cannot be null or empty");
            if (String.IsNullOrEmpty(Properties.Settings.Default.TwitchRedirectUri))
                throw new Exception("redirect uri cannot be null or empty");
            Console.WriteLine($"Using client id '{Properties.Settings.Default.TwitchClientId}', secret '{Properties.Settings.Default.TwitchClientSecret}' and redirect url '{Properties.Settings.Default.TwitchRedirectUri}'.");
        }

        private static Process openApp(string url)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "C:\\Program Files\\Google\\Chrome\\Application\\chrome_proxy.exe";
            myProcess.StartInfo.Arguments = "--enable-features=WebContentsForceDark --profile-directory=Default --app=" + url;
            myProcess.Start();
            return myProcess;
        }
    }
}
