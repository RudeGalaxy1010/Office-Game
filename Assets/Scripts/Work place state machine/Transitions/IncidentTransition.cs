public class IncidentTransition : Transition
{
    private void Update()
    {
        if (Target.NeedIncident)
        {
            NeedTransit = true;
        }
    }
}
