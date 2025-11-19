using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class AutoTeleportPointGenerator : MonoBehaviour
{
    [Header("Assign all planets (Sun optional)")]
    public List<Transform> planets;

    [Header("Teleport Anchor Settings")]
    public Vector3 offsetFromPlanet = new Vector3(0, 1.5f, 3f);
    public GameObject teleportAnchorPrefab;

    void Start()
    {
        GenerateTeleportPoints();
    }

    void GenerateTeleportPoints()
    {
        foreach (Transform planet in planets)
        {
            // Create parent object
            GameObject anchor = new GameObject(planet.name + "_TeleportPoint");
            anchor.transform.position = planet.position + offsetFromPlanet;
            anchor.transform.SetParent(planet);

            // Add Teleportation Anchor
            var teleportAnchor = anchor.AddComponent<TeleportationAnchor>();

            // Add collider for interaction
            SphereCollider col = anchor.AddComponent<SphereCollider>();
            col.isTrigger = true;
            col.radius = 0.5f;

            // Add simple visual
            GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            marker.transform.SetParent(anchor.transform);
            marker.transform.localPosition = Vector3.zero;
            marker.transform.localScale = Vector3.one * 0.2f;
            Destroy(marker.GetComponent<Collider>());

            Debug.Log("Created teleport anchor for: " + planet.name);
        }

        Debug.Log("✔ All teleport points generated!");
    }
}
