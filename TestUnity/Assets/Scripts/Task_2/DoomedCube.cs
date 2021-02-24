using UnityEngine;
public class DoomedCube : MonoBehaviour
{
    public float velocity;
    public float distance;

    protected void Start()
    {
        var lifetime = distance / velocity;
        Destroy(gameObject, lifetime);
    }

    public void Update()
    {
        transform.position += velocity * Time.deltaTime * transform.forward;
    }
}