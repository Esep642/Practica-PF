using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PFBenchmark : MonoBehaviour
{
    public TextMeshProUGUI TileCountdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCountdown(int count)
    {
        TileCountdown.text = count.ToString();
    }
}
