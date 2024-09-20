using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingWall : Pathfinding
{
    bool wallmode;
    int YWall=0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PathFinding", 0.5f, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void PathFinding()
    {
        if (current.x < goal.x &&
            !bounds.HasTile(current + new Vector3Int(1, 0))&&current.y>YWall)//derecha
        {
            current += new Vector3Int(1, 0);
            map.SetTile(current, path);
            return;
        }
        if (current.x > goal.x &&
            !bounds.HasTile(current + new Vector3Int(-1, 0)) && current.y > YWall)//izquierda
        {
            current += new Vector3Int(-1, 0);
            map.SetTile(current, path);
            return;
        }
        if (current.y < goal.y) //arriba
            Debug.Log("entro arriba");
            if (!bounds.HasTile(current + new Vector3Int(0, 1)))
            {
         
                current += new Vector3Int(0, 1);
                map.SetTile(current, path);
                return;
            }
            else if (!bounds.HasTile(current + new Vector3Int(1, 0)))//derecha??
            {
                YWall = current.y + 1;
               
                current += new Vector3Int(1, 0);
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

