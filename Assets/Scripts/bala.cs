using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
   
    public float velocidade;
    private Vector3 posicao;
    // Start is called before the first frame update
    void Start()
    {
        posicao= this.transform.position;
        InvokeRepeating("movimenta",0,1/50f);
        Destroy(this.gameObject,3);
    }

    void movimenta(){
        posicao.z+=velocidade*Time.deltaTime;
       this.transform.position=posicao;
    }
}
