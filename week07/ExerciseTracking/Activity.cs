using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _lengthInMinutes;

        public Activity(DateTime date, int lengthInMinutes)
        {
            _date = date;
            _lengthInMinutes = lengthInMinutes;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public int GetLengthInMinutes()
        {
            return _lengthInMinutes;
        }

    
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{_date:dd MMM yyyy} Activity ({_lengthInMinutes} min) - " +
                   $"Distance: {GetDistance():F1} miles, " +
                   $"Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }
}