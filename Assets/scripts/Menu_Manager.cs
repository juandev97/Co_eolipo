using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void cargarNivel(){
SceneManager.LoadScene("Nivel Lab Capsula");
    }

    public void cargarTest(){
        SceneManager.LoadScene("TestRoom");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
