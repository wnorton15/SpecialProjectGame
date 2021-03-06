﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    //THIS SCRIPT IS USED FOR KEEPING THE GAME DATA WHEN CHANGING BETWEEN SCENES

    //these are the different data we want to save 
    RegionVariables[] regionVariables = new RegionVariables[9];
    private int difficulty = 1;
    
    //this will be the variable to store if the save system has been created 
    //to keep from creating multiple save systems. 
    static SaveSystemController instance = null;

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
            if (PlayerPrefs.HasKey("Region1InfestedTrees"))
            {
                LoadGame();
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

    public void SaveGame()
    {
        for (int i = 0; i < regionVariables.Length; i++)
        {
            PlayerPrefs.SetInt("Region" + (i + 1).ToString() + "InfestedTrees", regionVariables[i].infectedTrees);
            PlayerPrefs.SetFloat("Region" + (i + 1).ToString() + "TimeSinceInfestedNewRegion", regionVariables[i].timeSinceInfectedNewRegion);
            PlayerPrefs.SetFloat("Region" + (i + 1).ToString() + "TimeSinceSpread", regionVariables[i].timeSinceSpread);
            PlayerPrefs.SetFloat("Region" + (i + 1).ToString() + "TimeSinceAddedMoney", regionVariables[i].timeSinceAddedMoney);
            PlayerPrefs.SetFloat("Region" + (i + 1).ToString() + "TimeSinceFirstInfected", regionVariables[i].timeSinceFirstInfested);
            if (regionVariables[i].firstDonation)
            {
                PlayerPrefs.SetInt("Region" + (i + 1).ToString() + "FirstDonation", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Region" + (i + 1).ToString() + "FirstDonation", 0);
            }
        }
    }

    public void LoadGame()
    {
        for (int i = 0; i < regionVariables.Length; i++)
        {
            regionVariables[i].infectedTrees = PlayerPrefs.GetInt("Region" + (i + 1).ToString() + "InfestedTrees");
            regionVariables[i].timeSinceInfectedNewRegion = PlayerPrefs.GetFloat("Region" + (i + 1).ToString() + "TimeSinceInfestedNewRegion");
            regionVariables[i].timeSinceSpread = PlayerPrefs.GetFloat("Region" + (i + 1).ToString() + "TimeSinceSpread");
            regionVariables[i].timeSinceAddedMoney = PlayerPrefs.GetFloat("Region" + (i + 1).ToString() + "TimeSinceAddedMoney");
            regionVariables[i].timeSinceFirstInfested = PlayerPrefs.GetFloat("Region" + (i + 1).ToString() + "TimeSinceFirstInfected");

            if (PlayerPrefs.GetInt("Region" + (i + 1).ToString() + "FirstDonation") == 1)
            {
                regionVariables[i].firstDonation = true;
            } else
            {
                regionVariables[i].firstDonation = false;
            }
        }
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < regionVariables.Length; i++)
        {
            regionVariables[i].infectedTrees = 0;
            regionVariables[i].timeSinceInfectedNewRegion = 0f;
            regionVariables[i].timeSinceSpread = 0f;
            regionVariables[i].timeSinceAddedMoney = 0f;
            regionVariables[i].timeSinceFirstInfested = 0f;
            regionVariables[i].firstDonation = false;
        }
        //start of infestation
        regionVariables[1].infectedTrees = 1;
        SaveGame();
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }

    
}
