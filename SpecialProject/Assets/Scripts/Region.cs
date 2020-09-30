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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowInfo()
    {
        infectionCounter.text = "Healthy Trees: " + (trees - infectedTrees).ToString() +
            "\nInfected Trees: " + infectedTrees.ToString() +
            "\nPercent Infected: " + ((infectedTrees/trees)*100).ToString() + "%";
    }
}
