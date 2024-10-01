using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PFBenchmark : MonoBehaviour
{
    public TextMeshProUGUI TileCountdown;
    [SerializeField]
    private int Goal;
    private int current;
    public TextMeshProUGUI Results;
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
    public void Evaluate()
    {
        if (current<Goal)
        {
            Results.color = Color.green;
        }
        else
        {
            Results.color = Color.red;
        }
        Results.text = new string(current.ToString()+"/"+Goal.ToString());
    }
    public void AddCurrent()
    {
        current++;
    }
}
