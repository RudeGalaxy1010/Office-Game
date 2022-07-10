using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pedestal : MonoBehaviour
{
    [SerializeField] private Transform _objectPosition;
    
    public void Place(GameObject obj)
    {
        obj.transform.position = _objectPosition.position;
    }
}
