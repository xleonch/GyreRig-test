using System;
public class ClickerModel
{
    public event Action<int> OnScoreUpdated;

    private int m_Score;
    public int Score
    {
        get => m_Score;
        set
        {
            if (m_Score != value)
            {
                OnScoreUpdated?.Invoke(value);
                m_Score = value;
            }
        }
    }
}
