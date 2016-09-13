public class Solution
{
	public bool CanConstruct(string ransomNote, string magazine)
	{
		var dic = new int[26];

		foreach (var c in magazine)
		{
			dic[c - 'a']++;
		}

		foreach (var c in ransomNote)
		{
			if (dic[c - 'a'] == 0)
				return false;
			dic[c - 'a']--;
		}
		return true;
	}
}
	