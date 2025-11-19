using UnityEngine;

using TMPro;

public class PlanetTeleportAndUIManager : MonoBehaviour
{
    [Header("Setup")]
    public Transform sun;                     // Center of orbit
    public PlanetInfo[] planetsInfo;          // Info for planet texts + audio
    public Transform[] planetObjects;         // Your actual planet models
    public GameObject teleportAnchorPrefab;   // Teleport anchor prefab
    public GameObject uiCanvasPrefab;         // UI text prefab

    [Header("Offsets")]
    public float teleportOffset = 3f;         // How far from the planet to place teleport anchor
    public float uiHeightOffset = 2f;         // How high the UI floats above the planet

    void Start()
    {
        for (int i = 0; i < planetObjects.Length; i++)
        {
            Transform planet = planetObjects[i];
            PlanetInfo info = planetsInfo[i];

            // 1. CREATE TELEPORT ANCHOR
            Vector3 anchorPos = planet.position + (planet.position - sun.position).normalized * teleportOffset;
            GameObject anchor = Instantiate(teleportAnchorPrefab, anchorPos, Quaternion.identity);

            // Name it
            anchor.name = info.planetName + "_TeleportAnchor";

            // 2. CREATE UI CANVAS
            GameObject ui = Instantiate(uiCanvasPrefab, planet);
            ui.transform.localPosition = new Vector3(0, uiHeightOffset, 0);

            // Set Text
            TextMeshProUGUI uiText = ui.GetComponentInChildren<TextMeshProUGUI>();
            uiText.text = info.planetName + "\n" + info.description;

            // Always face the player
            ui.AddComponent<Facecamera>();

            // 3. ADD SOUND ON TELEPORT
            UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationAnchor tel = anchor.GetComponent<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationAnchor>();
            if (tel != null && info.planetSound != null)
            {
                anchor.AddComponent<Sound>();
                anchor.GetComponent<Sound>().clip = info.planetSound;
            }
        }
    }
}
