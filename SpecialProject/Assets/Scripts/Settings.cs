using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    //1 - easy 2 - medium 3 - hard
    [SerializeField] [Range(1, 3)] int difficulty = 1;
    
    public int getDifficulty()
    {
        return difficulty;
    }
}
