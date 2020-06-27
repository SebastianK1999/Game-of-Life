using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        private class Board
        {
            // Static 
            // Variables
            //
            private static Form1 sForm; // Reference to form

            // Static
            // Functions
            //
            public static int[][] generateNeighbourIndexes(int x, int y) // 
            {
                int[][] neigboursIndexes = new int[8][];
                neigboursIndexes[0] = new int[2] { x - 1, y - 1 };
                neigboursIndexes[1] = new int[2] { x, y - 1 };
                neigboursIndexes[2] = new int[2] { x + 1, y - 1 };
                neigboursIndexes[3] = new int[2] { x - 1, y };
                neigboursIndexes[4] = new int[2] { x + 1, y };
                neigboursIndexes[5] = new int[2] { x - 1, y + 1 };
                neigboursIndexes[6] = new int[2] { x, y + 1 };
                neigboursIndexes[7] = new int[2] { x + 1, y + 1 };
                return neigboursIndexes;
            }

            //
            // Variables
            //
            public Dictionary<int, Dictionary<int, Cell>> storage = new Dictionary<int, Dictionary<int, Cell>> { }; // stucture that holds the cells
            public Cell highlightCell = new Cell(); // Highlight for were the cell will be plced
            public int cellSize = 20; // Size of the cells

            //
            // Getters Setters
            //
            public Dictionary<int, Cell> this[int i] { get { return this.storage[i]; } set { this.storage[i] = value; } }

            //
            // Functions
            //

            // creats alive cell
            public void createCell(int x, int y) 
            {
                this.storage[x].Add(y, new Cell(x, y, highlightCell.body.Size, true));
                this.createHiddenCells(x, y);
                sForm.Controls.Remove(this.highlightCell.body);
            }

            // Hidden cells around cell with given indexes
            public void createHiddenCells(int x, int y) 
            {
                int[][] CellsIndexes = Board.generateNeighbourIndexes(x, y);
                foreach (int[] i in CellsIndexes)
                {
                    if (!this.storage.ContainsKey(i[0]))
                    {
                        this.storage.Add(i[0], new Dictionary<int, Cell> { });
                        this.storage[i[0]].Add(i[1], new Cell(i[0], i[1], highlightCell.body.Size, false));
                    }
                    else if (!this.storage[i[0]].ContainsKey(i[1]))
                    {
                        this.storage[i[0]].Add(i[1], new Cell(i[0], i[1], highlightCell.body.Size, false));
                    }
                }
            }

            // Sumulates the game
            public void simulate()
            {
                List<Cell> dead = new List<Cell> { };
                List<Cell> toHide = new List<Cell> { };
                List<Cell> toShow = new List<Cell> { };
                
                // Looking for changes
                foreach (KeyValuePair<int, Dictionary<int, Cell>> nd in this.storage)
                {
                    foreach (KeyValuePair<int, Cell> n in nd.Value)
                    {
                        if (n.Value.isAlive)
                        {
                            int[][] CellsIndexes = Board.generateNeighbourIndexes(nd.Key, n.Key);
                            int activeCellsCount = 0;
                            foreach (int[] i in CellsIndexes)
                            {
                                Cell nRef = this.storage[i[0]][i[1]];
                                if (nRef.isAlive)
                                {
                                    activeCellsCount++;
                                }
                                else if (!dead.Contains(nRef))
                                {
                                    dead.Add(nRef);
                                }
                            }
                            if (!(activeCellsCount == 2 || activeCellsCount == 3))
                            {
                                toHide.Add(n.Value);
                            }
                        }
                    }
                }
                foreach (Cell n in dead)
                {
                    int[][] deadCellsInNdexes = Board.generateNeighbourIndexes(n.indexes[0], n.indexes[1]);
                    int aciveDeadCellsCount = 0;
                    foreach (int[] j in deadCellsInNdexes)
                    {
                        if (this.storage.ContainsKey(j[0]) && this.storage[j[0]].ContainsKey(j[1]) && this.storage[j[0]][j[1]].isAlive)
                        {
                            aciveDeadCellsCount++;
                        }
                    }
                    if (aciveDeadCellsCount == 3)
                    {
                        toShow.Add(n);
                    }
                }

                // Applying changes
                foreach (Cell n in toShow)
                {
                    if (n.isNew)
                    {
                        n.changeState();
                        n.reSize(cellSize);
                        createHiddenCells(n.indexes[0], n.indexes[1]);
                        n.isNew = false;
                    }
                    else
                    {
                        n.changeState();
                        n.reSize(cellSize);
                    }
                }
                foreach (Cell n in toHide)
                {
                    n.changeState();
                }
                toShow.Clear();
                toHide.Clear();
                dead.Clear();
            }

            // Cunstructor
            public Board(Form1 f)
            {
                Board.sForm = f;

                Cell.sForm = Board.sForm;
                highlightCell.body = sForm.Highlight;
                highlightCell.body.BackColor = System.Drawing.Color.FromArgb(255, 50, 50, 50);
                highlightCell.body.Size = new System.Drawing.Size(cellSize, cellSize);
                sForm.Controls.Remove(highlightCell.body);
            }
        }
    }
}

