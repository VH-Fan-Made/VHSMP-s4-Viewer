using Newtonsoft.Json;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using VHSMP.Models;
using VHSMP.Properties;

namespace VHSMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string settingJSON = Properties.Settings.Default.SettingJSON;
        Dictionary<string, bool> settings = new();
           
        public void ViewStream(String Streamer)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "C:\\Program Files\\Google\\Chrome\\Application\\chrome_proxy.exe";
            myProcess.StartInfo.Arguments = "--enable-features=WebContentsForceDark --profile-directory=Default --app=https://www.twitch.tv/" + Streamer;
            myProcess.Start();
        }
        LiveMonitor? liveMonitor;

        private void Form1_Load(object sender, EventArgs e)
        {
            liveMonitor = new LiveMonitor();
            generateList();
        }

        private void generateList()
        {
            List<string> lst = new() {
                "5up",
                "Abe",
                "CaptainPuffy",
                "CaptainSparklez",
                "ChosenArchitect",
                "falsesymmetry",
                "HBomb94",
                "Hrry",
                "InTheLittleWood",
                "iskall85",
                "itsRyanHiga",
                "jojosolos",
                "KaraCorvus",
                "PeteZahHutt",
                "Stressmonster",
                "tangofrags",
                "Tubbo",
                "Seapeekay"
            };
            foreach (string s in lst)
            {
                createGroupBox(s);
            }
            onlineAutoloadToolStripMenuItem.BackColor = Color.Red;
        }

        private void createGroupBox(string streamer)
        {
            Streamer s = new Streamer();
            s.name = streamer;

            //Label l = new Label();
            CheckBox cb = new CheckBox();
            cb.Text = "Offline";
            cb.BackColor = Color.Transparent;
            cb.Checked = getSettings(streamer + "-cb");
            cb.CheckedChanged += (sender, e) => { setSettings(streamer + "-cb", cb.Checked); };

            loadSelectedToolStripMenuItem.Click += (sender, e) => { if (cb.Checked) { ViewStream(streamer); }; };
            Button b = new Button();
            b.Click += (sender, e) => ViewStream(streamer);
            b.Name = streamer + "-b";
            b.Text = "View";
            FlowLayoutPanel f = new FlowLayoutPanel();
            f.Dock = DockStyle.Fill;
            f.FlowDirection = FlowDirection.TopDown;
            f.BackColor = Color.Transparent;
            f.TabStop = true;
            f.Controls.Add(cb);
            //f.Controls.Add(l);
            f.Controls.Add(b);
            GroupBox gb = new GroupBox();
            gb.Name = streamer + "-gb";
            gb.Text = streamer;
            gb.Controls.Add(f);
            gb.Width = (flowLayoutPanel1.Width / 5) - 6;
            gb.Height = (gb.Width / 16) * 10;
            flowLayoutPanel1.Controls.Add(gb);
            onlineAutoloadToolStripMenuItem.BackColor = Settings.Default.Autoload ? Color.LightGreen : Color.Red;
            System.Windows.Forms.Timer t = new();
            t.Interval = 5000;
            t.Tick += (sender, e) =>
            {
                s.imageHeight = gb.Height - 3;
                s.imageWidth = gb.Width - 3;
                s = getStreamerStatus(s);

                if (s.viewers == 0)
                {
                    cb.Text = "Offline";
                    cb.ForeColor = Color.Red;
                    f.BackgroundImage = null;
                }
                else
                {
                    if (s.image == null && Settings.Default.Autoload) 
                    {
                        ViewStream(streamer);
                    }
                    cb.Text = "Online - " + s.viewers + " viewer(s)";
                    cb.ForeColor = Color.LightGreen;
                    f.BackgroundImage = s.image;
                }

            };
            t.Enabled = true;

        }

        private Streamer getStreamerStatus(Streamer streamer)
        {
            Streamer s = streamer;
            if (liveMonitor != null)
            {
                streamer.viewers = liveMonitor.getStatus(s.name);
                if (streamer.viewers != 0)
                {
                    try
                    {
                        Uri? u = liveMonitor.getProfilePicture(s.name);
#pragma warning disable SYSLIB0014 // Type or member is obsolete
                        using (WebClient webClient = new WebClient())
                        {
                            if (u != null)
                            {
                                webClient.DownloadFile(u.ToString().Replace("{width}", s.imageWidth.ToString()).Replace("{height}", s.imageHeight.ToString()), s.name + "-" + s.imageWidth.ToString() + "x" + s.imageHeight.ToString() + ".png");
                            }
                        }
#pragma warning restore SYSLIB0014 // Type or member is obsolete
                        s.image = Image.FromFile(streamer.name + "-" + s.imageWidth.ToString() + "x" + s.imageHeight.ToString() + ".png");
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }
            return s;
        }

        private void setSettings(string streamer, bool value)
        {
            if (settings.ContainsKey(streamer))
            {
                settings[streamer] = value;
            }
            else
            {
                settings.Add(streamer, value);
            }
            settingJSON = JsonConvert.SerializeObject(settings);
            Properties.Settings.Default.SettingJSON = settingJSON;
            Properties.Settings.Default.Save();
        }

        private bool getSettings(string key)
        {
            settingJSON = Properties.Settings.Default.SettingJSON;

            Dictionary<string, bool>? tempSettings = JsonConvert.DeserializeObject<Dictionary<string, bool>>(settingJSON);
            if (tempSettings != null) settings = tempSettings;
            if (settings.ContainsKey(key))
            {
                return settings[key];
            }
            return false;
        }

        private void onlineAutoloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onlineAutoloadToolStripMenuItem.BackColor == Color.Red)
            {
                onlineAutoloadToolStripMenuItem.BackColor = Color.LightGreen;
                Settings.Default.Autoload = true;
                Settings.Default.Save();
            }
            else
            {
                onlineAutoloadToolStripMenuItem.BackColor = Color.Red;
                Settings.Default.Autoload = false;
                Settings.Default.Save();
            }
        }
    }
}