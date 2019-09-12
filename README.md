# MonoBoids
![Game Screenshot](/Images/Boids.png)


### Project Description
MonoBoids is a C# implementation of [Boids](https://en.wikipedia.org/wiki/Boids), using [Monogame](http://www.monogame.net/) for graphics. 

### Boids
Boids are an [emergent](https://en.wikipedia.org/wiki/Emergence) artifical life program which simulates the flocking behaviour of birds or schools of fish. The name Boid comes from "bird-oid", referring to something similar to a bird.

##### Flocking Behaviour
A "flock" of boids is created through the emergent behaviour of 3 simple rules:

- **Avoidance**: Boids steer away from it's neighbours if they are too close.
- **Alignment**: Boids steer in a similar direction as all of it's neighbours.
- **Coherence**: Boids steer towards the centre of it's neighbours.

These three simple behaviours acting on each boid produce a swarm-like behaviour.

### Optimisation Strategies
- I originally attempted to implement this in Python, but the simulation had a hard time handling more than 50 boids at a time. Using C# and Monogame however, I could easily simulate 400-500 boids with the same algorithm. 
- I further optimized this by using threading (all of the flocking behaviour runs on a separate thread). This made the drawing smoother, even when the number of boids causes the program to lag.
- Lastly, I reduced the number of distance calculations by separating boids into different "cells" (as shown by the blue grid in the screenshot). Each boid then only has to worry about boids in the cells adjacent to it's own. 
- The final simulation can run up to 700 boids at full speed (~800 boids is where it becomes a bit choppy.)
- (All of these benchmarks are run on my machine)

### Installation
Run Boids.exe to start the simulation.
