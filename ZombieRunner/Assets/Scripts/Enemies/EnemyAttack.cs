﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40.0f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if(target == null)
        {
            return;
        }
        else
        {
            target.TakeDamage(damage);
            target.GetComponent<DisplayDamage>().ShowDamageCanvas();
        }
    }
}
