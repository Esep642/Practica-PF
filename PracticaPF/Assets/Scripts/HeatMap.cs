using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeatMap : Pathfinding
{
    public int MaxAlpha;
    private Queue<Vector3Int> Tiles;
    private Queue<Color> Heat;
    public Tile tile2;
    // Update is called once per frame
    private void Start()
    {
        Tiles = new Queue<Vector3Int>();
        Heat = new Queue<Color>();
        Expand(1, current);
        InvokeRepeating("ShowHeat", timer, timer);
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
        Debug.Log(map.GetColor(Right).a);
        if (!map.HasTile(Right))//derecha
        {
            findPath(heat, Right);
        }
        else if ((map.GetColor(Right).a * (float)heat) <MaxAlpha)
        {
            Debug.Log("right");
            findPath(heat, Right);
        }
        if (!map.HasTile(Left))//izquierda
        {
            findPath(heat, Left);
        }
        else if ((map.GetColor(Left).a * (float)heat) < MaxAlpha)
        {
            findPath(heat, Left);
        }
        if (!map.HasTile(Up))//arriba
        {
            findPath(heat, Up);
        }
        else if ((map.GetColor(Up).a * (float)heat) < MaxAlpha)
        {
            findPath(heat, Up);
        }
        if (!map.HasTile(Down))//abajo
        {
            findPath(heat, Down);
        }
        else if ((map.GetColor(Down).a * (float)heat) < MaxAlpha)
        {
            findPath(heat, Down);
        }
    }
    private void ShowHeat()
    {
        
        Vector3Int tile = Tiles.Dequeue();
        map.SetTile(tile, path);
        map.SetTileFlags(tile, UnityEngine.Tilemaps.TileFlags.None);
        map.SetColor(tile, Heat.Dequeue());
        
        if (Tiles.Count == 0)
            CancelInvoke("ShowHeat");
    }
    private void findPath(int heat, Vector3Int pos)
    {
        if (!bounds.HasTile(pos))

        {
            Color Peso = path.color;
            Peso.a = MaxAlpha / (float)heat;
            Debug.Log(Peso.a);
            Tiles.Enqueue(pos);
            Heat.Enqueue(Peso);
            map.SetTile(pos, tile2);
            map.SetTileFlags(pos, UnityEngine.Tilemaps.TileFlags.None);
            map.SetColor(pos, Peso);
            map.RefreshTile(pos);

            Expand(heat + 1, pos);
        }
           
    }
    
}
