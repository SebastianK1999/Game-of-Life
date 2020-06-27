namespace Game_of_Life
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.dock = new System.Windows.Forms.PictureBox();
            this.PlayStopButton = new System.Windows.Forms.PictureBox();
            this.ClearButton = new System.Windows.Forms.PictureBox();
            this.CursorCords = new System.Windows.Forms.Label();
            this.Highlight = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayStopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Highlight)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // dock
            // 
            this.dock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dock.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dock.Dock = System.Windows.Forms.DockStyle.Top;
            this.dock.Location = new System.Drawing.Point(0, 0);
            this.dock.Name = "dock";
            this.dock.Size = new System.Drawing.Size(800, 40);
            this.dock.TabIndex = 3;
            this.dock.TabStop = false;
            // 
            // PlayStopButton
            // 
            this.PlayStopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PlayStopButton.BackgroundImage = global::Game_of_Life.Properties.Resources.Play;
            this.PlayStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayStopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayStopButton.Location = new System.Drawing.Point(10, 10);
            this.PlayStopButton.Name = "PlayStopButton";
            this.PlayStopButton.Size = new System.Drawing.Size(21, 21);
            this.PlayStopButton.TabIndex = 4;
            this.PlayStopButton.TabStop = false;
            this.PlayStopButton.Click += new System.EventHandler(this.playPauseClick);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClearButton.BackgroundImage = global::Game_of_Life.Properties.Resources.Clear;
            this.ClearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.Location = new System.Drawing.Point(41, 10);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(21, 21);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.TabStop = false;
            this.ClearButton.Click += new System.EventHandler(this.clearClick);
            // 
            // CursorCords
            // 
            this.CursorCords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CursorCords.AutoSize = true;
            this.CursorCords.ForeColor = System.Drawing.Color.Transparent;
            this.CursorCords.Location = new System.Drawing.Point(708, 424);
            this.CursorCords.Name = "CursorCords";
            this.CursorCords.Size = new System.Drawing.Size(80, 17);
            this.CursorCords.TabIndex = 6;
            this.CursorCords.Text = "X = - ; Y = -";
            // 
            // Highlight
            // 
            this.Highlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Highlight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Highlight.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Highlight.Location = new System.Drawing.Point(0, 400);
            this.Highlight.Name = "Highlight";
            this.Highlight.Size = new System.Drawing.Size(50, 50);
            this.Highlight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Highlight.TabIndex = 1;
            this.Highlight.TabStop = false;
            this.Highlight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClick);
            this.Highlight.MouseLeave += new System.EventHandler(this.highlightLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CursorCords);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.PlayStopButton);
            this.Controls.Add(this.dock);
            this.Controls.Add(this.Highlight);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "John Conway\'s Game of Life";
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.zoom);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayStopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Highlight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox dock;
        private System.Windows.Forms.PictureBox PlayStopButton;
        private System.Windows.Forms.PictureBox ClearButton;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label CursorCords;
        private System.Windows.Forms.PictureBox Highlight;
    }
}

