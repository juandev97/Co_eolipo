using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMutante_AI : MonoBehaviour
{

    public float disMaxima = 15.2f;
    private float disMinima = 2.0f;
    private float speed = 2.0f;
    public float RotSpeed = 2.5f;
    private Transform Goal;
    int atack;
    private Animator Manim;
    private Collider AtackColl;

    //private Life_Sys lf;
    public float fuerza = 15f;
    public float fuerza2 = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        Goal = GameObject.FindGameObjectWithTag("Player").transform;
        
        Manim = GetComponent<Animator>();
        AtackColl = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void LateUpdate()
    {

        
        Vector3 lookAtGoal = new Vector3(Goal.position.x,
                                        this.transform.position.y,
                                        Goal.position.z);
        
        Vector3 direccion = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direccion),
                                                    Time.deltaTime * RotSpeed);

        if (Vector3.Distance(transform.position, lookAtGoal) > disMinima  && Vector3.Distance(transform.position, lookAtGoal) < disMaxima)
        {

            AtackColl.enabled = false;
            Manim.SetInteger("moving",1);
            Manim.SetInteger("battle",0);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }else if(Vector3.Distance(transform.position, lookAtGoal) < disMinima){

            Manim.SetInteger("moving",0);
            
            if(!AtackColl.enabled){
            StartCoroutine(ataque());
            }else{
            
                
                StartCoroutine(End_ataque());
                 
            }

        }else{
            Manim.SetInteger("battle",0);
            Manim.SetInteger("moving",0);
        }
    }


    IEnumerator ataque(){


        Manim.SetInteger("battle",1);

        atack = Random.Range(2,5);
        yield return new WaitForSeconds(2.6f);

        
        Manim.SetInteger("moving",atack);
        AtackColl.enabled = true;
       // Manim.SetInteger("moving",0);

 //         yield return new WaitForSeconds(1.8f);
//      AtackColl.enabled = false;

    }


     IEnumerator End_ataque(){
             yield return new WaitForSeconds(.86f);
              AtackColl.enabled = false;
     }


private void OnTriggerEnter(Collider other) {
    
    if(other.tag == "Player"){

        other.GetComponent<Rigidbody>().AddForce(transform.forward  * fuerza, ForceMode.Impulse);
        other.GetComponent<Rigidbody>().AddForce(0, fuerza2, 0);
        other.GetComponent<Animator>().SetTrigger("IsHurt");
        other.GetComponent<Life_Sys>().TakeDamage(5);
    }
}

}