using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Button[] allRegionButtons;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in allRegionButtons)
        {
            button.image.alphaHitTestMinimumThreshold = .1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
