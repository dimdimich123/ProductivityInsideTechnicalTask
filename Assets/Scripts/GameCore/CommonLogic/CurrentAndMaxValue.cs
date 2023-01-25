namespace GameCore.CommonLogic
{
    public sealed class CurrentAndMaxValue
    {
        public float Current;
        public float Max;

        public CurrentAndMaxValue(float current, float max)
        {
            Current = current;
            Max = max;
        }
    }
}