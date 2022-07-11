public class IdleTransition : Transition
{
    private void Update()
    {
        if (Target.IsIncident == false && Target.IsDied == false)
        {
            NeedTransit = true;
        }
    }
}
