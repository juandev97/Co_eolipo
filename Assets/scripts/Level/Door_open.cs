using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open : MonoBehaviour
{

    public float RotSpeed;
    // Start is called before the first frame update
    private Collider col;
    
    public GameObject pl;
    bool llave;
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
        col = GetComponent<Collider>();
        col.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        llave = pl.GetComponent<ObtenerLlave>().GetKey();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            //check key
            if(llave){
                col.enabled = false;
                for(float i=0f;i <= 90f; i++){
                     this.transform.Rotate(0.0f, i * RotSpeed * Time.deltaTime, 0.0f, Space.Self);
                }
                
            }else{
                panel.SetActive(true);
            }
            

        }

    }


        private void OnTriggerExit(Collider other) {
            if(other.tag == "Player"){
                panel.SetActive(false);
            }
        }
}
