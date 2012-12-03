using System.Dynamic;
using System.Text.RegularExpressions;

namespace Toolbox.Parsing
{
	public static class RegexParser
	{
		public static dynamic tryParse(this string str, string regexPattern)
		{
			var rx = new Regex(regexPattern, RegexOptions.CultureInvariant);
			var m = rx.Match(str);
			if (!m.Success || m.Value != str)
				return null;

			return new ResultObject(m);
		}

		sealed class ResultObject : DynamicObject
		{
			readonly Match _match;

			public ResultObject(Match match)
			{
				_match = match;
			}

			public override bool TryGetMember(GetMemberBinder binder, out object result)
			{
				var group = _match.Groups[binder.Name];
				result = group.Success ? group.Value : null;
				return true;
			}
		}
	}

}
