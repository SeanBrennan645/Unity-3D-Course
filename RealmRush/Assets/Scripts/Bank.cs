using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalence = 150;
    [SerializeField] int currentBalence;
    public int CurrentBalence { get { return currentBalence; } }

    private void Awake()
    {
        currentBalence = startingBalence;
    }

    public void Deposit(int amount)
    {
        currentBalence += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalence -= Mathf.Abs(amount);
    }
}
