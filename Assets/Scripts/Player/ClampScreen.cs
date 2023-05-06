using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampScreen : MonoBehaviour
{
    private Vector3 playerPosition;
    // Start is called before the first frame update
    //-16.8
    //-10

    void Start()
    {
        playerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;

        playerPosition.x =  Mathf.Clamp(playerPosition.x, -20f, 20f);
        playerPosition.y =  Mathf.Clamp(playerPosition.y, -8f, 20);

        transform.position = playerPosition;

    }
}
