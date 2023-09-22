using UnityEngine;
using UnityEngine.Tilemaps;

public class MapEditorManager : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject Cursor;
    public Tile tile;

    public static MapEditorManager singleton;
    public Vector2Int MapSize = new(100, 100);

    private void Awake()
    {
        singleton = this;
    }

    private void ClearMap()
    {
        tilemap.ClearAllTiles();
    }

    private void CreateNew()
    {
        MapEditorLoader.TileReferences.TryGetValue("grass", out TileReference tileref);
        ClearMap();

        for (int i = -MapSize.x; i <= MapSize.x; i++)
            for (int k = -MapSize.y; k <= MapSize.y; k++)
            {
                DrawTile(new Vector3Int(i, k), tileref.Tile);
            }
    }

    private void Start()
    {
        CreateNew();
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3Int cursorPosition = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(mousePos));
        cursorPosition.Clamp(-(Vector3Int)MapSize, (Vector3Int)MapSize);
        Vector3 newPosition = tilemap.CellToWorld(cursorPosition);

        newPosition.y += 0.25f;
        newPosition.z = 10;

        Cursor.transform.position = newPosition;

        // drawing takes priority over not drawing
        if (Input.GetMouseButton(0))
        {
            Pencil(mousePos, tile);
        }
        else if (Input.GetMouseButton(1))
        {
            Eraser(mousePos);
        }
    }

    public void ChangeSelectedTile(Tile tile)
    {
        this.tile = tile;
        Debug.Log($"Tile switched to {tile.name}");
    }

    private void Eraser(Vector3 mousePosition)
    {
        Vector2 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int mousePosSnapped = tilemap.WorldToCell(mousePosWorld);
        mousePosSnapped.Clamp(-(Vector3Int)MapSize, (Vector3Int)MapSize);
        DrawTile(mousePosSnapped, null);
    }

    private void Pencil(Vector3 mousePosition, Tile tile)
    {
        Vector2 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int mousePosSnapped = tilemap.WorldToCell(mousePosWorld);
        mousePosSnapped.Clamp(-(Vector3Int)MapSize, (Vector3Int)MapSize);
        DrawTile(mousePosSnapped, tile);
    }

    private void DrawTile(Vector3Int tilePos, Tile tile)
    {
        tilemap.SetTile(tilePos, tile);
    }
}