using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlanetInfo : MonoBehaviour
{
    public AudioClip planetSound;
    public string description;
    public string planetName;
    private AudioSource source;

    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (planetSound != null)
                source.PlayOneShot(planetSound);

            Debug.Log(descriptionText);
        }
    }
}
