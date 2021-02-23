public class ClickerController
{
    private ClickerModel m_Model;

    public ClickerController(ClickerModel model)
    {
        m_Model = model;
    }

    public void IncrementScore()
    {
        ++m_Model.Score;
    }
}
