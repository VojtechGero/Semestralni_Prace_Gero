using Semestralni_prace.Properties;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Policy;

namespace Semestralni_prace
{

    public partial class FormSetup : Form
    {
        private List<PictureBox> pics = new List<PictureBox>();
        public FormSetup()
        {
            InitializeComponent();
        }
        public class Tile
        {
            public Image tiletype;
            public bool[] adj;

            public Tile(bool[] adj, Image tiletype)
            {
                this.tiletype = tiletype;
                this.adj = adj;
            }

            public Tile[,] add(Tile[,] bloky, int blok)
            {
                int l = bloky.GetLength(0);
                bloky[(blok - 1) / l, (blok - 1) % l] = this;
                return bloky;
            }
            public Tile[,] remove(Tile[,] bloky, int blok)
            {
                int l = bloky.GetLength(0);
                bloky[(blok - 1) / l, (blok - 1) % l] = null;
                return bloky;
            }

        }

        private void show(int worldsize, Tile[,] world)
        {
            const int size = 80;
            int off = Generate_Button.Size.Height;

            for (int i = 0; i < worldsize; i++)
            {
                for (int j = 0; j < worldsize; j++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Size = new Size(size, size),
                        Location = new Point(20 + j * size, off + 20 + i * size),
                        Image = world[i, j].tiletype
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

        private Tile[] getTiles()
        {
            Tile x = new Tile(new[] { true, true, true, true }, Resources.X);
            Tile stub = new Tile(new[] { false, true, false, false }, Resources.Stub);
            Tile turn1 = new Tile(new[] { true, true, false, false }, Resources.Turn1);
            Tile turn2 = new Tile(new[] { true, false, false, true }, Resources.Turn2);
            Tile turn3 = new Tile(new[] { false, false, true, true }, Resources.Turn3);
            return new[] { x, stub, turn1, turn2, turn3 };
        }
        private bool check(Tile[,] field, int blok, Tile t, int size)
        {
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
        private Tile[,] generator(Tile[,] field, Tile[] opts, int size, int blok)
        {
            if (blok < size * size + 1)
            {
                Tile[] shuffeled = opts;
                Random.Shared.Shuffle(shuffeled);
                foreach (Tile i in shuffeled)
                {
                    if (check(field, blok, i, size))
                    {
                        field = i.add(field, blok);
                        blok++;
                        Tile[,] temp = generator(field, opts, size, blok);
                        if (temp != null)
                        {
                            return temp;
                        }
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
            Tile[] options = getTiles();
            int size = 10;
            Tile[,] field = getField(size);
            field = generator(field, options, size, 1);
            show(size, field);
        }

    }
}