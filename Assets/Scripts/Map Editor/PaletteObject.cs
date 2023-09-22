using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Palette", menuName = "GEC/Map Editor/New Palette")]
public class PaletteObject : ScriptableObject
{
    public List<TileReference> Tiles = new();
    public string Name;
}
