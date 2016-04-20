using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;
namespace Game1
{
    public class InputManager
    {
        KeyboardState prevKeyState, keyState;

        public KeyboardState PreveKeyState
        {
            get{ return prevKeyState;}
            set{ prevKeyState = value;}
        }
        public KeyboardState KeyState
        {
            get{ return KeyState;}
            set{ prevKeyState = value;}
        }

        public void Update()
        {
            
            prevKeyState = keyState;
            keyState = Keyboard.GetState();
        }
        public bool KeyPressed(Keys key)
        {
            if(keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                return true;
            return false;
                
        }
        public bool KeyPressed(params Keys [] keys)
        {
            foreach(Keys key in keys)
            {
                if(keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                return true;
           
                
            }
             return false;
        }
         public bool KeyReleased(Keys key)
        {
            if(keyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                return true;
            return false;
                
        }
        public bool KeyReleased(params Keys [] keys)
        {
            foreach(Keys key in keys)
            {
                if(keyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                return true;
           
                
            }
             return false;
        }
        public bool keyDown(Keys key)
        {
            if (keyState.IsKeyDown(key))
                return true;
            return false;
        }
        public bool KeyDown(params Keys[] keys)
        {
            foreach(Keys key in keys)
            {
                if (KeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }



    }
}
