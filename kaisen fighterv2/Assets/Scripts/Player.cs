using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health, MaxHealth;
  

    [SerializeField]
    private HealthBarUI healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        // Your other update logic here
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object named "BULLET"
        if (collision.gameObject.CompareTag("BULLET"))
        {
            // Reduce player health by 10
            SetHealth(-10f);

            // Optionally, you can destroy the bullet here
            Destroy(collision.gameObject);
        }
    }
  
     
   
    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);

    }
}
