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
        
        float stage = 1 - ((float)(heat %10)/ 10);
        Color col = colours[(heat / 10)%colours.Length];
        Color nextCol = colours[((heat / 10)+1) % colours.Length];
        
        //col.a = alpha;
        map.SetColor(tile, Degrade(col, nextCol, stage));

        bench.UpdateCountdown(tileSequence.Count);

        if (tileSequence.Count == 0)
        {
            Debug.Log("done");
            CancelInvoke("ShowHeat");
        }
    }

    public void ShowTime() //es un nombre de mierda pero no me pude resistir, plz no me juzguen
    {
        bench.Evaluate();
        InvokeRepeating("ShowHeat", timer, timer);
    }
    public void Add(int heat, Vector3Int pos)
    {
        heatSequence.Enqueue(heat);
        tileSequence.Enqueue(pos);
        bench.AddCurrent();
    }

    private Color Degrade(Color current, Color next, float stage)
    {
        float Rdiff = current.r - next.r;
        float Gdiff = current.g - next.g;
        float Bdiff = current.b - next.b;
        Debug.Log(stage);
        Color col = new Color(current.r+(Rdiff*stage), current.g + (Gdiff * stage), current.b + (Bdiff * stage));
        return col;
    }
}
