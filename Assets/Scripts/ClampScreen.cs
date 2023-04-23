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

        playerPosition.x =  Mathf.Clamp(playerPosition.x, -15.5f, 15.5f);
        playerPosition.y =  Mathf.Clamp(playerPosition.y, -5.7f, 11);

        transform.position = playerPosition;

    }
}
