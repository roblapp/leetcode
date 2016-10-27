
public class Solution {
    public int Divide(int dividend, int divisor) {
        if (divisor == 1) return dividend;
        var isXPositive = dividend > 0;
        var isYPositive = divisor > 0;

        long x = Math.Abs(Convert.ToInt64(dividend));
        long y = Math.Abs(Convert.ToInt64(divisor));
        int result = 0;
        int power = 32;
        long yPower = y << power;

        while (x >= y)
        {
            while (yPower > x)
            {
                yPower = yPower >> 1;
                --power;
            }
            var temp = 1 << power;
            //result + temp > int.MaxValue
            //->
            //result > int.MaxValue - temp
            if (result > int.MaxValue - temp)
            {
                return int.MaxValue;
            }
            result = result + temp;
            x -= yPower;
        }
        return isXPositive ^ isYPositive ? -result : result;
    }
}
