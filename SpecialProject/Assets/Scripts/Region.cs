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
    float timeSinceSpread = Mathf.Infinity;
    float timeBetweenSpread = 5f;
    bool showing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceSpread > timeBetweenSpread)
        {
            IncreaseInfection();
        }
        else
        {
            timeSinceSpread += Time.deltaTime;
        }

        if (showing)
        {
            infectionCounter.text = "Healthy Trees: " + (trees - infectedTrees).ToString() +
                "\nInfected Trees: " + infectedTrees.ToString() +
                "\nPercent Infected: " + ((infectedTrees / trees) * 100).ToString() + "%";
        }
    }

    private void IncreaseInfection()
    {
        if (infectedTrees > 0 && infectedTrees < 10)
        {
            infectedTrees += 1;
        }
        else if (infectedTrees > 0 && infectedTrees < 100000)
        {
            infectedTrees += Mathf.RoundToInt(infectedTrees * .1f);
        }
        else if (infectedTrees > 0)
        {
            infectedTrees += Mathf.RoundToInt(infectedTrees * .025f);
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
}
