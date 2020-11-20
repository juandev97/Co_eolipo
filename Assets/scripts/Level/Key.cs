using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    float x;
    private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 75.5f;
    }


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        
            x += Time.deltaTime * rotationSpeed;

        

        transform.localRotation = Quaternion.Euler(0, x, 0);
    }
}
