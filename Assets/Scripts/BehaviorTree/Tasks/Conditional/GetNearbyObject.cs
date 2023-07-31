using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class GetNearbyObject<TNearbyObject, TSharedNearbyObject> : Conditional where TNearbyObject : Component where TSharedNearbyObject : SharedVariable<TNearbyObject>
{
    public SharedFloat Radius;
    public TSharedNearbyObject NearByObjectReturn;

    private readonly Collider[] _overlapColliders = new Collider[256];

    public override TaskStatus OnUpdate()
    {
        int overlapCount = Physics.OverlapSphereNonAlloc(transform.position, Radius.Value, _overlapColliders);
        TNearbyObject nearbyObject = null;
        float nearbyObjectDistance = float.PositiveInfinity;

        for (int i = 0; i < overlapCount; i++)
        {
            Collider overlapCollider = _overlapColliders[i];

            if (overlapCollider.gameObject == gameObject)
                continue;

            if (overlapCollider.TryGetComponent(out TNearbyObject detectedObject))
            {
                float distance = Vector3.Distance(transform.position, detectedObject.transform.position);

                if (distance < nearbyObjectDistance)
                {
                    nearbyObject = detectedObject;
                    nearbyObjectDistance = distance;
                }
            }
        }

        NearByObjectReturn.Value = nearbyObject;
        return nearbyObject != null ? TaskStatus.Success : TaskStatus.Failure;
    }
}
