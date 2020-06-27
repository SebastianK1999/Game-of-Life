using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Game_of_Life
{
    public partial class Form1 : Form {
        public class Cell {
            // Static
            // Variables
            //
            public static Form1 sForm; // Reference to the form
            
            
            //
            // Variables
            //
            public bool isAlive { get; private set; } // Variable that indicades wether the cell is dead or alive
            public bool isNew; // bool that saays whether the call has allredy been diplayed
            public PictureBox body; // The visible part of the Cell
            public int[] indexes; // Indexed of the cell on the map;

            //
            // Functions
            //

            // Function that changes size of the cell while zooming in
            public void reSize(int squareSize) 
            {
                this.body.Size = new System.Drawing.Size(squareSize, squareSize);
                this.body.Left = indexes[0] * squareSize;
                this.body.Top = indexes[1] * squareSize;
            }

            // Sitches stat of the Cell between dead or alive
            public void changeState() 
            {
                if (this.isAlive)
                {
                    this.isAlive = false;
                    Cell.sForm.Controls.Remove(this.body);
                }
                else
                {
                    this.isAlive = true;
                    Cell.sForm.Controls.Add(this.body);
                }
            }

            // Constructor
            public Cell(int x, int y, System.Drawing.Size cellSize, bool isAlive = false)
            {
                this.indexes = new int[2] { x, y };
                this.isAlive = isAlive;
                this.body = new PictureBox();

                this.body.Size = cellSize;
                this.body.BackColor = System.Drawing.Color.Green;
                this.body.Left = x * cellSize.Width;
                this.body.Top = y * cellSize.Height;

                this.body.MouseClick += sForm.cellClick;
                this.body.MouseEnter += sForm.cellMouseEnter;
                this.body.MouseLeave += sForm.cellMouseLeave;

                if (isAlive)
                {
                    sForm.Controls.Add(this.body);
                    this.isNew = false;
                }
                else
                {
                    this.isNew = true;
                }
            }

            // Empty constructor
            public Cell() { }
        }
    }
}
