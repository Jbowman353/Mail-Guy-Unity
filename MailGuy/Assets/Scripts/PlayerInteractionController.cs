using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    private IInteractable NearbyInteractable = null;
    private PlayerController Player;
    private InputAction interactAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GetComponentInParent<PlayerController>();
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (interactAction.IsPressed())
        {
            NearbyInteractable?.Interact(Player);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract(Player))
        {
            NearbyInteractable = interactable;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == NearbyInteractable)
        {
            NearbyInteractable = null;
        }
    }
}
