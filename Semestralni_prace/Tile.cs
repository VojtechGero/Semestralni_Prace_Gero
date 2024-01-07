using Semestralni_prace.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralni_prace
{
    internal class Tile
    {
        internal Image tiletype;
        internal bool[] adj;

        internal Tile(bool[] adj, Image tiletype)
        {
            this.tiletype = tiletype;
            this.adj = adj;
        }

        internal Tile[,] add(Tile[,] field, int blok)
        {
            int l = field.GetLength(0);
            field[(blok - 1) / l, (blok - 1) % l] = this;
            return field;
        }
        internal Tile[,] remove(Tile[,] field, int blok)
        {
            int l = field.GetLength(0);
            field[(blok - 1) / l, (blok - 1) % l] = null;
            return field;
        }

        internal static Tile[] getTiles()
        {
            
            Tile x = new Tile(new[] { true, true, true, true }, Resources.X);
            Tile stub = new Tile(new[] { false, true, false, false }, Resources.Stub);
            Tile turn1 = new Tile(new[] { true, true, false, false }, Resources.Turn1);
            Tile turn2 = new Tile(new[] { true, false, false, true }, Resources.Turn2);
            Tile turn3 = new Tile(new[] { false, false, true, true }, Resources.Turn3);
            return new[] { x, stub, turn1, turn2, turn3 };
        }

    }
}
