using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsController : MonoBehaviour
{
    [SerializeField] Text newsField;

    float timeSinceChanged = 0f;
    float timeBeforeClear = 10f;

    private void Start()
    {
        //start infection in region 2 
        string news = "Region 2 has been infected";
        ChangeNews(news);
    }

    // Update is called once per frame
    void Update()
    {
        if (!newsField.text.Equals(""))
        {
            timeSinceChanged += Time.deltaTime;
        }

        if (timeSinceChanged > timeBeforeClear)
        {
            newsField.text = "";
            timeSinceChanged = 0;
        }
    }

    public void ChangeNews(string newNews)
    {
        newsField.text = "";
        newsField.text = newNews;
        timeSinceChanged = 0f;
    }
}
