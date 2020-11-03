using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    //this keeps track of the money you can use on buying new tactics in the store 
    int bankroll = 0;

    public void AddToBankroll(int money)
    {
        bankroll += money;
    }

    public int GetBankRoll()
    {
        return bankroll;
    }

    public void TakeFromBankroll(int money)
    {
        bankroll -= money;
    }
}
