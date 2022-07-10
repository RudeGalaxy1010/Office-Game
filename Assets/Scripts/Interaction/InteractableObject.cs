using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] protected Pedestal Parent;

    public bool TryTake(Transform parent)
    {
        if (Vector3.Distance(transform.position, parent.transform.position) < 3f)
        {
            transform.position = parent.position;
            transform.SetParent(parent);
            return true;
        }

        return false;
    }

    public bool TryReturn()
    {
        if (Vector3.Distance(transform.position, Parent.transform.position) < 3f)
        {
            Parent.Place(gameObject);
            transform.SetParent(Parent.transform);
            return true;
        }

        return false;
    }
}
