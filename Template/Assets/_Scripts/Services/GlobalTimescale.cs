namespace _Scripts.Services
{
    public static class GlobalTimescale
    {
        public static int Timescale = 1;

        public static void StopTime() => Timescale = 0;
        public static void StartTime() => Timescale = 1;
    }
}