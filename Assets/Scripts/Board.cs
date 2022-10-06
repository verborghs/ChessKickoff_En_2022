using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private LayerMask _piecesLayer;
    
    [SerializeField]
    private LayerMask _tilesLayer;

    public void Select(Tile tile)
    {
        var piece = GetPieceAt(tile.transform.position);
        piece?.Activate();        
    }

    public Piece GetPieceAt(Vector3 worldPosition)
    {
        worldPosition.y = 2;
        
        Debug.DrawRay(worldPosition, Vector3.down * 2, Color.red, 2);

        if (Physics.Raycast(worldPosition, Vector3.down, out var hit, 2, _piecesLayer))
            return hit.collider.GetComponent<Piece>();

        return null;
    }

    public Tile GetTileAt(Vector3 worldPosition)
    {
        worldPosition.y = 1;

        if (Physics.Raycast(worldPosition, Vector2.down, out var hit, 2, _tilesLayer))
            return hit.collider.GetComponent<Tile>();
        
        return null;
    }
}
