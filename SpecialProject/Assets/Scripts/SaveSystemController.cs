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

    //array of ints that will store infected trees in each region 
    private int[] infestedTrees = new int[9];

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
            //set starting values for infested trees
            for (int i = 0; i < infestedTrees.Length; i++)
            {
                //region 2 starts with 1 tree infested
                if (i == 1)
                {
                    infestedTrees[i] = 1;
                }
                //all other regions start at 0
                else
                {
                    infestedTrees[i] = 0;
                }
            }
        }
        //if instance exists and isn't this 
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetInfestedTrees(int regionNumber, int infestedTrees)
    {
        this.infestedTrees[regionNumber - 1] = infestedTrees;
    }

    public int GetInfestedTrees(int regionNumber)
    {
        return infestedTrees[regionNumber - 1];
    }
    
}
