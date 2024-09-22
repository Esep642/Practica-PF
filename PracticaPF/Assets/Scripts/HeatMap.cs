using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatMap : Pathfinding
{
    public int MaxAlpha;

    // Update is called once per frame
    private void Start()
    {
        Expand(1, current);
    }
    public override void PathFinding()
    {
        
    }
    private void Expand(int heat, Vector3Int Pos)
    {
        Vector3Int Right = Pos + new Vector3Int(1, 0, 0);
        if (!map.HasTile(Right))//derecha
        {
            map.SetTile(Right, path);
            Color Peso = path.color;
            Peso.a = MaxAlpha / (float)heat;
            Debug.Log(Peso.a);
            map.SetTileFlags(Right, UnityEngine.Tilemaps.TileFlags.None);
            map.SetColor(Right, Peso);
            if (heat<10)//temporal, para que no loopee infinitamente
            Expand(heat + 1, Right);
        }
        
    }
    
}
