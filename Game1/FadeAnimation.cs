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
    public class FadeAnimation : Animation
    {
        bool increase;
        float fadeSpeed;
        TimeSpan defaultTime, timer;
        //bool startTimer;
        float activateValue;
        bool stopUpdating;
        float defaultAlpha;
        public bool Increase;

        public TimeSpan Timer
        {
            get { return timer; }
            set { defaultTime = value; timer = defaultTime; }
        }
        public float FadeSpeed
        {
            get { return fadeSpeed; }
            set { fadeSpeed = value; }  
        }

        public override float Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = value;
                if (alpha == 1.0f)
                    increase = false;
                else if (alpha == 0.0f)
                    increase = true;
            }
        }

        public float ActivateValue
        {
            get { return activateValue; }
            set { activateValue = value; }
        }
        public override void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
        {
           base.LoadContent(Content, image, text, position);
           increase = false;
           fadeSpeed = 0.6f;
           defaultTime = new TimeSpan(0, 0, 1);
           timer = defaultTime;
           activateValue = 0.0f;
           stopUpdating = false;
           defaultAlpha = alpha;
        }

        public override void Update(GameTime gameTime)
        {
            if (isActiv)
            {
                if (!stopUpdating)
                {
                    if (!increase)
                        alpha -= fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else
                        alpha += fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (alpha <= 0.0f)
                        alpha = 0.0f;
                    else if (alpha >= 1.0f)
                    alpha = 1.0f;
                }
                if (alpha == activateValue)
                {
                    stopUpdating = true;
                    timer -= gameTime.ElapsedGameTime;
                    if (timer.TotalSeconds <= 0)
                    {
                        increase = !increase;
                        timer = defaultTime;
                        stopUpdating = false;
                    }
                }

            }
            else
            {
                alpha = defaultAlpha;
                stopUpdating = false;
            }
        }

    }
}
