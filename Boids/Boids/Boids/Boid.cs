using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boids.Boids {
	class Boid {
		public static Texture2D boidSprite;
		private static Random rand = new Random();
		private const int speed = 5;
		private const int turnSpeed = 30/speed;

		public Vector2 position { get; private set; }
		public Vector2 cellPosition { get; private set; }

		public Vector2 velocity = new Vector2(rand.Next() * 2 - 1, rand.Next() * 2 - 1);
		public Vector2 acceleration = new Vector2();
		
		private Flock flock;

		public Boid(int x, int y, Flock flock) {
			this.position = new Vector2(x, y);
			this.flock = flock;
		}

		public void Draw(SpriteBatch sb) {
			sb.Draw(boidSprite, position:position, rotation:GetRotationRad(), origin:new Vector2(5, 5));
			sb.DrawLine(position, position + velocity * 3, Color.Red, thickness: 2);
		}

		public float GetRotationRad() {
			return (float)Math.Atan2(velocity.Y, velocity.X) + MathHelper.PiOver2;
		}

		public void Accelerate(Vector2 accel) {
			acceleration += accel/turnSpeed;
		}

		public void Run() {
			velocity += acceleration;
			acceleration = Vector2.Zero;

			if (Math.Abs(velocity.Length()) > speed) {
				velocity.Normalize();
				velocity *= speed;
			}

			position += velocity;
			cellPosition = new Vector2(position.X / MainGame.cellWidth, position.Y / MainGame.cellHeight);

			Borders();
		}

		private void Borders() {
			if (position.X < 0 || position.X > MainGame.screenWidth ||
				position.Y < 0 || position.Y > MainGame.screenHeight)
				position = new Vector2(MainGame.screenWidth / 2, MainGame.screenHeight / 2);
		}
	}
}
