using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Transform[] allChildren = GetComponentsInChildren<Transform>();

            Debug.Log(allChildren[0].gameObject.transform.position.x);
            Debug.Log(allChildren[1].gameObject.transform.position.x);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
