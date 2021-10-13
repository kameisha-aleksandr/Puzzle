using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private Transform _elementsParent;
    [SerializeField] private RectTransform _dragingParent;

    private Element[] elements;
    private Outline[] outlines;
    private void Awake()
    {
        elements = GetComponentsInChildren<Element>();
        var outlines = GetComponentsInChildren<Outline>();
    }
    private void Start()
    {
        foreach (var element in elements)
        {
            element.transform.SetParent(_elementsParent, false);
            element.Init(_dragingParent);
        }
    }
}
