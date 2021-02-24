using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

public class CubeMovement : MonoBehaviour
{
    public DoomedCube prefab;
    private static readonly CultureInfo m_culture = new CultureInfo("en-US");
    public struct InputData
    {
        public string label;
        public string input;
        public float value;
        public bool isValid;

        public InputData(string label)
        {
            this.label = label;
            input = string.Empty;
            value = default;
            isValid = default;
        }
    }

    private InputData m_InputDelay = new InputData("Creation Delay:");
    private InputData m_InputVelocity = new InputData("Velocity:");
    private InputData m_InputDistance = new InputData("Distance:");

    private IEnumerator currentProcess;

    protected void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "Task_1")
            GUI.enabled = false;
        else
        {
            Input(ref m_InputDistance);
            Input(ref m_InputVelocity);
            Input(ref m_InputDelay);

            GUI.enabled = m_InputDelay.isValid &&
                          m_InputVelocity.isValid &&
                          m_InputDistance.isValid;
            if (GUILayout.Button("Update"))
            {
                if (currentProcess != null)
                {
                    StopCoroutine(currentProcess);
                }
                currentProcess = DelayedSpawn(m_InputDelay.value, m_InputVelocity.value, m_InputDistance.value);
                StartCoroutine(currentProcess);
            }
            GUI.enabled = true;
            if (GUILayout.Button("Change scene"))
                SceneManager.LoadScene("Task_1");
        }
    }

    public void Input(ref InputData data)
    {
        GUILayout.Label(data.label);
        var newInput = GUILayout.TextField(data.input, 25);
        if (newInput != data.input)
        {
            if (Regex.IsMatch(newInput, @"^(?:(?:(?:0|[1-9]\d*)(?:\.(?:\d+)?)?)?)?$"))
            {
                data.isValid = float.TryParse(newInput, NumberStyles.Number, m_culture, out var updatedValue);
                data.input = newInput;
                if (data.isValid)
                    data.value = updatedValue;
            }
        }
    }

    public IEnumerator DelayedSpawn(float creationDelay, float velocity, float distance)
    {
        while (true)
        {
            yield return new WaitForSeconds(creationDelay);

            var cube = Instantiate(prefab);
            cube.velocity = velocity;
            cube.distance = distance;
        }
    }
}