using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public static int vidaE;
    public float fuerza;
    public float fuerza2;
    private void Start() {
        vidaE = 0;
    }
private void OnTriggerEnter(Collider other) {
    
    if(other.tag == "Enemy"){
        if(vidaE < 2){
        other.GetComponent<Rigidbody>().AddForce(transform.forward  * fuerza, ForceMode.Impulse);
        other.GetComponent<Rigidbody>().AddForce(0, fuerza2, 0);
        vidaE ++;
        }else{
            other.gameObject.GetComponent<Animator>().SetInteger("moving",13);
            
            StartCoroutine(destroyAfterDeath(other.gameObject));
        }

    }
}


IEnumerator destroyAfterDeath(GameObject mutant){

    yield return new WaitForSeconds(3.4f);
    Destroy(mutant);
}
}
