using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemGenerator : MonoBehaviour
{
    public GameObject itemPrefab;
    [Range(0.0f, 5f)]
    public float rangeFloat = 1;
    private int currentRarityLevel = 0;
    void Start()
    {
        StartCoroutine(SpawnItem());
    }



    // Spawn a item every 1 second
    IEnumerator SpawnItem()
    {
        while (true)
        {
            GameObject itemInstance = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            currentRarityLevel = Random.Range(1, 5);
            BuffItem.Rarity rarity;

            switch (currentRarityLevel)
            {
                case 1:
                    rarity =  BuffItem.Rarity.Common;
                    break;
                case 2:
                    rarity =  BuffItem.Rarity.Rare;
                    break;
                case 4:
                    rarity =  BuffItem.Rarity.Legendary;
                    break;
                default:
                    rarity =  BuffItem.Rarity.Common;
                    break;
            }
            itemInstance.GetComponent<BuffItem>().rarity = rarity;
            yield return new WaitForSeconds(rangeFloat);

        }
    }

}
