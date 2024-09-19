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
    private Tile StartT;
    [SerializeField]
    private Tile GoalT;
    [SerializeField]
    private Vector3Int[] Coordinates;
    [SerializeField]
    private Tile Wall;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SetBounds();
        Spawn(Coordinates[0], Coordinates[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Spawn(Vector3Int start, Vector3Int goal)
    {
        map.SetTile(start, StartT);
        map.SetTile(goal, GoalT);
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
    }
}
