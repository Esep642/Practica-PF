using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFIA : MonoBehaviour
{
    public HeatMap mapa;
    public Vector3Int pos;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FindPath()
    {
        if (mapa.Tiles[pos]==0)
        {
            CancelInvoke("FindPath");
            return;
        }
        int heat = int.MaxValue;
        Vector3Int newpos = new Vector3Int(int.MaxValue, int.MaxValue, int.MaxValue);

        Vector3Int Right = pos + new Vector3Int(1, 0, 0);
        Vector3Int Left = pos + new Vector3Int(-1, 0, 0);
        Vector3Int Up = pos + new Vector3Int(0, 1, 0);
        Vector3Int Down = pos + new Vector3Int(0, -1, 0);

        if (mapa.Tiles.ContainsKey(Up))//arriba
        {
            if (mapa.Tiles[Up] < heat)
            {
                newpos = Up;
                heat = mapa.Tiles[Up];
            }
        }
        if (mapa.Tiles.ContainsKey(Right))//derecha
        {
            if (mapa.Tiles[Right] < heat)
            {
                newpos = Right;
                heat = mapa.Tiles[Right];
            }
        }
        if (mapa.Tiles.ContainsKey(Down))//abajo
        {
            if (mapa.Tiles[Down] < heat)
            {
                newpos = Down;
                heat = mapa.Tiles[Down];
            }
        }
        if (mapa.Tiles.ContainsKey(Left))//izquierda
        {
            if (mapa.Tiles[Left] < heat)
            {
                newpos = Left;
                heat = mapa.Tiles[Left];
            }
        }
        pos = newpos;

    }
    public void startfindingpath()
    {
        InvokeRepeating("FindPath", timer, timer);
    }


}
