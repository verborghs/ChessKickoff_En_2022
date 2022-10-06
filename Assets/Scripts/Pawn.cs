﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Pawn : Piece
{

    private bool _hasMoved = false;
    internal override void Activate()
    {
        var tile1 = Board.GetTileAt(transform.position + transform.forward);
        if(tile1 != null)
        {
            var piece1 = Board.GetPieceAt(tile1.transform.position);
            if (piece1 == null)
                tile1.Highlight();

            if (!_hasMoved)
            {
                var tile2 = Board.GetTileAt(transform.position + transform.forward * 2);
                if (tile2 != null)
                {
                    var piece2 = Board.GetPieceAt(tile2.transform.position);
                    if (piece2 == null)
                        tile2.Highlight();
                }
            }
        }

        var tile3 = Board.GetTileAt(transform.position + transform.forward + transform.right);
        if(tile3 != null)
        {
            var piece3 = Board.GetPieceAt(tile3.transform.position);
            if (piece3 != null)
                tile3.Highlight();
        }

        var tile4 = Board.GetTileAt(transform.position + transform.forward - transform.right);
        if (tile4 != null)
        {
            var piece4 = Board.GetPieceAt(tile4.transform.position);
            if (piece4 != null)
                tile4.Highlight();
        }

    }
}



