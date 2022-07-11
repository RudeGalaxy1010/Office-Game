using UnityEngine;

public class InterruptEliminatingTransition : Transition
{
    private void Update()
    {
        if (Vector3.Distance(Target.transform.position, Target.Player.transform.position) > Target.MaxInteractionDistance)
        {
            NeedTransit = true;
        }
    }
}
