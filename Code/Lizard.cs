/*	pi.exe

	Lizard Class: The Lizard State Machine.

	Started: 1 February 2021
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using EndlessTrash;
using MessiahQuestII.Art;
using MessiahQuestII.Music;

namespace LizardAI
{
	public class Lizard
	{
		// Fields
		private LizardState _state;

		private Sprite p;
		private int timer;
		private Random rand;
		private List<string> farts;

		// Properties
		public LizardState State
		{
			get { return _state; }
			set
			{
				if (value == LizardState.Fart)
				{
					SongLoader.GetSong(farts[rand.Next(0, 4)]).Play();
				}
				else if (value == LizardState.Rip)
				{
					SongLoader.GetSong("DiseasedFart.wav").Play();
				}

				_state = value;
				p.PlayAnimation((byte)_state);
			}
		}
		public bool Hovering { get; set; }

		// Events
		public Action Rip;

		// Constructor
		public Lizard()
		{
			p = new Sprite(GraphicsLoader.GetBitmap("Spritesheet.png"), new Rectangle(0, 0, 256, 256), 256, 256, 4);
			timer = -1;
			rand = new Random();
			farts = new List<string>(){ "Fart1.wav", "Fart2.wav", "Fart3.wav", "FartWithReverb.wav" };

			State = LizardState.Idle;
			Hovering = false;

			Program.Clock.Tick += update;
		}

		// Event Handlers
		private void update(object sender, EventArgs e)
		{
			if (!p.Playing)
			{
				if (State == LizardState.Idle)
				{
					if (timer == -1)
					{
						timer = rand.Next(60, 240);
					}

					if (timer > 0)
						--timer;

					if (timer == 0)
					{
						State = LizardState.Cough;
						timer = -1;
					}
				}
				else if (State == LizardState.Cough)
				{
					State = LizardState.Idle;
				}
				else if (State == LizardState.Chuckle)
				{
					if (Hovering)
					{
						p.Playing = true;
					}
					else
					{
						State = LizardState.Cough;
					}
				}
				else if (State == LizardState.Fart)
				{
					State = LizardState.Chuckle;
				}
				else if (State == LizardState.Rip)
				{
					if (Rip != null)
						Rip();
				}
			}
		}
	}
}