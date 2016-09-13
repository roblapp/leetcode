/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        var temp = new ListNode(0);
        ListNode prev = temp;

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
        return temp.next;
    }
}
