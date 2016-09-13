/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		var dummyHead = new ListNode(0);
		AddTwoNumbersHelper(
			dummyHead,
			l1,
			l2,
			0);
		return dummyHead.next;
	}

	private void AddTwoNumbersHelper(ListNode prev, ListNode l1, ListNode l2, int carry)
	{
		while (true)
		{
			if (l1 == null && l2 == null && carry == 0) return;

			var sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;

			prev.next = new ListNode(sum%10);
			prev = prev.next;
			l1 = l1 == null ? null : l1.next;
			l2 = l2 == null ? null : l2.next;
			carry = sum/10;
		}
	}
}
