using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Tile
    {
        bool walkable;
        Sprite Tilesprite;
        Vector2f position;

        public Tile(bool _walkable, string texturepath, Vector2f _position)
        {
            walkable = _walkable;

            Tilesprite = new Sprite(new Texture(texturepath));
            Tilesprite.Position = _position;

            position = _position;
        }

        public void draw(RenderWindow win)
        {
            win.Draw(Tilesprite);
        }

    }
}
