using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TileSelectButton : MonoBehaviour, IPointerClickHandler
{
    private TileReference reference;
    private MapEditorManager manager;

    private void Start()
    {
        manager = MapEditorManager.singleton;
    }
    public void SetupButton(TileReference tile)
    {
        reference = tile;
        transform.GetChild(0).GetComponent<Image>().sprite = tile.Icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        manager.ChangeSelectedTile(reference.Tile);
    }
}
