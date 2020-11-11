using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open : MonoBehaviour
{

    public float RotSpeed;
    // Start is called before the first frame update
    private Collider col;
    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            //check key
            //if(key)}{
                col.enabled = false;
                for(float i=0f;i <= 90f; i++){
                     this.transform.Rotate(0.0f, i * RotSpeed * Time.deltaTime, 0.0f, Space.Self);
                }
                
           // }
            

        }
    }

}
