using System.Diagnostics;
using System.Net;

namespace VHSMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ViewStream(String Streamer)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "C:\\Program Files\\Google\\Chrome\\Application\\chrome_proxy.exe";
            myProcess.StartInfo.Arguments = "--enable-features=WebContentsForceDark --profile-directory=Default --app=https://www.twitch.tv/" + Streamer;
            myProcess.Start();
        }
        LiveMonitor? liveMonitor;

        private void button1_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox9.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox10.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox11.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox12.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox13.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox14.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox15.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox16.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox17.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox18.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox1 = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox2 = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox3 = checkBox3.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox4 = checkBox4.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox5 = checkBox5.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox6 = checkBox6.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox7 = checkBox7.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox8 = checkBox8.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox9 = checkBox9.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox10 = checkBox10.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox11 = checkBox11.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox12 = checkBox12.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox13 = checkBox13.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox14 = checkBox14.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox15 = checkBox15.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox16 = checkBox16.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox17 = checkBox17.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox18 = checkBox18.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.checkBox1;
            checkBox2.Checked = Properties.Settings.Default.checkBox2;
            checkBox3.Checked = Properties.Settings.Default.checkBox3;
            checkBox4.Checked = Properties.Settings.Default.checkBox4;
            checkBox5.Checked = Properties.Settings.Default.checkBox5;
            checkBox6.Checked = Properties.Settings.Default.checkBox6;
            checkBox7.Checked = Properties.Settings.Default.checkBox7;
            checkBox8.Checked = Properties.Settings.Default.checkBox8;
            checkBox9.Checked = Properties.Settings.Default.checkBox9;
            checkBox10.Checked = Properties.Settings.Default.checkBox10;
            checkBox11.Checked = Properties.Settings.Default.checkBox11;
            checkBox12.Checked = Properties.Settings.Default.checkBox12;
            checkBox13.Checked = Properties.Settings.Default.checkBox13;
            checkBox14.Checked = Properties.Settings.Default.checkBox14;
            checkBox15.Checked = Properties.Settings.Default.checkBox15;
            checkBox16.Checked = Properties.Settings.Default.checkBox16;
            checkBox17.Checked = Properties.Settings.Default.checkBox17;
            checkBox18.Checked = Properties.Settings.Default.checkBox18;

            liveMonitor = new LiveMonitor();

            timer1.Enabled = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ViewStream(groupBox1.Text);
            ViewStream(groupBox2.Text);
            ViewStream(groupBox3.Text);
            ViewStream(groupBox4.Text);
            ViewStream(groupBox5.Text);
            ViewStream(groupBox6.Text);
            ViewStream(groupBox7.Text);
            ViewStream(groupBox8.Text);
            ViewStream(groupBox9.Text);
            ViewStream(groupBox10.Text);
            ViewStream(groupBox11.Text);
            ViewStream(groupBox12.Text);
            ViewStream(groupBox13.Text);
            ViewStream(groupBox14.Text);
            ViewStream(groupBox15.Text);
            ViewStream(groupBox16.Text);
            ViewStream(groupBox17.Text);
            ViewStream(groupBox18.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) ViewStream(groupBox1.Text);
            if (checkBox2.Checked) ViewStream(groupBox2.Text);
            if (checkBox3.Checked) ViewStream(groupBox3.Text);
            if (checkBox4.Checked) ViewStream(groupBox4.Text);
            if (checkBox5.Checked) ViewStream(groupBox5.Text);
            if (checkBox6.Checked) ViewStream(groupBox6.Text);
            if (checkBox7.Checked) ViewStream(groupBox7.Text);
            if (checkBox8.Checked) ViewStream(groupBox8.Text);
            if (checkBox9.Checked) ViewStream(groupBox9.Text);
            if (checkBox10.Checked) ViewStream(groupBox10.Text);
            if (checkBox11.Checked) ViewStream(groupBox11.Text);
            if (checkBox12.Checked) ViewStream(groupBox12.Text);
            if (checkBox13.Checked) ViewStream(groupBox13.Text);
            if (checkBox14.Checked) ViewStream(groupBox14.Text);
            if (checkBox15.Checked) ViewStream(groupBox15.Text);
            if (checkBox16.Checked) ViewStream(groupBox16.Text);
            if (checkBox17.Checked) ViewStream(groupBox17.Text);
            if (checkBox18.Checked) ViewStream(groupBox18.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            statusCheck();
        }

        private void getStatus(Label label, GroupBox groupBox)
        {
            if (liveMonitor != null)
            {
                int a = liveMonitor.getStatus(groupBox.Text);
                if (a == 0)
                {
                    label.Text = "Offline";
                    label.ForeColor = Color.Red;
                    groupBox.BackgroundImage = null;
                }
                else
                {
                    label.Text = "Online - " + a + " viewer(s)";
                    label.ForeColor = Color.LightGreen;
                    try
                    {
                        Uri? u = liveMonitor.getProfilePicture(groupBox.Text);
#pragma warning disable SYSLIB0014 // Type or member is obsolete
                        using (WebClient webClient = new WebClient())
                        {
                            if (u != null)
                            {
                                webClient.DownloadFile(u.ToString().Replace("{width}", "145").Replace("{height}", "74"), groupBox.Text + ".png");
                            }
                        }
#pragma warning restore SYSLIB0014 // Type or member is obsolete
                        groupBox.BackgroundImage = Image.FromFile(groupBox.Text + ".png");
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }
        }

        private void statusCheck()
        {
            getStatus(label1, groupBox1);
            getStatus(label2, groupBox2);
            getStatus(label3, groupBox3);
            getStatus(label4, groupBox4);
            getStatus(label5, groupBox5);
            getStatus(label6, groupBox6);
            getStatus(label7, groupBox7);
            getStatus(label8, groupBox8);
            getStatus(label9, groupBox9);
            getStatus(label10, groupBox10);
            getStatus(label11, groupBox11);
            getStatus(label12, groupBox12);
            getStatus(label13, groupBox13);
            getStatus(label14, groupBox14);
            getStatus(label15, groupBox15);
            getStatus(label16, groupBox16);
            getStatus(label17, groupBox17);
            getStatus(label18, groupBox18);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusCheck();
        }
    }
}