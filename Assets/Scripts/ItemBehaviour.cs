using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] private float movement_speed = 0.5f;
    // Start is called before the first frame update

    // Update is called once per frame


    void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlayerInput playerInput))
        {
            return;
        }
        playerInput.IncreaseSpeed();
        
        Destroy(gameObject);
    }
}