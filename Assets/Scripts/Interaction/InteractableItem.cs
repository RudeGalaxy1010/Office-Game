using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractableItem : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Pedestal _parent;
    [SerializeField] private float _interactionDistance = 3f;

    public ItemType Type => _itemType;

    public bool TryTake(Transform parent)
    {
        if (Vector3.Distance(transform.position, parent.transform.position) < _interactionDistance)
        {
            transform.position = parent.position;
            transform.SetParent(parent);
            return true;
        }

        return false;
    }

    public bool TryReturn()
    {
        if (Vector3.Distance(transform.position, _parent.transform.position) < _interactionDistance)
        {
            _parent.Place(gameObject);
            return true;
        }

        return false;
    }
}
