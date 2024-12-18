using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] float maxHealth, currentHealth = 3f;
    [SerializeField] HealthBar bar;
    public GameOverScreen GameOver;

    // Get the health bar component
    private void Awake()
    {
        bar = GetComponentInChildren<HealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Set the health bar value
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Set the health bar value to 0
        GameOver.Setup();
    }
}
