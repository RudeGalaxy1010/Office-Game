using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminatingState : State
{
    private float _timer;

    private void OnEnable()
    {
        _timer = 0;
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {   
        _timer += Time.deltaTime;

        if (_timer >= Target.EliminatingTime)
        {
            Target.EndIncident();
        }
    }
}
