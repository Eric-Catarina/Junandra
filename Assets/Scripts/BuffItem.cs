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
        Debug.Log(emissionController.GetColor());
        emissionController.SetColor(emissionController.rarityColors[(int)rarity]);
        emissionController.SetIntensity(2);
    }

}
