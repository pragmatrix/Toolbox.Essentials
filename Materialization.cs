using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Toolbox
{
	public interface IMaterialized<out ElementT> : IEnumerable<ElementT>
	{
	}

	public static class MaterializationExtensions
	{
		public static IMaterialized<ElementT> materialize<ElementT>(this IEnumerable<ElementT> enumerable)
		{
			var materialized = enumerable as IMaterialized<ElementT>;
			if (materialized != null)
				return materialized;

			var array = enumerable as ElementT[];
			if (array != null)
				return new Materialized<ElementT>(array);

			return new Materialized<ElementT>(enumerable.ToArray());
		}

		// this is quite handy to avoid casts.

		public static IEnumerable<ElementT> toEnumerable<ElementT>(this IMaterialized<ElementT> materialized)
		{
			return materialized;
		}

		sealed class Materialized<ElementT> : IMaterialized<ElementT>
		{
			readonly IEnumerable<ElementT> _materialized;

			public Materialized(IEnumerable<ElementT> enumerable)
			{
				_materialized = enumerable;
			}

			public IEnumerator<ElementT> GetEnumerator()
			{
				return _materialized.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return _materialized.GetEnumerator();
			}
		}
	}

}
