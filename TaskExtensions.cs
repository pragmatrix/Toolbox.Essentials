using System;
using System.Threading.Tasks;

namespace Toolbox
{
	public static class TaskExtensions
	{
		public static void WaitCompletedOrCancelled(this Task task)
		{
			try
			{
				task.Wait();
			}
			catch (Exception)
			{
				if (task.IsFaulted)
					throw;
			}
		}
	}
}
