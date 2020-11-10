using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    //THIS SCRIPT IS USED FOR KEEPING THE GAME DATA WHEN CHANGING BETWEEN SCENES

    //these are the different data we want to save 
    [SerializeField] int[] regionInfestedTrees = new int[9];

    [SerializeField] int test = 1;

    //this will be the variable to store if the save system has been created 
    //to keep from creating multiple save systems. 
    static SaveSystemController instance = null;

    private void Start()
    {
        
    }
    private void Update()
    {
        test += 1;
    }

    private void Awake()
    {
        //check if instance already exists
        if (instance == null)
        {
            //if not set instance to this 
            instance = this;
        }
        //if instance exists and isn't this 
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
