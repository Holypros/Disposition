using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float actualHealth = 100;
    public float speed;
    public Slider slider;
    public PlayerHealth playerHealth;
    void Start() 
    {
        slider.value = 100;
    }
   
   public void SetHealth(int health)
   {
       //slider.value = Mathf.Lerp(slider.value,health,1f * Time.deltaTime);
       actualHealth = health;
      // slider.value = health;
   }
void Update() 
{
    actualHealth = playerHealth.playerHealth;
    if(Input.GetKeyDown(KeyCode.L))
    {
        SetHealth(50);
    }
    if(actualHealth < slider.value)
    {
        slider.value -= Time.deltaTime * speed;
    }
       
   
}

}