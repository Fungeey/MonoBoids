using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Boids.Boids {
	static class FlockBehaviour {

		public static Vector2 Avoidance(Boid boid, List<Boid> boids) {
			var radius = 25;
			var avoid = new Vector2();
			var count = 0;

			foreach (Boid other in boids) {
				if (Math.Abs((boid.cellPosition - other.cellPosition).Length()) > 1)
					continue;

				var distance = Vector2.Distance(boid.position, other.position);
					
				if (distance < radius && distance > 0) {
					avoid += (boid.position - other.position) / (float)Math.Pow(distance, 2);
					count++;
				}
			}

			if (count != 0)
				avoid /= count;

			if (avoid.Length() > 0)
				avoid.Normalize();
			else
				avoid = Vector2.Zero;

			return avoid;
		}

		public static Vector2 AvoidPoints(Boid boid, List<Vector2> points) {
			var radius = 25;
			var avoid = new Vector2();
			var count = 0;

			foreach (Vector2 point in points) {
				var distance = Vector2.Distance(boid.position, point);

				if (distance < radius && distance > 0) {
					avoid += (boid.position - point) / (float)Math.Pow(distance, 5);
					count++;
				}
			}

			if (count != 0)
				avoid /= count;

			if (avoid.Length() > 0)
				avoid.Normalize();
			else
				avoid = Vector2.Zero;

			return avoid;
		}

		public static Vector2 Alignment(Boid boid, List<Boid> boids) {
			var radius = 100;
			var align = new Vector2();
			var count = 0;

			foreach (Boid other in boids) {
				if (Math.Abs((boid.cellPosition - other.cellPosition).Length()) > 1)
					continue;

				var distance = Vector2.Distance(boid.position, other.position);

				if (distance < radius && distance > 0) {
					align += other.velocity;
					count++;
				}
			}

			if (count != 0)
				align /= count;

			var dir = align - boid.velocity;
			dir.Normalize();
			return dir;
		}

		public static Vector2 Cohesion(Boid boid, List<Boid> boids) {
			var radius = 100;
			var cohere = new Vector2();
			var count = 0;

			foreach (Boid other in boids) {
				if (Math.Abs((boid.cellPosition - other.cellPosition).Length()) > 1)
					continue;

				var distance = Vector2.Distance(boid.position, other.position);

				if (distance < radius && distance > 0) {
					cohere += other.position;
					count++;
				}
			}

			if (count != 0)
				cohere /= count;

			var dir = cohere - boid.position;
			dir.Normalize();
			return dir;
		}
	}
}
