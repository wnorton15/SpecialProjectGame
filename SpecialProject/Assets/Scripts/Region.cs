using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Region : MonoBehaviour
{
    [SerializeField] int regionID;
    [SerializeField] int trees = 1;
    [SerializeField] int infectedTrees = 0;
    [SerializeField] float percentInfected;
    [SerializeField] Text infectionCounter;
    [SerializeField] Region[] surroundingRegions;
    [SerializeField] Image image;
    float timeBetweenInfectingNewRegion = 10f;
    float timeSinceInfectedNewRegion = 0f;
    float timeSinceSpread = Mathf.Infinity;
    float timeBetweenSpread = .5f;
    //variables for adding money 
    float timeSinceAddedMoney = Mathf.Infinity;
    float timeBetweenAddedMoney = 5f;

    bool showing = false;

    float originalRColor;
    float originalGColor;
    float originalBColor;

    NewsController newsController;

    // Start is called before the first frame update
    void Start()
    {
        originalRColor = image.color.r;
        originalGColor = image.color.g;
        originalBColor = image.color.b;

        newsController = FindObjectOfType<NewsController>();
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
        if (timeSinceInfectedNewRegion > timeBetweenInfectingNewRegion && percentInfected > .2f)
        {
            SpreadToNewRegion();
        }
        else 
        {
            timeSinceInfectedNewRegion += Time.deltaTime;
        }

        //change color 
        ChangeColor();

        percentInfected = (float)((float)infectedTrees / (float)trees);

        //update counter
        if (showing)
        {
            infectionCounter.text = "Healthy Trees: " + (trees - infectedTrees).ToString() +
                "\nInfected Trees: " + infectedTrees.ToString() +
                "\nPercent Infected: " + (percentInfected * 100).ToString() + "%";
        }
    }

    private void ChangeColor()
    {
        float newRValue = originalRColor - percentInfected;
        float newBValue = originalBColor - percentInfected;
        float newGValue = originalGColor - percentInfected;

        if (newRValue < .3)
        {
            newRValue = .3f;
        }

        if (newBValue < .3)
        {
            newBValue = .3f;
        }

        if (newGValue < .3)
        {
            newGValue = .3f;
        }


        image.color = new Color(newRValue, newGValue, newBValue);
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
                timeSinceInfectedNewRegion = 0f;
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
            difficultyMultiplier = 1f;
        }
        else if (difficulty == 2)
        {
            difficultyMultiplier = 1.3f;
        }
        else if (difficulty == 3)
        {
            difficultyMultiplier = 1.6f;
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
        String newNews = "Region " + regionID.ToString() + " has been infected";
        newsController.ChangeNews(newNews);
    }

    private void addToMoney()
    {

    }
}
