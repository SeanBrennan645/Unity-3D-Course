using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalence = 150;
    [SerializeField] int currentBalence;
    public int CurrentBalence { get { return currentBalence; } }

    [SerializeField] TextMeshProUGUI displayBalance;

    private void Awake()
    {
        currentBalence = startingBalence;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalence += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalence -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currentBalence < 0)
        {
            //Lose the game
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalence;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
