using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}


public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str ;
    }

    public void OnInteract()
    {
        switch (data.type)
        {
            case ItemType.usable:
                if (data.displayName == "Jump Pad")
                {
                    JumpEffect();
                }
                break;

            case ItemType.consumable:
                if (data.displayName == "Speed Item")
                {
                    float boost = data.consumable.value;
                    float duration = data.consumable.duration;

                    CharacterManager.Instance.Player.controller.BoostSpeed(boost, duration);
                    Destroy(gameObject);
                }
                break;
        }
    }

    private void JumpEffect()
    {
        Rigidbody rb = CharacterManager.Instance.Player.controller.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float jumpForce = 200f; 
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            OnInteract();
        }
    }
}
