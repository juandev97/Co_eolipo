using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    public float disMaxima = 15.2f;
    private float disMinima = 4.5f;
    private float speed = 2.0f;
    public float RotSpeed = 2.5f;
    private Transform Goal;
    public GameObject[] waypoints;

   

    private float accuracy = 1.6f;
    public int currentWP = 0;

    private Animator Wanim;
    // Start is called before the first frame update
    void Start()
    {
        Goal = GameObject.FindGameObjectWithTag("Player").transform;
        waypoints = GameObject.FindGameObjectsWithTag("waypoints");
        Wanim = GetComponent<Animator>();
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
            Wanim.SetInteger("atack",1);
            this.transform.Translate(0, 0, speed * Time.deltaTime);

        }else if(Vector3.Distance(transform.position, Goal.position) > disMaxima){
             Wanim.SetInteger("atack",0);
        }

//distancia =  Vector3.Distance(transform.position, player.position);

////////////////////////
        if(Vector3.Distance(transform.position, lookAtGoal) <= disMinima ){
            if(waypoints.Length == 0) return;

            
            RotSpeed = 15.5f;
            Vector3 lookAtWay= new Vector3(waypoints[currentWP].transform.position.x,
                                            this.transform.position.y,
                                            waypoints[currentWP].transform.position.z);
            
            Vector3 direction = lookAtWay - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime* RotSpeed);

            if(direction.magnitude <= accuracy){

                currentWP++;
                if(currentWP >= waypoints.Length){
                    currentWP = 0;
                }
            }

            Wanim.SetInteger("atack",1);
            this.transform.Translate(0,0,speed * Time.deltaTime);
            }


    }
}