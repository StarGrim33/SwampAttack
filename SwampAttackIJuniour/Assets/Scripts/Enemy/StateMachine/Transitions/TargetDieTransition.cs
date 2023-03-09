public class TargetDieTransition : Transitions
{
    private void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
