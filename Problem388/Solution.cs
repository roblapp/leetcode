



public class Solution
{
	public int LengthLongestPath(string input)
	{
		var i = 0;
		var level = 0;
		var count = 0;
		var infile = false;
		var result = 0;
		var levelMap = new Dictionary<int, int>();
		//dir\nfile.txt
		//dir\n\tsubdir1\n\tfile.txt
		//dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext
		while (true)
		{
			if (input[i] == '.')
			{
				infile = true;
				count++;
			}
			else if (input[i] == '\n')
			{
				if (infile)
				{
					//Compute
					var sum = 0;
					for (var j = 0; level > 0 && j < level; j++)
					{
						int value;
						var isOk = levelMap.TryGetValue(j, out value);
						if (isOk)
						{
							sum += value;
						}
					}
					result = Math.Max(result, sum + level + count);
				}
				else
				{
					levelMap[level] = count;
				}
				level = 0;
				count = 0;
				infile = false;
			}
			else if (input[i] == '\t')
			{
				level++;
				infile = false;
			}
			else
			{
				count++;
			}
			i++;
			if (i == input.Length)
			{
				if (infile)
				{
					//Compute
					var sum = 0;
					for (var j = 0; level > 0 && j < level; j++)
					{
						int value;
						var isOk = levelMap.TryGetValue(j, out value);
						if (isOk)
						{
							sum += value;
						}
					}
					result = Math.Max(result, sum + level + count);
				}
				break;
			}
		}

		return result;
	}
}
	