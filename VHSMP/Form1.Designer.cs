namespace VHSMP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer1 = new System.Windows.Forms.Timer(components);
            flowLayoutPanel1 = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            loadAllToolStripMenuItem = new ToolStripMenuItem();
            loadAllToolStripMenuItem1 = new ToolStripMenuItem();
            loadSelectedToolStripMenuItem = new ToolStripMenuItem();
            onlineAutoloadToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            flowLayoutPanel1.Location = new Point(0, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(826, 754);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadAllToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(826, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // loadAllToolStripMenuItem
            // 
            loadAllToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadAllToolStripMenuItem1, loadSelectedToolStripMenuItem, onlineAutoloadToolStripMenuItem });
            loadAllToolStripMenuItem.Name = "loadAllToolStripMenuItem";
            loadAllToolStripMenuItem.Size = new Size(64, 20);
            loadAllToolStripMenuItem.Text = "Controls";
            // 
            // loadAllToolStripMenuItem1
            // 
            loadAllToolStripMenuItem1.Name = "loadAllToolStripMenuItem1";
            loadAllToolStripMenuItem1.Size = new Size(180, 22);
            loadAllToolStripMenuItem1.Text = "Load all";
            // 
            // loadSelectedToolStripMenuItem
            // 
            loadSelectedToolStripMenuItem.Name = "loadSelectedToolStripMenuItem";
            loadSelectedToolStripMenuItem.Size = new Size(180, 22);
            loadSelectedToolStripMenuItem.Text = "Load selected";
            // 
            // onlineAutoloadToolStripMenuItem
            // 
            onlineAutoloadToolStripMenuItem.Name = "onlineAutoloadToolStripMenuItem";
            onlineAutoloadToolStripMenuItem.Size = new Size(180, 22);
            onlineAutoloadToolStripMenuItem.Text = "Online autoload";
            onlineAutoloadToolStripMenuItem.Click += onlineAutoloadToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 778);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "VHSMP Season 4 Viewer";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private FlowLayoutPanel flowLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadAllToolStripMenuItem;
        private ToolStripMenuItem loadAllToolStripMenuItem1;
        private ToolStripMenuItem loadSelectedToolStripMenuItem;
        private ToolStripMenuItem onlineAutoloadToolStripMenuItem;
    }
}