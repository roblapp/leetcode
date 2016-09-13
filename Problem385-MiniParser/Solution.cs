public class Solution
{
	public NestedInteger Deserialize(string s)
	{
		if (string.IsNullOrWhiteSpace(s))
			return null;

		if (s[0] != '[')
			return new NestedInteger(int.Parse(s));

		var array = SpecialSplit(s.Substring(1, s.Length - 2));
		var nested = new NestedInteger();

		foreach (var temp in array.Select(Deserialize))
		{
			nested.Add(temp);
		}

		return nested;
	}

	private static IEnumerable<string> SpecialSplit(string s)
	{
		//needs to split things such as 123,[456,[789]] into 2 elements "123" , "[456,[789]]" and not 3 elements like string.Split would... "123" , "[456" , "[789]]"
		var bracketCount = 0;
		var index = 0;
		var len = 0;
		var result = new List<string>();

		for (var i = 0; i < s.Length; i++)
		{
			if (s[i] == '[') bracketCount++;
			else if (s[i] == ']') bracketCount--;

			if (s[i] == ',' && bracketCount == 0)
			{
				if (len > 0)
					result.Add(s.Substring(index, len));
				index = i + 1;
				len = 0;
			}
			else
				len++;
		}
		if (len > 0)
			result.Add(s.Substring(index, len));
		return result;
	}
}
