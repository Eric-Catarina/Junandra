using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    float sinCenterY;
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x);
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }
}
