using System.Globalization;

namespace Toolbox
{
	/*
		Culture invariant helpers.

		Because nasty stuff happens:
		http://stackoverflow.com/questions/2720024/int-parse-of-8-fails-int-parse-always-requires-cultureinfo-invariantculture
	*/

	public static class Invariant
	{
		public static int parseInt(string v)
		{
			return int.Parse(v, CultureInfo.InvariantCulture);
		}

		public static int? tryParseInt(string v)
		{
			int result;
			return int.TryParse(v, NumberStyles.Integer, CultureInfo.InvariantCulture, out result) ? (int?) result : null;
		}

		public static uint parseUInt(string v)
		{
			return uint.Parse(v, CultureInfo.InvariantCulture);
		}

		public static uint? tryParseUInt(string v)
		{
			uint result;
			return uint.TryParse(v, NumberStyles.Integer, CultureInfo.InvariantCulture, out result) ? (uint?)result : null;
		}
	}
}
