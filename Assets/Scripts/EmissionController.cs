using UnityEngine;
using System.Collections;


public class EmissionController : MonoBehaviour
{
    [SerializeField] private float intensityMultiplier = 1.0f;
    [SerializeField] private bool increaseIntensityOnCollision = false;
    float baseIntensity;

    private static readonly int EmissiveColorID = Shader.PropertyToID("_EmissionColor");
    private Material materialInstance;
    private Color initialEmissiveColor;

    private void Start()
    {   
        if (!TryGetComponent<Renderer>(out Renderer renderer)){
        }

        materialInstance = renderer.material;
        initialEmissiveColor = materialInstance.GetColor(EmissiveColorID);
        baseIntensity = initialEmissiveColor.r;
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

    public IEnumerator FlashCoroutine(float intensity)
    {
        float flashDuration = 1f;
        float timer = 0f;

        while (timer < flashDuration)
        {
            float lerpValue = Mathf.Lerp(1f, intensity, timer / flashDuration);
            materialInstance.SetColor("_EmissionColor", initialEmissiveColor * lerpValue * baseIntensity);
            timer += Time.deltaTime;
            yield return null;
        }

        materialInstance.SetColor("_EmissionColor", initialEmissiveColor * baseIntensity);
    }

    public void Flash(float intensity){
        StartCoroutine(FlashCoroutine(intensity));
    }
}
