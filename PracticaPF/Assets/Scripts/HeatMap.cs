using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeatMap : Pathfinding
{
    public PFBenchmark bench;
   // public int MaxAlpha;
  //  private Queue<Vector3Int> TileSequence;
    //private Queue<Color> HeatSequence;
    public Tile tile2;
    private Dictionary<Vector3Int, int> Tiles;
    [SerializeField]
    private PFVisualizer visualizer;
    private void Start()
    {
      //  TileSequence = new Queue<Vector3Int>();
        //HeatSequence = new Queue<Color>();
        Tiles = new Dictionary<Vector3Int, int>();
        Expand(1, current);
        // Debug.Log("empezo con: " +HeatSequence.Count);
        //InvokeRepeating("ShowHeat", timer, timer);
        visualizer.ShowTime();
    }
    public override void PathFinding()
    {
        
    }
    private void Expand(int heat, Vector3Int Pos)
    {
        
        Vector3Int Right = Pos + new Vector3Int(1, 0, 0);
        Vector3Int Left = Pos + new Vector3Int(-1, 0, 0);
        Vector3Int Up = Pos + new Vector3Int(0, 1, 0);
        Vector3Int Down = Pos + new Vector3Int(0, -1, 0);

        if (!Tiles.ContainsKey(Right))//derecha
        { 
            findPath(heat, Right);
        }
        else if (Tiles[Right] >heat)
        {
               findPath(heat, Right);
        }
        if (!Tiles.ContainsKey(Left))//izquierda
        {
            findPath(heat, Left);
        }
        else if (Tiles[Left] > heat)
        {
            findPath(heat, Left);
        }
        if (!Tiles.ContainsKey(Up))//arriba
        {
            findPath(heat, Up);
        }
        else if (Tiles[Up] > heat)
        {
            findPath(heat, Up);
        }
        if (!Tiles.ContainsKey(Down))//abajo
        {
            findPath(heat, Down);
        }
        else if (Tiles[Down] > heat)
        {
            findPath(heat, Down);
        }
    }
    private void ShowHeat()
    {
        
     /*   Vector3Int tile = TileSequence.Dequeue();
        map.RefreshTile(tile);
        map.SetTile(tile, path);
        map.SetTileFlags(tile, TileFlags.None);
        map.SetColor(tile, HeatSequence.Dequeue());
        bench.UpdateCountdown(TileSequence.Count);
        
        if (TileSequence.Count == 0)
        {
            Debug.Log("done");
            CancelInvoke("ShowHeat");
        }
            */
        
    }
    private void findPath(int heat, Vector3Int pos)
    {
        if (!bounds.HasTile(pos))
        {
            Tiles[pos] = heat;
            visualizer.Add(heat, pos);
            Expand(heat + 1, pos);
            /* Color Peso = path.color;
             Peso.a = MaxAlpha / (float)heat;
             TileSequence.Enqueue(pos);
             HeatSequence.Enqueue(Peso);
             
            */
        }
      
    }
    
}
