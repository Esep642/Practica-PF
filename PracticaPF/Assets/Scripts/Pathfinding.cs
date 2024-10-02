using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pathfinding : MonoBehaviour
{
    public Vector3Int start;
    public Vector3Int goal;
    public Tile path;
    public Tilemap map;
    public Tilemap bounds;
    public Vector3Int current;
    public float timer;
    public StartNGoalSpawner spawner;
    int heat;

    // Start is called before the first frame update
    void Start()
    {
       //Debug.Log("wtf?");
        start = spawner.Coordinates[0];
        goal = spawner.Coordinates[1];
        current = start;
        InvokeRepeating("PathFinding", 0.5f,timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void PathFinding()
    {
        if(current.x<goal.x && 
            !bounds.HasTile(current + new Vector3Int( 1,0)))//derecha
        {
            current += new Vector3Int(1, 0);
            map.SetTile(current, path);
            return;
        }
        if (current.x > goal.x &&
            !bounds.HasTile(current + new Vector3Int(-1, 0)))//izquierda
        {
            current += new Vector3Int(-1, 0);
            map.SetTile(current, path);
            return;
        }
        if (current.y < goal.y
            &&!bounds.HasTile(current + new Vector3Int(0, 1))) //arriba
        {
            current += new Vector3Int(0, 1);
            map.SetTile(current, path);
                return;
        }
        
        if (current.y > goal.y &&
            !bounds.HasTile(current + new Vector3Int(0, -1)))//abajo
        {
            current += new Vector3Int(0, -1);
            map.SetTile(current, path);
            return;
        }
    }
}
