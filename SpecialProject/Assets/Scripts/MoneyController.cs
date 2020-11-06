using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    //text element on the canvas to track the money 
    [SerializeField] Text bankrollText;
    //this keeps track of the money you can use on buying new tactics in the store 
    int bankroll = 0;

    private void Start()
    {
        bankrollText.text = "Bankroll: $" + bankroll.ToString();
    }

    public void AddToBankroll(int money)
    {
        bankroll += money;
        UpdateBankrollText();
    }

    private void UpdateBankrollText()
    {
        bankrollText.text = "Bankroll: $" + bankroll.ToString();
    }

    public int GetBankRoll()
    {
        return bankroll;
    }

    public void TakeFromBankroll(int money)
    {
        bankroll -= money;
        UpdateBankrollText();
    }
}
