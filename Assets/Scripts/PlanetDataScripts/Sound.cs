using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip clip;

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
    }
}
