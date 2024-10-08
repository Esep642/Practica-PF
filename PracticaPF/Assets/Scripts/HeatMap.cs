using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeatMap : Pathfinding
{
    public PFBenchmark bench;

    public Tile tile2;
    public Dictionary<Vector3Int, int> Tiles;
    [SerializeField]
    private PFVisualizer visualizer;
    public PFIA personaje;
    public bool BF;
   
    private void Start()
    {
        Tiles = new Dictionary<Vector3Int, int>();
        current = spawner.Coordinates[0];
        Tiles[current] = 0;

        
        Expand(1, current);
        if (personaje!=null)
        {
            personaje.startfindingpath();
        }
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

       
        
        if (!Tiles.ContainsKey(Up))//arriba
        {
            findPath(heat, Up);
        }
        else if (Tiles[Up] > heat)
        {
            findPath(heat, Up);
        } 
        if (!Tiles.ContainsKey(Right))//derecha
        { 
            findPath(heat, Right);
        }
        else if (Tiles[Right] >heat)
        {
               findPath(heat, Right);
        }
        if (!Tiles.ContainsKey(Down))//abajo
        {
            findPath(heat, Down);
        }
        else if (Tiles[Down] > heat)
        {
            findPath(heat, Down);
        }
       if (!Tiles.ContainsKey(Left))//izquierda
        {
            findPath(heat, Left);
        }
        else if (Tiles[Left] > heat)
        {
            findPath(heat, Left);
        }
    }
 
    private void findPath(int heat, Vector3Int pos)
    {
        if (!bounds.HasTile(pos))
        {
            Tiles[pos] = heat;
            visualizer.Add(heat, pos);
            Expand(heat + 1, pos);
          
        }
      
    }
    
}
