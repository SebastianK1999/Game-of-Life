using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        //
        // Variables
        //
        private Board board; // Storage and functionality of the cells


        //
        // Functions
        //

        // Starts and stops the simulation
        private void playPause() 
        {
            if (gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                PlayStopButton.BackgroundImage = Properties.Resources.Play;
            }
            else
            {
                gameTimer.Enabled = true;
                PlayStopButton.BackgroundImage = Properties.Resources.Pause;
            }
        }

        // Updetes displayed coordiantes
        private void updateCoordsLabel(string X, string Y) 
        {
            int ow = CursorCords.Width;
            int l = CursorCords.Left;
            CursorCords.Text = "X = " + X + "; Y = " + Y;
            CursorCords.Left = ow + l - CursorCords.Width;
        }

        // Contstuctor
        public Form1() 
        {
            InitializeComponent();
            this.board = new Board(this);
        }


        //
        // Custom event handlers
        //

        // event of clicking on alive cell
        private void cellClick(object sender, EventArgs e)
        {
            int x = ((PictureBox)sender).Location.X / this.board.cellSize;
            int y = ((PictureBox)sender).Location.Y / this.board.cellSize;
            board[x][y].changeState();
        }

        // Event of entering alive cell
        private void cellMouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = System.Drawing.Color.ForestGreen;
            updateCoordsLabel((((PictureBox)sender).Left / this.board.cellSize).ToString(), (((PictureBox)sender).Top / this.board.cellSize).ToString());

        }

        // Event of leaving alive cell
        private void cellMouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = System.Drawing.Color.Green;
            updateCoordsLabel((this.board.highlightCell.body.Left / this.board.cellSize).ToString(), (this.board.highlightCell.body.Top / this.board.cellSize).ToString());
        }



        //
        // Form1 [Projekt] event handlers
        //

        // The main timer of the game
        private void gameTimerEvent(object sender, EventArgs e)
        {
            this.board.simulate(); 
        }

        // Event of releasing a key
        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.playPause();
            }
        }

        // Event of clicking a mouse on a empy field
        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = this.board.highlightCell.body.Location.X / this.board.cellSize;
                int y = this.board.highlightCell.body.Location.Y / this.board.cellSize;
                if (!board.storage.ContainsKey(x))
                {
                    board.storage.Add(x, new Dictionary<int, Cell> { });
                    this.board.createCell(x,y);
                }
                else if (!this.board[x].ContainsKey(y))
                {
                    this.board.createCell(x,y);
                }
                else
                {
                    board[x][y].changeState();
                    this.board[x][y].isNew = false;

                    this.board.createHiddenCells(x,y);
                    this.Controls.Add(this.board[x][y].body);
                    this.Controls.Remove(this.board.highlightCell.body);

                }
            }
        }

        // Event of leaving highlight area
        private void highlightLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(this.board.highlightCell.body);
        }

        //Event of moving a mouse on a Form background 
        private void mouseMove(object sender, MouseEventArgs e)
        {
            int x = (e.X / this.board.cellSize) * this.board.cellSize;
            int y = (e.Y / this.board.cellSize) * this.board.cellSize;
            this.board.highlightCell.body.Left = x;
            this.board.highlightCell.body.Top = y;
            updateCoordsLabel((x / this.board.cellSize).ToString(), (y / this.board.cellSize).ToString());
            this.Controls.Add(this.board.highlightCell.body);
        }

        // Event of clicking a play button
        private void playPauseClick(object sender, EventArgs e)
        {
            this.playPause();
        }

        // Event of clicking on a cler burron
        private void clearClick(object sender, EventArgs e)
        {
            if (board.storage.Count > 0)
            {
                if (MessageBox.Show("Are you sure yow want to clear the map", "Warning!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (KeyValuePair<int, Dictionary<int, Cell>> nd in board.storage)
                    {
                        foreach (KeyValuePair<int, Cell> n in nd.Value)
                        {
                            Controls.Remove(n.Value.body);
                        }
                        nd.Value.Clear();
                    }
                    board.storage.Clear();
                    if (gameTimer.Enabled)
                    {
                        playPause(); 
                    }
                }
            }
        }


        private void zoom(object sender, ScrollEventArgs e)
        {

        }
    }
}
