using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private Transform _startElementsParent;
    [SerializeField] private Transform _dragingParent;
    [SerializeField] public UnityEvent _won;

    private Layer[] _layers;
    private int _currentLayer;
 
    private void Awake()
    {
        _currentLayer = 1;
        _layers = GetComponentsInChildren<Layer>();
        foreach (var layer in _layers)
            layer.Init(_dragingParent, _startElementsParent);
    }
    private void Start()
    {
        SetActiveCurrentOutlines(_currentLayer);
    }

    private void SetActiveCurrentOutlines(int currentLayer)
    {
        for (int i=0; i< _layers.Length; i++)
        {
            foreach (var outline in _layers[i]._outlines)
            {
                if (i== currentLayer-1)
                {
                    outline.SetActive(true);
                }
                else
                    outline.SetActive(false);
            }
        }
    }
    public void CheckOutlineList()
    {
        int countEmptyElements = 0;
        foreach(var outline in _layers[_currentLayer - 1]._outlines)
        {
            if (outline.IsEmpty)
                countEmptyElements++;
        }
        if (_currentLayer == _layers.Length && countEmptyElements == 0)
            _won.Invoke();
        else if (countEmptyElements == 0)
        {
            _currentLayer++;
            SetActiveCurrentOutlines(_currentLayer);
        }
    }
}
