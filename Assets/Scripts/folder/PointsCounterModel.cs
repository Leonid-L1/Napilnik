using System;

public class PointsCounterModel
{   
    private int _score = 0;

    public event Action<int> ScoreUpdated;

    public void IncreaseCounter() 
    {
        _score++;
        ScoreUpdated(_score);
    }
}
