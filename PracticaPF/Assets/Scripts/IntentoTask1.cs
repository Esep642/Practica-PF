using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentoTask1 : Pathfinding
{
   public Vector3Int last;
    public int CurrentOpener;
    public bool opening;
    // Start is called before the first frame update
    void Start()
    {
        start = spawner.Coordinates[0];
        goal = spawner.Coordinates[1];
        current = start;
        InvokeRepeating("PathFinding", 0.5f, timer);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void PathFinding()
    {
        
        if(opening)
        {
            current = start;
            CurrentOpener++;
            CurrentOpener = CurrentOpener % 4;
            opening = false;
        }
        switch(CurrentOpener)
        {
            case 0:
                {
                    MovSequence(Vector3Int.up, Vector3Int.right, Vector3Int.down, Vector3Int.left);
                    break;
                }
            case 1:
                {
                    MovSequence(Vector3Int.right, Vector3Int.down, Vector3Int.left, Vector3Int.up);
                    break;
                }
            case 2:
                {
                    MovSequence(Vector3Int.down, Vector3Int.left, Vector3Int.up, Vector3Int.right);
                    break;
                }
            case 3:
                {
                    MovSequence(Vector3Int.left, Vector3Int.up, Vector3Int.right, Vector3Int.down);
                    break;
                }
        }
       
    }
    private bool TryDirection(Vector3Int dir)
    {
        if (!bounds.HasTile(current + dir) && (current+dir)!=last)//abajo
        {
            last = current;
            current += dir;
            
            map.SetTile(current, path);
            return true;
        }
        return false;
    }
    private void MovSequence(Vector3Int first, Vector3Int second, Vector3Int third, Vector3Int forth)
    {
        if (TryDirection(first)) return;
        if (TryDirection(second)) return;
        if (TryDirection(third)) return;
        if (TryDirection(forth)) return;
        opening = true;
    }
    

}
