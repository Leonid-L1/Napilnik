using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetStartDirection : Action
{
    public SharedTransform Selftransform;
    public SharedVector2 Target;

    private float _randomCircleRadius = 4f;

    public override void OnAwake() => Target.Value = Random.insideUnitCircle * _randomCircleRadius;
    
}
