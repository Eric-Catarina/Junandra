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

    private int Choose(float[] probabilities)
    {
        float total = 0;

        foreach (float elem in probabilities)
        {
            total += elem;
        }

        float randomPoint = UnityEngine.Random.value * total;

        for (int i = 0; i < probabilities.Length; i++)
        {
            if (randomPoint < probabilities[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probabilities[i];
            }
        }

        return probabilities.Length - 1;
    }



    // Spawn a item every 1 second
    IEnumerator SpawnItem()
    {
        while (true)
        {

            GameObject itemInstance = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            currentRarityLevel = Random.Range(1, 4);
            BuffItem.Rarity rarity;

            switch (currentRarityLevel)
            {
                case 1:
                    rarity =  BuffItem.Rarity.Common;
                    break;
                case 2:
                    rarity =  BuffItem.Rarity.Rare;
                    break;
                case 3:
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
