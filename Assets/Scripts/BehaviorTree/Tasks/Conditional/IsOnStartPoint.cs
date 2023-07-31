using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks; 
using UnityEngine;

public class IsOnStartPoint : Conditional
{
    public SharedTransform SelfTransform;
    public SharedVector2 Startpoint;

    private float _offset = 0.7f;

    public override TaskStatus OnUpdate()
    {       
        Vector2 selfVector2 = new Vector2(SelfTransform.Value.position.x, SelfTransform.Value.position.z);
        Vector2 startpoint = Startpoint.Value;

        if(Vector2.Distance(selfVector2,startpoint) <= _offset)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        } 
    }
}


