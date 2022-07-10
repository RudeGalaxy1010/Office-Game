using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _itemHolder;

    private InteractableObject _interactableObject;

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

        if (hit.collider.TryGetComponent(out InteractableObject interactable))
        {
            TryTakeInteractable(interactable);
        }
        else if (hit.collider.TryGetComponent(out Pedestal pedestal) && _interactableObject != null)
        {
            TryReleaseInteractable(_interactableObject);
        }
    }

    private void TryTakeInteractable(InteractableObject interactable)
    {
        if (interactable.TryTake(_itemHolder))
        {
            _interactableObject = interactable;
        }
    }

    private void TryReleaseInteractable(InteractableObject interactable)
    {
        if (interactable.TryReturn())
        {
            _interactableObject = null;
        }
    }
}
