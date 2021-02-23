using UnityEngine;

public class Clicker : MonoBehaviour
{
    private ClickerView m_View;

    protected void Awake()
    {
        var model = new ClickerModel();
        var controller = new ClickerController(model);
        m_View = new ClickerView(model, controller);
    }

    protected void OnGUI()
    {
        m_View.Update();
    }
}
