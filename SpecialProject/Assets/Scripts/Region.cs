using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Region : MonoBehaviour
{
    [SerializeField] int trees = 1;
    [SerializeField] int infectedTrees = 0;
    [SerializeField] float percentInfected;
    [SerializeField] Text infectionCounter;
    [SerializeField] Region[] surroundingRegions;
    float timeBetweenInfectingNewRegion = 10f;
    float timeSinceInfectedNewRegion = 0f;
    float timeSinceSpread = Mathf.Infinity;
    float timeBetweenSpread = 2f;
    bool showing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increase infection 
        if (timeSinceSpread > timeBetweenSpread)
        {
            IncreaseInfection();
        }
        else
        {
            timeSinceSpread += Time.deltaTime;
        }

        //timer for spreading to new region 
        if (timeSinceInfectedNewRegion > timeBetweenInfectingNewRegion)
        {
            SpreadToNewRegion();
        }
        else if (infectedTrees > (trees / 2))
        {
            timeSinceInfectedNewRegion += Time.deltaTime;
        }

        //update counter
        if (showing)
        {
            infectionCounter.text = "Healthy Trees: " + (trees - infectedTrees).ToString() +
                "\nInfected Trees: " + infectedTrees.ToString() +
                "\nPercent Infected: " + ((infectedTrees / trees) * 100).ToString() + "%";
        }
    }

    private void SpreadToNewRegion()
    {
        //spread to first uninfected region adjacent to the region
        foreach (Region region in surroundingRegions)
        {
            if (region.GetInfectedTrees() > 0)
            {

            } else
            {
                region.Infect();
                return;
            }
        }
        return;
    }

    private void IncreaseInfection()
    {
        float difficultyMultiplier = 1;
        int difficulty = FindObjectOfType<Settings>().getDifficulty();
        if (difficulty == 1)
        {
            difficultyMultiplier = 1;
        }
        else if (difficulty == 2)
        {
            difficultyMultiplier = 1.3;
        }
        else if (difficulty == 3)
        {
            difficultyMultiplier = 1.6;
        }
        //increase the infection faster as the infection grows
        if (infectedTrees > 0 && infectedTrees < 10)
        {
            infectedTrees += 1;
        }
        else if (infectedTrees > 0 && infectedTrees < 100000)
        {
            infectedTrees += Mathf.RoundToInt(infectedTrees * .1f * difficultyMultiplier);
        }
        else if (infectedTrees > 0)
        {
            infectedTrees += Mathf.RoundToInt(infectedTrees * .025f * difficultyMultiplier);
        }

        //cap the infection
        if (infectedTrees > trees)
        {
            infectedTrees = trees;
        }
        timeSinceSpread = 0;
    }

    public void ShowInfo()
    {
        foreach (Region region in FindObjectsOfType<Region>())
        {
            region.UnshowInfo();
        }
        showing = true;
    }

    public void UnshowInfo()
    {
        showing = false;
    }

    public int GetInfectedTrees()
    {
        return infectedTrees;
    }

    public void Infect()
    {
        infectedTrees++;
    }
}
