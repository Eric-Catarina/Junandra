using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItem : MonoBehaviour
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary
    }
        public Color[] rarityColors = new Color[] {
        new Color(0.5f, 0.5f, 0.5f),   // Gray
        new Color(0f, 1f, 0f),         // Green
        new Color(0f, 0f, 1f),         // Blue
        new Color(1f, 0.5f, 0f)        // Orange
    };
    public Color emissiveColor;
    public Rarity rarity = Rarity.Common;
    [SerializeField]
    private EmissionController emissionController;
    private Renderer myRenderer;

    void Start()
    {
        emissionController = GetComponent<EmissionController>();
        emissiveColor = rarityColors[(int)rarity];
        emissionController.SetColorAndIntensity(emissiveColor, 3);
    }
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        collision.gameObject.GetComponent<PlayerController>().Blink(emissiveColor);

    }


}
