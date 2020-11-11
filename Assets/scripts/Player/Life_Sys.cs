using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life_Sys : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public life_bar healthBar;

    private Animator anim;
    void Start()
    {   
        currentHealth = maxHealth;
        healthBar.setHealth(maxHealth);

        anim = GetComponent<Animator>();

    }

    void Update()
    {
            if(currentHealth <= 0){

                anim.SetTrigger("Die");

                StartCoroutine(CargarScene());
            }
    }

    IEnumerator CargarScene(){
        
        yield return new  WaitForSeconds(1.8f);
        SceneManager.LoadScene("Menu");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -=damage;
        healthBar.setHealth(currentHealth);
    }

}
