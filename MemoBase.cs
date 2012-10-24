using System;
using System.Collections.Generic;

namespace Toolbox
{
	public abstract class MemoBase : IDisposable
	{
		readonly Stack<Action> _actions = new Stack<Action>();

		public void Dispose()
		{
			while (_actions.Count != 0)
				_actions.Pop()();
		}

		protected void memo(Action action)
		{
			_actions.Push(action);
		}

		protected void memo(IDisposable disposable)
		{
			memo(disposable.Dispose);
		}
	}
}
