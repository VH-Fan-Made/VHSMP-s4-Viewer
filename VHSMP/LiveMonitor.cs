using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;
using TwitchLib.Api.Helix.Models.Entitlements.GetCodeStatus;
using TwitchLib.Api.Core.Enums;

namespace VHSMP
{
    public class LiveMonitor
    {
        public LiveStreamMonitorService? Monitor;
        private TwitchAPI? API;

        public LiveMonitor()
        {
            var t1 = Task.Run(() => Auth.MainAsync().GetAwaiter().GetResult());
            while (t1.IsCompleted == false) { Thread.Sleep(1000); }
            Task.Run(() => ConfigLiveMonitorAsync());
        }

        private async Task ConfigLiveMonitorAsync()
        {
            while (API == null)
            {
                API = Auth.getAPI();
            }
            
            Monitor = new LiveStreamMonitorService(API, 60);
            Monitor.OnStreamOnline += Monitor_OnStreamOnline;
            Monitor.OnStreamOffline += Monitor_OnStreamOffline;
            Monitor.OnStreamUpdate += Monitor_OnStreamUpdate;

            Monitor.OnServiceStarted += Monitor_OnServiceStarted;
            Monitor.OnChannelsSet += Monitor_OnChannelsSet;

            List<string> lst = new List<string> { "5up", "Abe", "CaptainPuffy", "CaptainSparklez", "ChosenArchitect", "falsesymmetry", "HBomb94", "Hrry", "InTheLittleWood", "iskall85", "itsRyanHiga", "jojosolos", "KaraCorvus", "PeteZahHutt", "Stressmonster", "tangofrags", "Tubbo", "Seapeekay" };
            Monitor.SetChannelsByName(lst);

            Monitor.Start(); //Keep at the end!
            await Monitor.UpdateLiveStreamersAsync(true);

            var a = Monitor.LiveStreams;

            await Task.Delay(-1);

        }

        public int getStatus(string streamer)
        { 
            if (Monitor.LiveStreams != null) {
                foreach (TwitchLib.Api.Helix.Models.Streams.GetStreams.Stream stream in Monitor.LiveStreams.Values)
                {
                    if ( stream.ViewerCount > 0 && stream.UserName == streamer)
                    {
                        var strem = stream;
                        Console.WriteLine(streamer + " :" + strem.ViewerCount);
                        return strem.ViewerCount;
                    }
                }
            }
            return 0;
        }

        public Uri? getProfilePicture(string streamer)
        {
            if (Monitor.LiveStreams != null)
            {
                foreach (TwitchLib.Api.Helix.Models.Streams.GetStreams.Stream stream in Monitor.LiveStreams.Values)
                {
                    if (stream.ViewerCount > 0 && stream.UserName == streamer)
                    {
                        var strem = stream;
                        Console.WriteLine(streamer + " :" + strem.ViewerCount);
                        Uri stremUri;
                        UriCreationOptions uriCreationOptions = new UriCreationOptions();
                        uriCreationOptions.DangerousDisablePathAndQueryCanonicalization = true;
                        _ = Uri.TryCreate(strem.ThumbnailUrl, uriCreationOptions, out stremUri);
                        return stremUri;
                    }
                }
            }
            return null;
        }

        private void Monitor_OnStreamOnline(object sender, OnStreamOnlineArgs e)
        {
            Console.WriteLine(e);
        }

        private void Monitor_OnStreamUpdate(object sender, OnStreamUpdateArgs e)
        {
            Console.WriteLine(e);
        }

        private void Monitor_OnStreamOffline(object sender, OnStreamOfflineArgs e)
        {
            Console.WriteLine(e);
        }

        private void Monitor_OnChannelsSet(object sender, OnChannelsSetArgs e)
        {
            Console.WriteLine(e);
        }

        private void Monitor_OnServiceStarted(object sender, OnServiceStartedArgs e)
        {
            Console.WriteLine(e);
        }
    }
}
