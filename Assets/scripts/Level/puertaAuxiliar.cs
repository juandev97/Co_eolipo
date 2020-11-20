using UnityEngine;

public class puertaAuxiliar : MonoBehaviour {
    
    public GameObject player;
    
    private Collider col ;
    bool llave;

    private void Start() {
        col = GetComponent<Collider>();
        col.enabled = true;
    }
    private void Update() {
        llave = player.GetComponent<ObtenerLlave>().GetKey();

        if(llave){
            col.enabled = false;
        }
    }
}