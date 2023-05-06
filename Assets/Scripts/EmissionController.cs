using UnityEngine;

public class EmissionController : MonoBehaviour
{
    [SerializeField] private float intensityMultiplier = 1.0f;
    [SerializeField] private bool increaseIntensityOnCollision = false;

    private static readonly int EmissiveColorID = Shader.PropertyToID("_EmissionColor");
    private Material materialInstance;
    private Color initialEmissiveColor;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("No Renderer component found on the GameObject.");
            return;
        }

        materialInstance = renderer.material;
        initialEmissiveColor = materialInstance.GetColor(EmissiveColorID);
    }

    public void SetIntensity(float intensity)
    {
        intensityMultiplier = intensity;
        UpdateEmission();
    }

    private void UpdateEmission()
    {
        Color newEmissiveColor = initialEmissiveColor * intensityMultiplier;
        materialInstance.SetColor(EmissiveColorID, newEmissiveColor);
    }
}
