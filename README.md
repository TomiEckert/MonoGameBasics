# MonoGameBasics

The tutorial will walk through the following points to help you get started with this thing.

- [Setup](#Setting-up)
- [Textures](#Loading-and-displaying-texture)
    - [Loading from file](#Loading-from-a-file)
    - [Loading from Pipeline Tool](#Loading-from-the-PT)
    - [Drawing texture](#Drawing-textures)
- [Keyboard input](#Keyboard-input)
- [Mouse input](#Mouse-input)

---
## Setting up

> Need Sisual Studio 2015 or higher. NOT VSCode. So bootcamp up loosers.

1. Go to [monogame.net](https://monogame.net) and download the latest one. Here's [direct link](http://community.monogame.net/t/monogame-3-7-1-release/11173).
2. Install obviously.
3. Open Visual Studio, and create a new MonoGame Project. File > New... > Visual C# > MonoGame > MonoGame Windows Project. Then call it what you want.
4. Once it loaded press F5 and if it's a blue window you're good.

---
## Loading and displaying texture

`Program.cs` launches the game window and we literally don't need it for anything at all. `Game1.cs` however is the code that runs when you open the game.
> It looks big but 80% is comments.

This is `Game1.cs` shortened down:

```csharp
public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
```
To load textures, sounds, and what not, you need the `ContentManager`, which is initialized by default.

There are 2 ways to load textures:

1. Load straight from a file, normal size, no encryption, etc. But easy to do.
2. Load from the `Pipeline Tool`. Compressed, encrypted, but have to compile the texture in the `PT` before.

### Loading from a file

1. Put the texture into the `bin\Windows\x86\Debug` folder in your project.
2. Create a new `Texture2D` variable on the top of the class. Name it ***myTexture***.
3. Insert the following code into `LoadContent`. And at least read what it does so you don't stay retarded.
```csharp
FileStream filestream = new FileStream("mytexture.png", FileMode.Open);
Texture2D myTexture = Texture2D.FromStream(graphics.GraphicsDevice, filestream);
filestream.Close();
```

### Loading from the PT

1. Right-click `Content.mgcb` in the solution explorer. Open with `MonoGame Pipeline Tool`.
2. Add existing item, and select the texture you want to load.
3. Build the resources with the `PT`. If it succeeded you're good to go. If it didn't then idk, it never failed for me.
4. Create a new `Texture2D` variable on the top of the class. Name it ***myTexture***.
5. Insert the following code into `LoadContent`. And at least read what it does so you don't stay retarded.
```csharp
myTexture = Content.Load<Texture2D>("mytexture");
```

### Drawing textures

This is the last point of this chapter thingy. It is fairly simple. You have a `SpriteBatch` and that can draw `Texture2D`s.

The simplest way to draw our `Texture2D` is this:

```csharp
spriteBatch.Begin();
spriteBatch.Draw(myTexture, new Vector2(0, 0), Color.White);
spriteBatch.End();
```

You have to initialize and end a drawing cycle. Idk why but yeah. And that's how you draw a single texture. With a lot of textures, we can have them in a array and foreach through them, or recursively go through objects and shit. We'll see.

---
## Keyboard input

We need to process input when the game updates.
> ***THIS IS NOT TIED TO FPS.***
This means that we need to use `GameTime` to see the elapsed time since last update. So that an action takes 152ms and not 8 frames.

Input mapping is manual. That sucks but whatever.

1. Add a new variable to the top: `Vector2 position;`
2. Edit `Draw` to match this:
```csharp
spriteBatch.Draw(myTexture, position, Color.White);
```
3. Copy paste this into `Update`.

```csharp
if (Keyboard.GetState().IsKeyDown(Keys.W))
    position += new Vector2(0, -1);
if (Keyboard.GetState().IsKeyDown(Keys.A))
    position += new Vector2(-1, 0);
if (Keyboard.GetState().IsKeyDown(Keys.S))
    position += new Vector2(0, 1);
if (Keyboard.GetState().IsKeyDown(Keys.D))
    position += new Vector2(1, 0);
```
4. Profit.

---
## Mouse input

```csharp
if you followed the previous chapter thing {
    do the following steps
} else {
    do the previous chapter thing
}
```

1. Change update to look like this:
```csharp
protected override void Update(GameTime gameTime)
{
    position = Mouse.GetState().Position.ToVector2();
}
```
2. Profit.