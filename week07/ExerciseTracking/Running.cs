using System;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distance;

        public Running(DateTime date, int lengthInMinutes, double distance) 
            : base(date, lengthInMinutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
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
            return $"{GetDate():dd MMM yyyy} Running ({GetLengthInMinutes()} min) - " +
                   $"Distance: {GetDistance():F1} miles, " +
                   $"Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }
}