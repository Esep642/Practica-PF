using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StartNGoalSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3Int[] bounds;
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private Tilemap PF;
    [SerializeField]
    private Tile StartT;
    [SerializeField]
    private Tile GoalT;
    
    public Vector3Int[] Coordinates;
    [SerializeField]
    private Tile Wall;
    [SerializeField]
    private Vector3Int Limit;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       // map.GetTilesBlock(new BoundsInt(Coordinates[0], Coordinates[1]));
       // SetBounds();
     //   Spawn(Coordinates[0], Coordinates[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("spawn")]
    private void Spawn()
    {
        bool spawned = false;
        while(!spawned)
        {
            int x = Random.Range(0, Limit.x);
            int y = Random.Range(0, Limit.y);
            Vector3Int pos = new Vector3Int(x, y, 0);
            if (!map.HasTile(pos))
            {
                Coordinates[0] = pos;
                map.SetTile(pos, StartT);
                spawned = true;
            }
        }
        spawned = false;
        while (!spawned)
        {
            int x = Random.Range(0, Limit.x);
            int y = Random.Range(0, Limit.y);
            Vector3Int pos = new Vector3Int(x, y, 0);
            if (!map.HasTile(pos))
            {
                Coordinates[1] = pos;
                PF.SetTile(pos, GoalT);
                spawned = true;
            }
        }

        //  map.SetTile(Coordinates[0], StartT);
        //map.SetTile(Coordinates[1], GoalT);
    }
    [ContextMenu ("bounds")]
    private void SetBounds()
    {
        for (int x=bounds[0].x; x<bounds[1].x; x++)
        {
            map.SetTile(new Vector3Int(x, bounds[0].y),Wall);//piso
            map.SetTile(new Vector3Int(x, bounds[1].y), Wall);//techo
        }
        for (int y = bounds[0].y; y < bounds[1].y; y++)
        {
            map.SetTile(new Vector3Int(bounds[0].x, y), Wall);//izquierda
            map.SetTile(new Vector3Int(bounds[1].x, y), Wall);//derecha
        }
        map.SetTile(bounds[1], Wall); //ezquina
        for (int x = bounds[2].x; x < bounds[3].x; x++)
        {
            map.SetTile(new Vector3Int(x, bounds[2].y), Wall);//pared hardcodeada
          
        }
    }
    [ContextMenu("show00")]
    private void Show00()
    {
        map.SetTile(new Vector3Int(0, 0, 0),Wall);
        map.SetTile(Limit, Wall);
    }
    [ContextMenu("reset")]
    private void GoalReset()
    {
        map.SetTile(Coordinates[0], null);
        PF.SetTile(Coordinates[1], null);
        Spawn();
    }
}
