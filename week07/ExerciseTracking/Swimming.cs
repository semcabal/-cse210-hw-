using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;
        private const double LapLengthMeters = 50;
        private const double MetersToMiles = 0.000621371;

        public Swimming(DateTime date, int lengthInMinutes, int laps) 
            : base(date, lengthInMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return _laps * LapLengthMeters / 1000 * MetersToMiles;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / GetLengthInMinutes()) * 60;
        }

        public override double GetPace()
        {
            return GetLengthInMinutes() / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{GetDate():dd MMM yyyy} Swimming ({GetLengthInMinutes()} min) - " +
                   $"Distance: {GetDistance():F2} miles, " +
                   $"Speed: {GetSpeed():F2} mph, " +
                   $"Pace: {GetPace():F2} min per mile, " +
                   $"Laps: {_laps}";
        }
    }
}