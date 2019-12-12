namespace TwiceLinear
{
    public class DoubleLinear
    {
        private static readonly DoubleLinearSequence Sequence = new DoubleLinearSequence();
        
        public static int DblLinear(int n)
        {
            return (int) Sequence.GetValue(n);
        }
    }
}