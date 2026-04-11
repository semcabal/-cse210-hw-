public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) 
        : base(name, description, -Math.Abs(points))
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetDetailsString()
    {
        return $"[-] {_shortName} ({_description}) - Lose {Math.Abs(_points)} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{Math.Abs(_points)}";
    }

    public override bool IsCompleted() => false;
}