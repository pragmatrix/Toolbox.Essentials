namespace Toolbox
{
	public static class Casts
	{
		public static uint unsigned(this int value)
		{
			return (uint) value;
		}

		public static int signed(this uint value)
		{
			return (int) value;
		}

		public static ulong unsigned(this long value)
		{
			return (ulong) value;
		}

		public static long signed(this ulong value)
		{
			return (long) value;
		}
	}
}
