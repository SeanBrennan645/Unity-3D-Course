using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthPoints = 100.0f;
    [SerializeField] TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + healthPoints.ToString();
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        healthText.text = "Health: " + healthPoints.ToString();
        if(healthPoints <= 0)
        {
            healthText.text = "Health: 0";
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
