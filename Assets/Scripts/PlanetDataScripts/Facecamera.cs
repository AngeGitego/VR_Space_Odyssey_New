using UnityEngine;

public class Facecamera : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main)
            transform.LookAt(Camera.main.transform);
    }
}
