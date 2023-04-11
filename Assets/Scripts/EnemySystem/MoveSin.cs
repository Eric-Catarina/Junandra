using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    float sinCenterX;
    void Start()
    {
        sinCenterX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.y) * 3;
        pos.x = sinCenterX + sin;

        transform.position = pos;
    }
}
