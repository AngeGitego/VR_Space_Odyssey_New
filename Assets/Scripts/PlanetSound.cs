using UnityEngine;

public class PlanetSound : MonoBehaviour
{
    [Header("Assign a unique sound per planet")]
    public AudioClip planetSound;
    private AudioSource audioSource;

    void Awake()
    {
        // Add and configure AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f; // 3D sound
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.minDistance = 1.5f;
        audioSource.maxDistance = 25f;
        audioSource.clip = planetSound;
    }

    // Clicking in Editor / Desktop
    void OnMouseDown()
    {
        PlayClip();
    }

    // Public method for XR or other callers
    public void PlayClip()
    {
        if (planetSound == null) return;
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(planetSound);
    }
}
