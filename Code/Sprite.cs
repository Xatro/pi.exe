/*	Endless Trash

	Sprite Class: Draws an animated image using a sprite sheet.

	Started: 29 April 2019

	Edited: 1 February 2021 (pi.exe)
	-Uses rows for multiple animations on one sheet.
*/

using System;
using System.Drawing;

namespace EndlessTrash
{
	public class Sprite : IDrawable
	{
		// Fields
		Bitmap spritesheet;
		Rectangle area;
		byte frame;
		byte row;
		int frameWidth;
		int frameHeight;
		byte numberOfFrames;
		byte frameDelay;
		byte timer;
		bool loop;

		// Properties
		public byte Layer { get; set; }
		public bool Visible { get; set; }
		public bool Playing { get; set; }
		public int X
		{
			get { return area.X; }
		}

		// Constructor
		public Sprite(Bitmap i, Rectangle a, int width, int height, byte delay = 1, bool looping = false)
		{
			Layer = 1;
			Visible = true;
			Playing = false;

			spritesheet = i;
			area = a;
			frame = 0;
			row = 0;
			frameWidth = width;
			frameHeight = height;
			numberOfFrames = (byte)(spritesheet.Width / frameWidth);
			frameDelay = delay;
			loop = looping;

			Program.Window.Images.Add(this);
			Program.Clock.Tick += update;
		}

		// Methods
		public void Draw(Graphics graphics)
		{
			graphics.DrawImage(spritesheet, area,
				frame * frameWidth, row * frameHeight, frameWidth, frameHeight,
				GraphicsUnit.Pixel);
		}
		public void Translate(int x)
		{
			area.X += x;
		}
		public void PlayAnimation(byte id)
		{
			row = id;
			frame = 0;
			Playing = true;
		}

		// Event Handler
		private void update(object sender, EventArgs e)
		{
			if (Playing)
			{
				if (timer % frameDelay == 0)
				{
					++frame;
					if (frame >= numberOfFrames)
					{
						if (loop)
						{
							frame = 0;
						}
						else
						{
							frame = (byte)(numberOfFrames - 1);
							Playing = false;
						}
					}
				}

				++timer;
			}
		}
	}
}