using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PFVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private Tile path;
    private Queue<Vector3Int> tileSequence;
    private Queue<int> heatSequence;
    [SerializeField]
    private PFBenchmark bench;
    [SerializeField]
    private Color[] colours;
    [SerializeField]
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        tileSequence = new Queue<Vector3Int>();
        heatSequence = new Queue<int>();
    }
    private void ShowHeat()
    {

        Vector3Int tile = tileSequence.Dequeue();
        map.RefreshTile(tile);
        map.SetTile(tile, path);
        map.SetTileFlags(tile, TileFlags.None);
        
        int heat = heatSequence.Dequeue();
        
        float alpha = 1 - ((float)(heat %10)/ 10);
        Color col = colours[heat % colours.Length];
        col.a = alpha;
        map.SetColor(tile, col);

        bench.UpdateCountdown(tileSequence.Count);

        if (tileSequence.Count == 0)
        {
            Debug.Log("done");
            CancelInvoke("ShowHeat");
        }
    }

    public void ShowTime() //es un nombre de mierda pero no me pude resistir, plz no me juzguen
    {
        InvokeRepeating("ShowHeat", timer, timer);
    }
    public void Add(int heat, Vector3Int pos)
    {
        heatSequence.Enqueue(heat);
        tileSequence.Enqueue(pos);
    }
}
