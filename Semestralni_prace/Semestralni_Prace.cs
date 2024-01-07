using Semestralni_prace.Properties;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Policy;

namespace Semestralni_prace
{
    
    public partial class Semestralni_Prace : Form
    {
        private List<PictureBox> pics = new List<PictureBox>();
        public Semestralni_Prace()
        {
            InitializeComponent();
        }
        

        private void show(Tile[,] field)
        {
            int worldsize = field.GetLength(0);
            const int size = 80;
            int offset = Generate_Button.Size.Height;

            for (int i = 0; i < worldsize; i++)
            {
                for (int j = 0; j < worldsize; j++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Size = new Size(size, size),
                        Location = new Point(20 + j * size, offset + 20 + i * size),
                        Image = field[i, j].tiletype
                    };
                    pics.Add(pictureBox);
                    Controls.Add(pictureBox);
                }
            }
        }

        private Tile[,] getField(int size)
        {
            Tile[,] tiles = new Tile[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tiles[i, j] = null;
                }
            }
            return tiles;
        }

        
        private bool check(Tile[,] field, int blok, Tile t)
        {
            int size = field.GetLength(0);
            int row = (blok - 1) / size;
            int col = (blok - 1) % size;
            int rows, cols;
            rows = cols = size;
            Tile[] touch = new Tile[4];
            if (row > 0) touch[0] = field[row - 1, col]; //top
            else touch[0] = null;

            if (col < cols - 1) touch[1] = field[row, col + 1]; //right
            else touch[1] = null;

            if (row < rows - 1) touch[2] = field[row + 1, col]; //bottom
            else touch[2] = null;

            if (col > 0) touch[3] = field[row, col - 1]; //left
            else touch[3] = null;
            for (int i = 0; i < 4; i++)
            {
                if (touch[i] is not null)
                {
                    var n = touch[i].adj;
                    var m = t.adj;
                    if (n[(i + 2) % 4] != m[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private Tile[,] generator(Tile[,] field, Tile[] opts, int blok)
        {
            int size = field.GetLength(0);
            if (blok < size * size + 1)
            {
                Tile[] shuffeled = opts;
                Random.Shared.Shuffle(shuffeled);
                foreach (Tile i in shuffeled)
                {
                    if (check(field, blok, i))
                    {
                        field = i.add(field, blok);
                        blok++;
                        Tile[,] temp = generator(field, opts, blok);
                        if (temp != null)
                        {
                            return temp;
                        }
                        i.remove(field, blok);
                        blok--;
                    }
                }
                return null;
            }
            return field;
        }
        private void closeAll()
        {
            foreach (PictureBox c in pics)
            {
                c.Dispose();
            }
            pics.Clear();
        }
        private void Generate_Button_Click(object sender, EventArgs e)
        {
            
            closeAll();
            Tile[] options = Tile.getTiles();
            int size = 10;
            Tile[,] field = getField(size);
            field = generator(field, options, 1);
            show(field);
        }
    }
}