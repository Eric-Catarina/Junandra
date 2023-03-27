using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadordeInimigo : MonoBehaviour
{
    public GameObject[] naves;  // vai ser um array de naves que podera ser acessado atraves de indices garantindo grande velocidade nessas operacoes
    public Vector3 range;       // intervalo em que essas naves serao criadas
    public float tempo;        // de quanto em quanto tempo eu quero criar, tempo de repeticao da criacao  
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", 0, tempo); // chamara a funcao a cada 1 segundo

    }
    // essa funcao abaixo e que vai instanciar os imigos na tela
    void Create(){
        GameObject nave = naves[Random.Range(0, naves.Length)];
        Vector3 pos = this.transform.position + Vector3.Lerp(-range, range, Random.value);
        Instantiate(nave, pos, Quaternion.identity);
    }           

    // Update is called once per frame
    void Update()
    {
    }
}
