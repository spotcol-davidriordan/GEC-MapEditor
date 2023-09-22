using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MapEditorLoader : MonoBehaviour
{
    public static Dictionary<string, TileReference> TileReferences = new();
    public static List<PaletteObject> Palettes = new();

    public GameObject TileSelectionContent;
    public static GameObject TileSelectionPrefab;

    public GameObject PaletteContent;
    public static GameObject PalettePrefab;

    [RuntimeInitializeOnLoadMethod]
    private static void LoadMapEditor()
    {
        // load prefabs
        TileSelectionPrefab = Resources.Load<GameObject>("MAPEDIT/Prefabs/Tile Button");
        if (TileSelectionPrefab != null) Debug.Log("[MAPEDIT] Loaded tile selection prefab");

        PalettePrefab = Resources.Load<GameObject>("MAPEDIT/Prefabs/Palette");
        if (PalettePrefab != null) Debug.Log("[MAPEDIT] Loaded palette prefab");

        // load tilereferences from disk
        var _tileRefs = Resources.LoadAll<TileReference>("MAPEDIT/Tiles");
        foreach (TileReference reference in _tileRefs)
        {
            Debug.Log($"[MAPEDIT] Loaded tile reference {reference.Name}");
            TileReferences.Add(reference.TileID, reference);
        }

        // load palettes
        Palettes = Resources.LoadAll<PaletteObject>("MAPEDIT/Palettes").ToList();
        foreach (PaletteObject palette in Palettes)
        {
            Debug.Log($"[MAPEDIT] Loaded palette {palette.Name}");
        }
    }

    private void Start()
    {
        GenerateUI();
    }

    private void GenerateUI()
    {
        // generate tile buttons
        foreach (TileReference reference in TileReferences.Values)
        {
            var button = Instantiate(TileSelectionPrefab, TileSelectionContent.transform);
            button.GetComponent<TileSelectButton>().SetupButton(reference);
        }

        // generate palettes
        foreach (PaletteObject palette in Palettes)
        {
            var paletteObject = Instantiate(PalettePrefab, PaletteContent.transform);
            paletteObject.GetComponent<Palette>().SetupPalette(palette);
        }
    }
}
