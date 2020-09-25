using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Region : MonoBehaviour
{
    [SerializeField] int trees;
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
        //set infection counter 
        infectionCounter.text = infectedTrees.ToString();
    }
}
