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
    public Rarity rarity = Rarity.Common;
    [SerializeField]
    private EmissionController emissionController;
    private Renderer myRenderer;

    void Start()
    {
        emissionController = GetComponent<EmissionController>();
        Color emissiveColor = emissionController.rarityColors[(int)rarity];
        emissionController.SetColorAndIntensity(emissiveColor, 3);
    }

}
