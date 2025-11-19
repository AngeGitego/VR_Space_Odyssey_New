using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform sun;      // The object this planet will orbit
    public float orbitSpeed;   // Speed of the orbit
    public float rotationSpeed; // How fast the planet rotates on itself

    void Update()
    {
        // Orbit around the Sun
        if (sun != null)
        {
            transform.RotateAround(sun.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }

        // Self rotation (planet spinning)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
