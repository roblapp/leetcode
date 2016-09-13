public class Solution
    {
        //Run time: 385 ms
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            Rec(n, 0, 0, 0, string.Empty, result);
            return result;
        }

        public void Rec(int n, int parenCount, int closeCount, int count, string s, IList<string> list)
        {
            if (count == 2*n)
            {
                list.Add(s);
                return;
            }
            if (parenCount < n)
            {
                Rec(n, parenCount + 1, closeCount, count + 1, s + "(", list);
            }
            if (closeCount < parenCount && count > 0)
            {
                Rec(n, parenCount, closeCount + 1, count + 1, s + ")", list);
            }
        }
    }

    ////public class Solution
    ////{

    ////    //Run time: 365 ms
    ////    public IList<string> GenerateParenthesis(int n)
    ////    {
    ////        var result = new List<string>();
    ////        Rec(n, 0, string.Empty, result);
    ////        return result;
    ////    }

    ////    public void Rec(int n, int count, string s, IList<string> list)
    ////    {
    ////        if (count == 2 * n)
    ////        {
    ////            if (IsValid(s))
    ////            {
    ////                list.Add(s);
    ////            }
    ////            return;
    ////        }
    ////        Rec(n, count + 1, s + "(", list);

    ////        Rec(n, count + 1, s + ")", list);
    ////    }

    ////    private static bool IsValid(string s)
    ////    {
    ////        var count = 0;
    ////        foreach (char t in s)
    ////        {
    ////            if (t == '(')
    ////            {
    ////                count++;
    ////            }
    ////            else if (count <= 0)
    ////            {
    ////                return false;
    ////            }
    ////            else
    ////            {
    ////                count--;
    ////            }
    ////        }
    ////        return count == 0;
    ////    }
    ////}
	