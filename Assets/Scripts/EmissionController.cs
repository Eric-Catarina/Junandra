using UnityEngine;
using System.Collections;


public class EmissionController : MonoBehaviour
{
    [SerializeField] private float intensityMultiplier = 1.0f;
    [SerializeField] private bool increaseIntensityOnCollision = false;
    public bool hasEmission;
    float baseIntensity;

    public Color[] rarityColors = new Color[] {
        new Color(0.5f, 0.5f, 0.5f),   // Gray
        new Color(0f, 1f, 0f),         // Green
        new Color(0f, 0f, 1f),         // Blue
        new Color(1f, 0.5f, 0f)        // Orange
    };
    private static readonly int EmissiveColorID = Shader.PropertyToID("_EmissionColor");
    [SerializeField]
    private Material materialInstance;
    private Color initialEmissiveColor;
    [SerializeField]
    private Renderer myRenderer;

    private void Start()
    {
        if (hasEmission)
        {
            TryGetComponent<Renderer>(out myRenderer);

            materialInstance = myRenderer.material;

            initialEmissiveColor = materialInstance.GetColor(EmissiveColorID);
            baseIntensity = initialEmissiveColor.r;
        }
    }

    public void SetIntensity(float intensity)
    {
        intensityMultiplier = intensity;
        UpdateEmission();
    }

    private void UpdateEmission()
    {
        if (hasEmission){
            Color newEmissiveColor = initialEmissiveColor * intensityMultiplier;
            myRenderer.material.SetColor(EmissiveColorID, newEmissiveColor);
        }
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

    public void Flash(float intensity)
    {
        StartCoroutine(FlashCoroutine(intensity));
    }
    public void SetColor(Color color)
    {
        materialInstance.SetColor("_EmissionColor", color);
    }
    public void SetColorAndIntensity(Color color,float intensity)
    {
        materialInstance.SetColor("_EmissionColor", color * intensity);
    }
    public Color GetColor(){
        return myRenderer.material.GetColor("_EmissionColor");
    }
}
