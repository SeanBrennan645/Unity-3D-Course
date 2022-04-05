using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthPoints = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        Debug.Log("You took a hit!");
        if(healthPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
