using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    public event UnityAction<GameObject> Entered;
    public event UnityAction<GameObject> Exited;

    private void OnTriggerEnter(Collider other)
    {
        Entered?.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        Exited?.Invoke(other.gameObject);
    }
}
