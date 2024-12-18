using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider bar;

   public void HealthBarUpdate(float currentHealth, float maxHealth)
    {
       bar.value = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
