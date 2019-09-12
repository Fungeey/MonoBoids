using Boids.Boids;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Boids {
	public class MainGame : Game {
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public static int screenWidth = 1280;
		public static int screenHeight = 768;

		public static int cellWidth = screenWidth / 30;
		public static int cellHeight = screenHeight / 20;

		Flock flock;

		public MainGame() {
			graphics = new GraphicsDeviceManager(this);

			graphics.PreferredBackBufferWidth = screenWidth;
			graphics.PreferredBackBufferHeight = screenHeight;
			graphics.ApplyChanges();
		}

		protected override void Initialize() {
			base.Initialize();

			flock = new Flock();
		}

		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Boid.boidSprite = Content.Load<Texture2D>("Content/Boid");
		}

		protected override void UnloadContent() {
			spriteBatch.Dispose();
		}

		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			base.Update(gameTime);

			flock.Update();
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.WhiteSmoke);
			base.Draw(gameTime);

			spriteBatch.Begin(samplerState: SamplerState.PointClamp);

			for(int i = 0; i < screenWidth; i += cellWidth) {
				spriteBatch.DrawLine(new Vector2(i, 0), new Vector2(i, screenHeight), Color.CornflowerBlue);
			}

			for (int i = 0; i < screenHeight; i += cellHeight) {
				spriteBatch.DrawLine(new Vector2(0, i), new Vector2(screenWidth, i), Color.CornflowerBlue);
			}

			flock.Draw(spriteBatch);

			spriteBatch.End();
		}
	}
}
