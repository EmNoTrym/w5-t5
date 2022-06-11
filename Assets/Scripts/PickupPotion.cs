using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Colliding");
            collider.GetComponent<PlayerController>().LossHealth(-20);
            Destroy(gameObject);
        }
    }
}
