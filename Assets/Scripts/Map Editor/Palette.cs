using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Palette : MonoBehaviour
{
    public Foldout foldout;
    [SerializeField] private TextMeshProUGUI label;

    public void SetupPalette(PaletteObject palette)
    {
        var prefab = MapEditorLoader.TileSelectionPrefab;
        foreach (TileReference reference in palette.Tiles)
        {
            var button = Instantiate(prefab, foldout.Content.transform);
            button.GetComponent<TileSelectButton>().SetupButton(reference);
        }

        label.GetComponent<TextMeshProUGUI>().text = palette.Name;
    }
}
