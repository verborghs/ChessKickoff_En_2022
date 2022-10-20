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


    private Piece _selectedPiece;
    private List<Tile> _validTiles = new List<Tile>(0);

    public void Select(Tile tile)
    {
        DeactivateValidTiles();

        if(_selectedPiece != null && _validTiles.Contains(tile))
        {
            var piece = GetPieceAt(tile.transform.position);
            if( piece == null ||  piece.Player != _selectedPiece.Player)
            {
                piece?.Take();
                _selectedPiece.Move(tile);
            }
            
            ResetState();
        }
        else 
        {
            _selectedPiece = GetPieceAt(tile.transform.position);
            _validTiles = _selectedPiece.GetValidTiles();
        }

        ActivateValidTiles();
    }

    private void ResetState()
    {
        _selectedPiece = null;
        _validTiles.Clear();
    }

    private void ActivateValidTiles()
    {
        foreach (var tile in _validTiles)
            tile.Highlight();                                                       
    }

    private void DeactivateValidTiles()
    {
        foreach (var tile in _validTiles)
            tile.UnHighlight();


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
