using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Enemy>() != null)
        {
            collider.GetComponent<Enemy>().LossHealth(10);
        }

        if (collider.GetComponent<PlayerController>() != null)
        {
            collider.GetComponent<PlayerController>().LossHealth(5);
            Debug.Log("Player hit");
        }
    }

    
}
