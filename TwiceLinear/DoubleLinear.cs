namespace TwiceLinear
{
    public class DoubleLinear
    {
        private static readonly DoubleLinearSequence Sequence = new DoubleLinearSequence();
        
        public static int DblLinear(int n)
        {
            var s = new DoubleLinearSequence();
            return s.GetValue(n);
        }
    }
}