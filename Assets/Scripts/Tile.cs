using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Tile : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private Material _defaultMaterial;

    [SerializeField]
    private Material _highlightMaterial;


    private Renderer _renderer;

    private Board _board;


    private void OnEnable()
    {
        _board = FindObjectOfType<Board>();
        _renderer = GetComponentInChildren<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _board.Select(this);
    }

    internal void Highlight()
        => _renderer.material = _highlightMaterial;    
    
    internal void UnHighlight()
        =>  _renderer.material = _defaultMaterial;
   

}
