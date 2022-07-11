using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _itemHolder;

    private InteractableItem _currentItem;

    public ItemType ItemType => _currentItem == null ? ItemType.None : _currentItem.Type;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycast(Input.mousePosition);
        }
    }

    private void Raycast(Vector2 touchPosition)
    {
        Ray ray = _camera.ScreenPointToRay(touchPosition);
        Physics.Raycast(ray, out RaycastHit hit);

        if (hit.collider == null)
        {
            return;
        }

        if (hit.collider.TryGetComponent(out InteractableItem item))
        {
            TryTakeInteractable(item);
        }
        else if (hit.collider.TryGetComponent(out Pedestal pedestal) && _currentItem != null)
        {
            TryReleaseInteractable(_currentItem);
        }
    }

    private void TryTakeInteractable(InteractableItem item)
    {
        if (item.TryTake(_itemHolder))
        {
            _currentItem = item;
        }
    }

    private void TryReleaseInteractable(InteractableItem item)
    {
        if (item.TryReturn())
        {
            _currentItem = null;
        }
    }
}
