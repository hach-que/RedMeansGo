using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protogame;
using Protogame.Platformer;
using Microsoft.Xna.Framework.Audio;

namespace Protogame
{
    public class BackgroundAudioEntity : AudioEntity
    {
        public BackgroundAudioEntity(World world, string name)
            : base(world, name)
        {
        }

		public float Tempo
        {
            get
            {
                return 0;
            }
            set
            {
                this.m_Instance.Pitch = value - 1;
            }
		}

        public override void Update(World rawWorld)
		{
            if (this.m_IsPlaying && this.m_Instance.State != SoundState.Playing)
            {
                this.m_Instance.Play();
                this.RaiseOnPlay();
                this.m_IsPlaying = false;
            }
            else if (!this.m_IsPlaying && !this.IsLooped && this.m_Instance.State == SoundState.Stopped && this.m_HasPlayed)
            {
                if (this.DeleteWhenFinished)
                    this.m_World.Entities.Remove(this);
            }
        }

		public void Start()
		{
            base.IsLooped = true;
			base.Play();
		}
    }
}
