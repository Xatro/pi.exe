/*	XATRO GAMES Presents
	MESSIAH QUEST II

	SongLoader Class: A utility which loads songs embedded in the assembly.
	Started: 21 August 2016
*/

using System.Media;
using System.Reflection;

namespace MessiahQuestII.Music
{
	public static class SongLoader
	{
		// Field
		private static Assembly assembly = Assembly.GetExecutingAssembly();

		// Methods
		public static SoundPlayer GetSong(string songName)
		{
			return new SoundPlayer(assembly.GetManifestResourceStream(songName));
		}
	}
}