using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boids.Boids {
	class Flock {
		private List<Boid> boids;

		private int numBoids = 100;
		private static Random rand = new Random();

		public Flock() {
			boids = new List<Boid>();

			for (int i = 0; i < numBoids; i++) {
				Boid b = new Boid(rand.Next(0, MainGame.screenWidth), rand.Next(0, MainGame.screenHeight), this);
				Add(b);
			}
		}

		public void Add(Boid boid) {
			boids.Add(boid);
		}

		public void Remove(Boid boid) {
			boids.Remove(boid);
		}

		public void Draw(SpriteBatch sb) {
			foreach (Boid b in boids) {
				b.Draw(sb);
			}
		}

		private List<Vector2> GetBorderPoints(Boid boid) {
			return new List<Vector2>() {
			new Vector2(boid.position.X, 0),
			new Vector2(boid.position.X, MainGame.screenHeight),
			new Vector2(0, boid.position.Y),
			new Vector2(MainGame.screenWidth, boid.position.Y)
			};
		}
		
		public void Update() {
			Task.Run(() => {
				foreach (Boid b in boids) {
					b.Accelerate(FlockBehaviour.Avoidance(b, boids) * 1.5f);
					b.Accelerate(FlockBehaviour.AvoidPoints(b, GetBorderPoints(b)) * 5);
					b.Accelerate(FlockBehaviour.Alignment(b, boids) / 1.5f);
					b.Accelerate(FlockBehaviour.Cohesion(b, boids) / 3);
					b.Accelerate(b.velocity/7);
					b.Run();
				}
			});
		}
	}
}
