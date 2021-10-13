using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Element : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _targetPosition;
    private CanvasGroup _canvasGroup;
    private Transform _dragingParent;
    private Transform _previousParent;
    private bool _isElementOnPlace;

    [SerializeField] private UnityEvent _posted;

    public void Init (RectTransform dragingParent)
    {
        _dragingParent = dragingParent;
    }
    private void Awake()
    {
        _isElementOnPlace = false;
        _targetPosition = transform.position;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!_isElementOnPlace)
        {
            _previousParent = transform.parent;
            transform.SetParent(_dragingParent, false);

            _canvasGroup.alpha = 0.6f;
            _canvasGroup.blocksRaycasts = false;
        }  
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isElementOnPlace)
        {
            transform.position = eventData.pointerCurrentRaycast.worldPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isElementOnPlace)
        {
            var outline = EventSystem.current.GetFirstComponentUnderPointer<Outline>(eventData);
            if (outline != null && outline.Target == _targetPosition)
            {
                transform.SetParent(outline.transform.parent, false);
                transform.position = _targetPosition;
                _isElementOnPlace = true;
                outline.IsEmpty = false;
                _posted?.Invoke();
            }
            else
            {
                transform.SetParent(_previousParent, false);
            }
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
        } 
    }
}
