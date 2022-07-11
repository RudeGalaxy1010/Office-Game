using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminatingTransition : Transition
{
    private void Update()
    {
        if (Vector3.Distance(Target.transform.position, Target.Player.transform.position) <= Target.MaxInteractionDistance)
        {
            NeedTransit = true;
        }
    }
}
