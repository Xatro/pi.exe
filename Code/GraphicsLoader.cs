/*	XATRO GAMES Presents
	MESSIAH QUEST II

	GraphicsLoader Class: A utility which loads graphics embedded in the assembly.
	Started: 21 August 2016

	Edited: 1 February 2021 (pi.exe)
	-Removed code specific for that other thing I'm working on...
	-The Icon is named p.
*/

using System.Drawing;
using System.Reflection;

namespace MessiahQuestII.Art
{
	public static class GraphicsLoader
	{
		// Field
		private static Assembly assembly = Assembly.GetExecutingAssembly();

		// Methods
		public static Bitmap GetBitmap(string imageName)
		{
			return new Bitmap(assembly.GetManifestResourceStream(imageName));
		}
		public static Icon GetIcon()
		{
			return new Icon(assembly.GetManifestResourceStream("p.ico"));
		}
	}
}