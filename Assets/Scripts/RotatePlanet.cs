using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 10f, 0); // degrees/sec
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }
}
