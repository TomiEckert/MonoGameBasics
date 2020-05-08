using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace MGBasics
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D myTexture;
        Vector2 position;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("mytexture");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                position += new Vector2(0, -1);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                position += new Vector2(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                position += new Vector2(0, 1);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                position += new Vector2(1, 0);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(myTexture, position, Color.White);
            spriteBatch.End();
        }
    }
}
