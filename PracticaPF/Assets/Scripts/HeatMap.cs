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
    private Queue<Vector3Int> BFTiles;
    private Queue<int> BFHeats;
    
   
    private void Start()
    {
        BFTiles = new Queue<Vector3Int>();
        BFHeats = new Queue<int>();
        Tiles = new Dictionary<Vector3Int, int>();
        current = spawner.Coordinates[0];
        Tiles[current] = 0;

        
        Expand(1, current);
        if (personaje!=null&&!BF)
        {
            personaje.startfindingpath();
        }
        if (!BF)
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
        Debug.Log(pos);
        if (BF&& !bounds.HasTile(pos))
        {
            BFHeats.Enqueue(heat);
            BFTiles.Enqueue(pos);
            Tiles[pos] = heat;
        }
        else if (!bounds.HasTile(pos))
        {
            Tiles[pos] = heat;
            visualizer.Add(heat, pos);
            Expand(heat + 1, pos);

        }


    }
    private void deQueueBF()
    {
        int peso = BFHeats.Dequeue();
        Vector3Int pos = BFTiles.Dequeue();

        visualizer.Add(peso, pos);
        Expand(peso + 1, pos);
    }
    private void Update()
    {
        if (BFHeats.Count > 0)
        {
          //  Debug.Log(BFHeats.Count);
            deQueueBF();

            if (BF&&BFHeats.Count==0) visualizer.ShowTime();

        }



    }

}
