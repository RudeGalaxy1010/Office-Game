using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Pedestal _parent;

    public ItemType ItemType => _itemType;

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
        if (Vector3.Distance(transform.position, _parent.transform.position) < 3f)
        {
            _parent.Place(gameObject);
            return true;
        }

        return false;
    }
}
