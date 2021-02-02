/*	Endless Trash

	frmMain Class: The main form which will play the animation.

	Started: 8 April 2019

	Edited: 1 February 2021 (pi.exe)
	-Window is now 256x256 with transparent background.
	-Movie is replaced by Lizard.
	-Responds to user input.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using LizardAI;
using MessiahQuestII.Art;

namespace EndlessTrash
{
	public class frmMain : Form
	{
		// Fields
		private Lizard p;

		// Property
		public List<IDrawable> Images { get; set; }

		// Constructor
		public frmMain() : base()
		{
			ClientSize = new Size(256, 256);
			TransparencyKey = Color.Magenta;
			BackColor = Color.Magenta;
			FormBorderStyle = FormBorderStyle.None;
			Font = new Font(FontFamily.GenericMonospace, 16f);
			Text = "P";
			Icon = GraphicsLoader.GetIcon();
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			Images = new List<IDrawable>();
			MouseEnter += frmMain_MouseEnter;
			MouseLeave += frmMain_MouseLeave;
			Click += frmMain_Click;
			KeyDown += frmMain_KeyDown;
			Paint += frmMain_Paint;
			Program.Clock.Tick += update;

			Program.Window = this;

			p = new Lizard();
			p.Rip += p_Rip;
		}

		// Event Hanlders
		private void frmMain_MouseEnter(object sender, EventArgs e)
		{
			p.State = LizardState.Chuckle;
			p.Hovering = true;
		}
		private void frmMain_MouseLeave(object sender, EventArgs e)
		{
			p.Hovering = false;
		}
		private void frmMain_Click(object sender, EventArgs e)
		{
			p.State = LizardState.Fart;
		}
		private void frmMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				p.State = LizardState.Rip;
			}
		}
		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
			var imagesToDraw = from image in Images
				where image.Visible
				orderby image.Layer
				select image;

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

			foreach (var image in imagesToDraw)
			{
				image.Draw(e.Graphics);
			}
		}
		private void update(object sender, EventArgs e)
		{
			Invalidate();
		}
		private void p_Rip()
		{
			Application.Exit();
		}
	}
}