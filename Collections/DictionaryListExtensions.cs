using System;
using System.Collections.Generic;
using System.Linq;

namespace Toolbox.Collections
{
	public static class DictionaryListExtensions
	{
		public static void addElement<KeyT, ElementT>(this Dictionary<KeyT, List<ElementT>> dict, KeyT key, ElementT element)
		{
			List<ElementT> list;
			if (!dict.TryGetValue(key, out list))
			{
				list = new List<ElementT>();
				dict.Add(key, list);
			}

			list.Add(element);
		}

		public static bool removeElement<KeyT, ElementT>(this Dictionary<KeyT, List<ElementT>> dict, KeyT key, ElementT element)
		{
			List<ElementT> list;
			if (!dict.TryGetValue(key, out list))
				return false;

			bool r = list.Remove(element);

			if (list.Count == 0)
				dict.Remove(key);

			return r;
		}

		public static int removeElements<KeyT, ElementT>(this Dictionary<KeyT, List<ElementT>> dict, KeyT key, Predicate<ElementT> whichToRemove)
		{
			List<ElementT> list;
			if (!dict.TryGetValue(key, out list))
				return 0;

			int r = list.RemoveAll(whichToRemove);

			if (list.Count == 0)
				dict.Remove(key);

			return r;
		}

		public static bool containsElement<KeyT, ElementT>(this Dictionary<KeyT, List<ElementT>> dict, KeyT key, ElementT element)
		{
			List<ElementT> list;
			return dict.TryGetValue(key, out list) && list.Contains(element);
		}

		// returns an empty sequence if the key is not found.

		public static IEnumerable<ElementT> getElements<KeyT, ElementT>(this Dictionary<KeyT, List<ElementT>> dict, KeyT key)
		{
			List<ElementT> list;
			return dict.TryGetValue(key, out list) ? list : Enumerable.Empty<ElementT>();
		}
	}
}
