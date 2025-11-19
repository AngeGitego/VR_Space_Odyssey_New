using UnityEngine;

public class PlanetAutoPositioner : MonoBehaviour
{
    [System.Serializable]
    public class PlanetInfo
    {
        public string name;
        public Transform planet;
        public float distanceFromSun;
        public float scale;
        public float yOffset;
    }

    public Transform sun;

    // Pre-filled planet data
    public PlanetInfo[] planets = new PlanetInfo[]
    {
        new PlanetInfo { name = "Mercury", distanceFromSun = 4f,  scale = 0.5f,  yOffset = 0.5f },
        new PlanetInfo { name = "Venus",   distanceFromSun = 7f,  scale = 0.9f,  yOffset = -0.3f },
        new PlanetInfo { name = "Earth",   distanceFromSun = 10f, scale = 1.0f,  yOffset = 0.8f },
        new PlanetInfo { name = "Moon",    distanceFromSun = 11f, scale = 0.27f, yOffset = 0.5f },
        new PlanetInfo { name = "Mars",    distanceFromSun = 13f, scale = 0.7f,  yOffset = -0.4f },
        new PlanetInfo { name = "Jupiter", distanceFromSun = 18f, scale = 3.0f,  yOffset = 1.2f },
        new PlanetInfo { name = "Saturn",  distanceFromSun = 24f, scale = 2.5f,  yOffset = 0.5f },
        new PlanetInfo { name = "Uranus",  distanceFromSun = 30f, scale = 1.8f,  yOffset = -0.6f },
        new PlanetInfo { name = "Neptune", distanceFromSun = 36f, scale = 1.7f,  yOffset = 1.0f },
    };

    private void Start()
    {
        if (sun == null)
        {
            Debug.LogError("Please assign the Sun in the inspector!");
            return;
        }

        foreach (var p in planets)
        {
            if (p.planet == null)
            {
                Debug.LogWarning($"{p.name} is not assigned!");
                continue;
            }

            Vector3 position = new Vector3(
                p.distanceFromSun,
                p.yOffset,
                0
            );

            p.planet.position = sun.position + position;
            p.planet.localScale = Vector3.one * p.scale;
        }
    }
}
