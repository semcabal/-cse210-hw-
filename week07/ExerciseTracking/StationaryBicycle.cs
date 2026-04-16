using System;

namespace ExerciseTracking
{
    public class StationaryBicycle : Activity
    {
        private double _speed;

        public StationaryBicycle(DateTime date, int lengthInMinutes, double speed) 
            : base(date, lengthInMinutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return _speed * (GetLengthInMinutes() / 60.0);
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            return 60 / _speed;
        }

        public override string GetSummary()
        {
            return $"{GetDate():dd MMM yyyy} Stationary Bicycle ({GetLengthInMinutes()} min) - " +
                   $"Distance: {GetDistance():F1} miles, " +
                   $"Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }
}