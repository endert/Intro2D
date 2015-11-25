using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_07_Beispiel
{
    /// <summary>
    /// abstract base class for player and enemy may be later more
    /// </summary>
    abstract class GameObject
    {
        //Attributes
        protected Sprite sprite;
        protected Texture textur;
        protected float baseMovementSpeed;
        protected float movementSpeed;
        protected bool isMoving = false;

        //Propreties
        /// <summary>
        /// the Vector which describes the movement for the next tick (length = movementspeed)
        /// </summary>
        public Vector2f MovingDirection { get; protected set; }
        /// <summary>
        /// the position of this instance
        /// </summary>
        public Vector2f Position { get { return sprite.Position; } }
        /// <summary>
        /// the size of the sprite of this instance
        /// </summary>
        public Vector2f Size { get { return new Vector2f(textur.Size.X * sprite.Scale.X, textur.Size.Y * sprite.Scale.Y); } }

        /// <summary>
        /// norms the MovingDirection and than moving this for the MovingDirection
        /// </summary>
        protected void Move()
        {
            //evaluate the length of the direction vector. Math \(^^)/
            float length = (float)Math.Sqrt(MovingDirection.X * MovingDirection.X + MovingDirection.Y * MovingDirection.Y);

            //norming the direction vector, so it have the length of 1. Math \(^^)/
            if (length != 0)
                MovingDirection = MovingDirection / length;

            MovingDirection *= movementSpeed;

            //adding a percentage of the direction to the position. guess what comes now^^ Math \(^^)/
            isMoving = Program.map.IsWalkable(this);

            if (isMoving)
                sprite.Position += MovingDirection;
        }

        /// <summary>
        /// abstract Methode, must be implemented by all subclasses which are not abstract
        /// <para>shall Update this instance by calling all needed Methods</para>
        /// </summary>
        public abstract void Update(GameTime gTime);
        /// <summary>
        /// Draws the sprite in the given Window
        /// </summary>
        /// <param name="win"></param>
        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}
