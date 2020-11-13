using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    //THIS SCRIPT IS USED FOR KEEPING THE GAME DATA WHEN CHANGING BETWEEN SCENES

    //these are the different data we want to save 
    RegionVariables[] regionVariables = new RegionVariables[9];

    [SerializeField] int test = 1;

    //this will be the variable to store if the save system has been created 
    //to keep from creating multiple save systems. 
    static SaveSystemController instance = null;

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
            for (int i = 0; i < regionVariables.Length; i++)
            {
                //region 2 starts with 1 tree infested
                if (i == 1)
                {
                    regionVariables[i] = new RegionVariables(1, 0f, 0f, 0f, 0f, false);
                }
                //all other regions start at 0
                else
                {
                    regionVariables[i] = new RegionVariables(0, 0f, 0f, 0f, 0f, false);
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

    public void SetRegionVars(int regionNumber, RegionVariables regionVars)
    {
        regionVariables[regionNumber - 1] = regionVars;
    }

    public RegionVariables GetRegionVars(int regionNumber)
    {
        return regionVariables[regionNumber - 1];
    }

    
}
