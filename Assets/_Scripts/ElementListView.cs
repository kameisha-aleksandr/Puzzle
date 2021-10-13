using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementListView : MonoBehaviour
{
    [SerializeField] private List<Element> _elements;
    [SerializeField] private Transform _container;
    void Awake()
    {
        Render(_elements);
    }
   
    private void Render(IEnumerable<Element> elements)
    {
        foreach(var element in elements)
        {
            Instantiate(element, _container);
        }
    }
}
