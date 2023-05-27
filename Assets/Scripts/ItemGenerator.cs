using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject itemPrefab;
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn a item every 1 second
    IEnumerator SpawnItem()
    {
        while (true)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);

        }
    }

}
