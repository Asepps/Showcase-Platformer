using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    class NinjaStar : GameObject
    {
        public NinjaStar(Texture2D texture, Vector2 velocity, Vector2 position, float rotation)
            : base(texture)
        {
            this.velocity = velocity;
            this.position = position;
            this.rotation = rotation;
        }

        public override void Update()
        {
            position += velocity;
            rotation += .2f;
        }
    }
}
