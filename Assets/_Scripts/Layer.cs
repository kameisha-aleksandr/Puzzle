using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    private Transform _startElementsParent;
    private Transform _dragingParent;

    private List<Element> _elements;
    public List<Outline> _outlines;

    public void Init(Transform dragingParent, Transform startElementsParent)
    {
        _dragingParent = dragingParent;
        _startElementsParent = startElementsParent;
    }
    private void Start()
    {
        _elements = new List<Element>(GetComponentsInChildren<Element>());
        _outlines =new List<Outline>(GetComponentsInChildren<Outline>());

        foreach (var element in _elements)
        {
            element.transform.SetParent(_startElementsParent, false);
            element.Init(_dragingParent);
        }
    }
}
