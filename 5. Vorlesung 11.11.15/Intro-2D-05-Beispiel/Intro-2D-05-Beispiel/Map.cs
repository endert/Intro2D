using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SFML.Window;
using SFML.Graphics;

namespace Intro_2D_05_Beispiel
{
    class Map
    {
        /// <summary>
        /// the "logic" array
        /// </summary>
        Tile[,] tiles;
        public float TileSize { get { return 50; } }

        string white = System.Drawing.Color.FromArgb(255, 255, 255).Name;
        string black = System.Drawing.Color.FromArgb(0, 0, 0).Name;

        public Map(Bitmap mask)
        {
            tiles = new Tile[mask.Width, mask.Height];

            //all collums
            for (int i = 0; i < tiles.GetLength(0); ++i)
            {
                //all rows
                for (int j = 0; j < tiles.GetLength(1); ++j)
                {
                    //decide what to do in the possible cases
                    if (mask.GetPixel(i, j).Name.Equals(white))
                        tiles[i, j] = new Tile(SFML.Graphics.Color.White, new Vector2f(i, j) * TileSize, true, new Vector2f(TileSize, TileSize));

                    if (mask.GetPixel(i, j).Name.Equals(black))
                        tiles[i, j] = new Tile(SFML.Graphics.Color.Black, new Vector2f(i, j) * TileSize, false, new Vector2f(TileSize, TileSize));
                }
            }
        }

        /// <summary>
        /// collision test for the given GameObject
        /// </summary>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public bool IsWalkable(GameObject gObj)
        {
            int x = (int)(gObj.Position.X / TileSize + gObj.MovingDirection.X / TileSize);
            int y = (int)(gObj.Position.Y / TileSize + gObj.MovingDirection.Y / TileSize);

            int sx = (int)(gObj.Position.X / TileSize + gObj.Size.X / TileSize + gObj.MovingDirection.X / TileSize);
            int sy = (int)(gObj.Position.Y / TileSize + gObj.Size.Y / TileSize + gObj.MovingDirection.Y / TileSize);

            //instead of the if statement above you can use a try catch as well
            try
            {
                return tiles[x, y].Walkable && tiles[sx, y].Walkable && tiles[x, sy].Walkable && tiles[sx, sy].Walkable;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        /// <summary>
        /// Draws all Tiles (it is not a must)
        /// </summary>
        /// <param name="win"></param>
        public void Draw(RenderWindow win)
        {
            foreach(Tile t in tiles)
            {
                t.Draw(win);
            }
            
        }
    }
}
