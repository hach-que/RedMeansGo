using System;

namespace Protogame.SHMUP
{
    public class ShmupWorld : World
    {
        /// <summary>
        /// A reference to the player entity.
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// Spawns a specified player at the specified location, replacing the existing
        /// player instance in the world.
        /// </summary>
        /// <typeparam name="T">The type of player to spawn.</typeparam>
        /// <param name="x">The X position to spawn the player at.</param>
        /// <param name="y">The Y position to spawn the player at.</param>
        public void SpawnPlayer<T>(float x, float y) where T : Player, new()
        {
            if (this.Player != null)
                this.Entities.Remove(this.Player);
            this.Player = new T() { X = x, Y = y };
            this.Entities.Add(this.Player);
        }

        public override void DrawBelow(Protogame.GameContext context)
        {
        }

        public override void DrawAbove(Protogame.GameContext context)
        {
        }

        public override bool Update(Protogame.GameContext context)
        {
            return true;
        }
    }
}

