using UnityEngine;
public class DoomedCube : MonoBehaviour
{
    public float velocity;
    public float distance;

    protected void Start()
    {
        // t = s / v
        var lifetime = distance / velocity;
        Destroy(gameObject, lifetime);
    }

    public void Update()
    {
        // x = v * t
        transform.position += velocity * Time.deltaTime * transform.forward;
    }
}