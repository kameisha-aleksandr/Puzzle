using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    private int _layer;
    private bool _isEmpty;
    private CanvasGroup _canvasGroup;
    public int Layer { get => _layer; set => _layer = value; }
    public bool IsEmpty { get => _isEmpty; set => _isEmpty = value; }

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        IsEmpty = true;
        Layer = GetComponentInParent<Layer>().Number;
    }
    public void SetActiveOutline(bool value)
    {
        if(value)
            _canvasGroup.alpha = 1;
        else
            _canvasGroup.alpha = 0;
        _canvasGroup.interactable = value;
        _canvasGroup.blocksRaycasts = value;
    }

}
