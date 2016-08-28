public class Solution {
	//Not a very clean solution...
    public IList<Interval> Merge(IList<Interval> intervals)
    {
        var soln = new List<Interval>();

        if (intervals == null || intervals.Count == 0)
            return soln;
		
		//Cannot cast an IList to a List with Mono compiler...
        var tempList = new List<Interval>(intervals);
        tempList.Sort((a, b) =>
        {
            if (a.start < b.start)
                return -1;
            if (a.start > b.start)
                return 1;
            return a.end - b.end;
        });

        var index = 1;
        var temp = tempList[0];

        while (index < tempList.Count)
        {
            if (IsOverlapped(temp, tempList[index]))
            {
                temp.end = Math.Max(temp.end, tempList[index].end);
            }
            else
            {
                soln.Add(temp);
                temp = tempList[index];
            }
            index++;
        }
        soln.Add(temp);
        return soln;
    }
    
    static bool IsOverlapped(Interval p0, Interval p1)
    {
        return p1.start <= p0.end;
    }
}
