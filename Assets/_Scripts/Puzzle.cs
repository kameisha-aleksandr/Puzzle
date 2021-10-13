using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private Transform _elementsParent;
    [SerializeField] private RectTransform _dragingParent;

    private Element[] _elements;
    private Outline[] _outlines;

    private int _currentLayer;
    private List<Outline> _listOfCurrentOutlines;

    private void SetListOfCurrentOutlines(int currentLayer)
    {
        foreach (var outline in _outlines)
        {
            if (outline.Layer == currentLayer)
            {
                _listOfCurrentOutlines.Add(outline);
                outline.SetActiveOutline(true);
            }
            else
                outline.SetActiveOutline(false);
        }
    }
    public void RemoveFilledOutlines()
    {
        foreach (var outline in _listOfCurrentOutlines.ToArray())
        {
            if (outline.IsEmpty == false)
                _listOfCurrentOutlines.Remove(outline);
        }
    }
    private void Start()
    {
        _currentLayer = 1;
        _listOfCurrentOutlines = new List<Outline>();
        _elements = GetComponentsInChildren<Element>();
        _outlines = GetComponentsInChildren<Outline>();
        SetListOfCurrentOutlines(_currentLayer);
        foreach (var element in _elements)
        {
            element.transform.SetParent(_elementsParent, false);
            element.Init(_dragingParent);
        }   
    }
    private void Update()
    {
        if(_listOfCurrentOutlines.Count==0 && _currentLayer<=3)
        {
            _currentLayer++;
            SetListOfCurrentOutlines(_currentLayer);
        }
    }
}
