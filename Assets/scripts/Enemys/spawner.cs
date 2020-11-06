using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public int cantidad = 5;
    public float tiempoEntreSpawn = 5f;
    public GameObject Enemy;
    float Timer;
    Transform player;
    float distancia;

 
    public float distMinima;
    // Start is called before the first frame update
    void Start()
    {
        Timer = tiempoEntreSpawn;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        distancia =  Vector3.Distance(transform.position, player.position);
        Timer -= Time.deltaTime;
        if (Timer <= 0 && cantidad > 0 && distancia < distMinima)
        {

            cantidad--;
            Instantiate(Enemy, this.transform.position, Quaternion.identity);


            Timer = tiempoEntreSpawn;

        }
    }


}