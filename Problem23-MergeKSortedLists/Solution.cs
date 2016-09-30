/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
        {
            return null;
        }
        return MergeKListsHelper(lists, 0, lists.Length - 1);
    }

    private static ListNode MergeKListsHelper(ListNode[] lists, int low, int high)
    {
        if (low == high)
        {
            return lists[low];
        }
        if (high - low + 1 == 2)
        {
            var temp = Merge2Lists(lists[low], lists[high]);
            return temp;
        }

        var mid = low + (high - low)/2;
        var left = MergeKListsHelper(lists, low, mid);
        var right = MergeKListsHelper(lists, mid + 1, high);
        return Merge2Lists(left, right);
    }

    private static ListNode Merge2Lists(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode(0);
        var prev = dummy;

        while (l1 != null && l2 != null)
        {
            if (l1.val < l2.val)
            {
                prev.next = new ListNode(l1.val);
                l1 = l1.next;
            }
            else
            {
                prev.next = new ListNode(l2.val);
                l2 = l2.next;
            }
            prev = prev.next;
        }

        while (l1 != null)
        {
            prev.next = new ListNode(l1.val);
            prev = prev.next;
            l1 = l1.next;
        }

        while (l2 != null)
        {
            prev.next = new ListNode(l2.val);
            prev = prev.next;
            l2 = l2.next;
        }
        return dummy.next;
    }
}
