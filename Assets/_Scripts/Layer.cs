using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField] private int _number;

    public int Number { get => _number; set => _number = value; }

    void Start()
    {
        
    }
}
