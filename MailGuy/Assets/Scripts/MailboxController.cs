using UnityEngine;

public class MailboxController : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        // if (player)
        // {
        //     player.DeliverMail();
        //     Destroy(gameObject);
        // }
    }

    public void Interact(PlayerController player)
    {
        Destroy(gameObject);
        player.DeliverMail();
    }

    public bool CanInteract(PlayerController player)
    {
        return true;
    }
}
