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
            position = Vector2.Zero;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            FileStream filestream = new FileStream("mytexture.png", FileMode.Open);
            myTexture = Texture2D.FromStream(graphics.GraphicsDevice, filestream);
            filestream.Close();
        }

        protected override void Update(GameTime gameTime)
        {

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
