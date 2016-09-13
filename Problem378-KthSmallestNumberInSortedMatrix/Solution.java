public class Solution {
    public int kthSmallest(int[][] matrix, int k) {
		int n = matrix.length;
		int left = matrix[0][0];
		int right = matrix[n - 1][n - 1];

		while (left < right) {
			int mid = left + (right - left) / 2;
			int count = 0;
			for (int i = 0; i < n; i++) {
				count += upperBound(matrix[i], mid);
			}
			if (count < k) {
				left = mid + 1;
			} else {
				right = mid;
			}
		}
		return left;
	}

	public int upperBound(int[] a, int x) {
		int low = 0;
		int high = a.length;

		while (low < high) {
			int mid = low + (high - low) / 2;
			if (x >= a[mid]) {
				low = mid + 1;
			} else {
				high = mid;
			}
		}
		return low;
	}
}
