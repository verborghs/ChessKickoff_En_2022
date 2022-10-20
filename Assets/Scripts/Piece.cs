using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{

    [SerializeField]
    private Player _player;

    protected Board Board;

    public Player Player => _player;

    private void OnEnable()
    {
        Board = FindObjectOfType<Board>();
    }

    internal abstract List<Tile> GetValidTiles();

    internal void Move(Tile tile)
        => transform.position = tile.transform.position;
    

    internal void Take()
        => gameObject.SetActive(false);
    
}
