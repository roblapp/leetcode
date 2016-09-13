/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (head == null) return null;
        var node = new ListNode(0);
        node.next = head;
        RemoveNthFromEndHelper(node, n);
        head = node.next;
        return head;
    }

    private int RemoveNthFromEndHelper(ListNode node, int n)
    {
        if (node.next == null) return 0;
        var count = RemoveNthFromEndHelper(node.next, n);
        if (count + 1 == n) node.next = node.next.next;
        return count + 1;
    }
}
