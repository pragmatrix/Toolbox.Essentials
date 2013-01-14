using System;
using System.Threading;
using System.Threading.Tasks;

namespace Toolbox
{
	public static class TaskExtensions
	{
		public static void waitCompletedOrCancelled(this Task task)
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

		/*
			Create a Task cancellation source that is cancelled when the token is cancelled.
			If the Source is cancelled, the token's state is untouched.
		*/

		public static CancellationTokenSource createLinkedSource(this CancellationToken token)
		{
			var source = new CancellationTokenSource();
			// If this token is already in the canceled state, the delegate will be run 
			// immediately and synchronously.
			token.Register(source.Cancel);
			return source;
		}

		public static CancellationToken createLinkedToken(this CancellationToken token)
		{
			return token.createLinkedSource().Token;
		}
	}
}
