using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 0.1f;
    private int mailToDeliver = 5;
    public UIDocument GameUIDoc;
    public Animator PlayerAnimator;
    private Rigidbody2D rb;
    InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GameUIDoc.rootVisualElement.Q<Label>().text = "Mail Remaining: " + mailToDeliver;
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        // Check for movement
        UnityEngine.Vector2 move = moveAction.ReadValue<UnityEngine.Vector2>();

        rb.linearVelocity = move * moveSpeed;

        Camera.main.transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        if (move.x != 0 || move.y != 0)
        {
            PlayerAnimator.SetBool("IsMoving", true);
        }
        else
        {
            PlayerAnimator.SetBool("IsMoving", false);
        }
    }

    public void DeliverMail()
    {
        mailToDeliver -= 1;
        if (mailToDeliver == 0)
        {
            GameUIDoc.rootVisualElement.Q<Label>().text = "VICTORY!";
        }
        else
        {
            GameUIDoc.rootVisualElement.Q<Label>().text = "Mail Remaining: " + mailToDeliver;
        }
    }

    public void KillPlayer()
    {
        GameUIDoc.rootVisualElement.Q<Label>().text = "YOU HAVE DIED";
        Destroy(gameObject);
    }
}
