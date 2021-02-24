using UnityEngine;

public class ClickerView
{
    private ClickerController m_Controller;
    private string m_Label;

    public ClickerView(ClickerModel model, ClickerController controller)
    {
        OnScoreUpdated(model.Score);
        model.OnScoreUpdated += OnScoreUpdated;
        m_Controller = controller;
    }

    private void OnScoreUpdated(int score)
    {
        m_Label = $"Clicks:  {score}";
    }

    public void Update()
    {
        GUILayout.Label(m_Label);
        if (GUILayout.Button("Click!"))
            m_Controller.IncrementScore();
    }
}