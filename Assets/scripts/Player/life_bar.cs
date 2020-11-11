using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life_bar : MonoBehaviour
{

    
    public Slider slider;
    public Text text;


    public void setMaxHealth(int health){
            slider.maxValue = health;
            text.text = health.ToString();
            slider.value = health;
    }
    
    public void setHealth(int health){

    if(health >= 0){

        slider.value = health;
        text.text = health.ToString();
        }else{
         text.text = "0";
        }
    }

}
