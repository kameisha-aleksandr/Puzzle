﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

static class EventSystemExtensions
{
    public static T GetFirstComponentUnderPointer<T>(this EventSystem system, PointerEventData eventData) where T:class
    {
        var result = new List<RaycastResult>();
        system.RaycastAll(eventData, result);

        foreach (var raycast in result)
        {
            if (raycast.gameObject.TryGetComponent<T>(out T component))
                return component;
        }
        return null;
    }
}
