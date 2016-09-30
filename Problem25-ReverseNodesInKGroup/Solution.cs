/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (head == null) return null;
        if (head.next == null) return head;

        ListNode prev = null;
        ListNode cur = head;
        ListNode next = null;

        var i = 1;

        //If we have less than K items, return this head
        while (i < k)
        {
            cur = cur.next;
            if (cur == null)
            {
                return head;
            }
            i++;
        }

        i = 0;
        cur = head;
        while (i < k)
        {
            next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
            if (cur == null)
            {
                return prev;
            }
            i++;
        }
        head.next = ReverseKGroup(next, k);
        return prev;
    }
}
