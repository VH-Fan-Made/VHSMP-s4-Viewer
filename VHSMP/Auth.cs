using System.Diagnostics;
using TwitchLib.Api;

namespace VHSMP
{
    internal class Auth
    {
        private static List<string> scopes = new List<string> { "chat:read", "whispers:read", "whispers:edit", "chat:edit", "channel:moderate" };
        private static TwitchAPI api = new TwitchAPI(); 
        private static TwitchAPI? api2 = null;
        public static TwitchAPI? getAPI()
        {
            return api2;
        }

        public static async Task MainAsync()
        {
            validateCreds();
            api.Settings.ClientId = Properties.Settings.Default.TwitchClientId;
            var server = new WebServer(Properties.Settings.Default.TwitchRedirectUri);
            var URL = getAuthorizationCodeUrl(Properties.Settings.Default.TwitchClientId, Properties.Settings.Default.TwitchRedirectUri, scopes);
            Process app = openApp(URL);
            var auth = await server.Listen();
            var resp = await api.Auth.GetAccessTokenFromCodeAsync(auth.Code, Properties.Settings.Default.TwitchClientSecret, Properties.Settings.Default.TwitchRedirectUri);
            api.Settings.AccessToken = resp.AccessToken;
            var user = (await api.Helix.Users.GetUsersAsync()).Users[0];
            var refresh = await api.Auth.RefreshAuthTokenAsync(resp.RefreshToken, Properties.Settings.Default.TwitchClientSecret);
            api.Settings.AccessToken = refresh.AccessToken;
            user = (await api.Helix.Users.GetUsersAsync()).Users[0];
            Properties.Settings.Default.TwitchClientRefreshToken = refresh.RefreshToken;
            Properties.Settings.Default.TwitchClientAccessToken = refresh.AccessToken;
            Properties.Settings.Default.Save();
            api2 = api;
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
