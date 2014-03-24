using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WordRectangle
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Color tcolor = Color.White;
        Color bcolor = Color.CornflowerBlue;
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("MyFont");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //key board state set up for up and down keys
             KeyboardState state = Keyboard.GetState();
            //if up is pressed change to black
             if (state.IsKeyDown(Keys.Up))
             {
                 tcolor = Color.Black;
             }
             //if down is pressed change to white
             else if (state.IsKeyDown(Keys.Down))//if escape key is pressed 
             {
                 tcolor = Color.White;
             }
             else if (state.IsKeyDown(Keys.Left))//if escape key is pressed 
             {
                 bcolor = Color.CornflowerBlue;
             }
             else if (state.IsKeyDown(Keys.Right))//if escape key is pressed 
             {
                 bcolor = Color.Green;
             }
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            //string which will be passed in
            string outcomeString = "Gavin is my name";
          

            GraphicsDevice.Clear(bcolor);

            spriteBatch.Begin();
            
            //vector2 which mesures the size of the string
            Vector2 strsiz =  font.MeasureString(outcomeString);
            //x and y of vector cast to an int
            int strx = (int)strsiz.X;
            int stry = (int)strsiz.Y;
            
            //new rectangle made with x and y of 10,10 and width of strx and height of stry
            Rectangle rec = new Rectangle(10, 10, strx, stry);
           
            //method draw rectangle called passing in spritebatch, rectangle r, a color, and width of the line
            Game1.DrawRectangle(spriteBatch,rec,Color.Red, 2);
            Game1.DrawRectangle(spriteBatch, rec, Color.Red, 2);

            //string printed to the screen
            spriteBatch.DrawString(font, outcomeString, new Vector2(10,10), tcolor);
            spriteBatch.DrawString(font, "sideways", new Vector2(100, 150), tcolor, (float)(Math.PI / 2), new Vector2(32, 19), 1.0f, SpriteEffects.None, 0.5f);
           
           
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        //static texture2d called gTexture
        static Texture2D gTexture;
        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int WidthofLine)
        {
            if (gTexture == null)
            {
                gTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                gTexture.SetData<Color>(new Color[] { Color.White });
            }


            //draws 4 lines to make up rectangle
            spriteBatch.Draw(gTexture, new Rectangle(rectangle.X, rectangle.Y, WidthofLine, rectangle.Height + WidthofLine), color);
            spriteBatch.Draw(gTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + WidthofLine, WidthofLine), color);
            spriteBatch.Draw(gTexture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, WidthofLine, rectangle.Height + WidthofLine), color);
            spriteBatch.Draw(gTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + WidthofLine, WidthofLine), color);
            
        }     
        
        
    }
}
