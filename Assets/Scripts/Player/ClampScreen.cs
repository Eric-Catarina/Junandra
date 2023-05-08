using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampScreen : MonoBehaviour
{
    private Vector3 playerPosition;
    public float xMin = -20f;
    public float xMax = 20f;
    public float yMin = -7.5f;
    public float yMax = 20f;

    void Start()
    {
        playerPosition = transform.position;
    }

    void Update()
    {
        playerPosition = transform.position;

        playerPosition.x =  Mathf.Clamp(playerPosition.x, xMin, xMax);
        playerPosition.y =  Mathf.Clamp(playerPosition.y, yMin, yMax);

        transform.position = playerPosition;

    }
}
