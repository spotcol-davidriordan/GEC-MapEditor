using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "New Tile Reference", menuName = "GEC/Map Editor/Tile Reference")]
public class TileReference : ScriptableObject
{
    public Tile Tile;
    public string TileID;
    public string Name;

    public Sprite Icon;
}
