using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    static Animator anim;
    private move movi;
    public float AuxSpeed;
    public GameObject hitbox;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movi = GetComponent<move>();
        AuxSpeed = movi.getSpeed();
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if(Input.GetKeyDown("space"))
        {
            anim.SetTrigger("IsJumping");
        }
        */

        if (movi.movimiento != 0){
            anim.SetBool("IsWalking",true);
        }else{
            anim.SetBool("IsWalking",false);
        }

        // golpe 
        if(Input.GetButtonDown("Fire1")){

            anim.SetBool("IsHitting",true);
            hitbox.SetActive(true);
            movi.setSpeed(0f);
            
        }else{
            anim.SetBool("IsHitting",false);
            movi.setSpeed(AuxSpeed);
            hitbox.SetActive(false);
        }
    }

    public void dolor(){
        anim.SetTrigger("IsHurt");
    }
}
