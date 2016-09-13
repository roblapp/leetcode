/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null) return null;
        if (head.next == null) return head;

        var prev = head;
        var cur = head.next;

        prev.next = cur.next;
        cur.next = prev;

        head = cur;
        head.next.next = SwapPairs(head.next.next);

        return head;
    }
}
