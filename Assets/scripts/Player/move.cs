using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float movimiento;
    public float rotacion;
    public float speed = 20f;
    public float velocidadRotacion = 60f;
    private Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotacion = Input.GetAxis("Horizontal")*velocidadRotacion;
        rotacion *= Time.deltaTime;
        transform.Rotate(0,rotacion,0);
        
        
        movimiento = Input.GetAxis("Vertical")*speed;
        movimiento *= Time.deltaTime;
        transform.Translate(0,0,movimiento);
        
    }

    public float getSpeed(){
        return speed;
    }
    public void setSpeed(float s){
        this.speed = s;
    }
}
