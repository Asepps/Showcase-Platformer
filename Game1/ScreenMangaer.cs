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
    public class ScreenManager
    {
        #region Variables
        /// <summary>
        /// Creating custom contentmanager
        /// </summary>
        ContentManager content;
  
        /// <summary>
        /// Current screen thats being displayed
        /// </summary>
        GameScreen currentScreen;

        /// <summary>
        /// The new screeen that will be taking effect
        /// </summary>
        GameScreen newScreen;
        /// <summary>
        /// Screen Manager Instance
        /// </summary>
        private static ScreenManager instance;
        
        /// <summary>
        /// Screen Stack transfers you to different screens of the game.
        /// </summary> 
        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        /// <summary>
        /// screens width and height
        /// </summary>
        Vector2 dimensions;
        
        bool transition;

        FadeAnimation fade = new FadeAnimation();
        Texture2D fadeTexture;

        

        #endregion
        #region Properties
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }
        public Vector2 Dimensions
        {
            get { return dimensions;}
            set { dimensions = value;}
        }
        #endregion

        #region Main Methods
        /// <summary>
        /// Add Screen: Lets you load and unload your screen.
        /// </summary>
        public void AddScreen(GameScreen screen)
        {
            transition = true;
            newScreen = screen;
            fade.IsActiv = true;
            fade.Alpha = 0.0f;
            fade.ActivateValue = 1.0f;
        }
        public void AddScreen(GameScreen screen, float alpha)
        {
            transition = true;
            newScreen = screen;
            fade.IsActiv = true;
            fade.Alpha = 0.0f;
            fade.ActivateValue = 1.0f;
            if (alpha != 1.0f)
                fade.Alpha = 1.0f - alpha;
            else
                fade.Alpha = alpha;
            fade.Increase = true;
        }
        public void Initialize() 
        {
            currentScreen = new SplashScreen();
            fade = new FadeAnimation();
        

        }
        public void LoadContent(ContentManager Content) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
            fadeTexture = content.Load<Texture2D>("fade");
            fade.LoadContent(content, fadeTexture, "", Vector2.Zero);
            fade.Scale = dimensions.X;
        }
        public void Update(GameTime gameTime) 
        {
            if (!transition)
                currentScreen.Update(gameTime);
            else
                Transition(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            currentScreen.Draw(spriteBatch);
            if (transition)
                fade.Draw(spriteBatch);
        }
        
        #endregion
        #region Private Methods
        private void Transition(GameTime gameTime)
        {
            fade.Update(gameTime);
            if (fade.Alpha == 1.0f && fade.Timer.TotalSeconds == 1.0f)
            {
                screenStack.Push(newScreen);
                currentScreen.UnloadContent();
                currentScreen = newScreen;
                currentScreen.LoadContent(content);
            }
            else if (fade.Alpha == 0.0f)
            {
                transition = false;
                fade.IsActiv = false;
            }
        }

        #endregion


    }
}