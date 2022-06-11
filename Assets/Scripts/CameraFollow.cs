using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject _player;

    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);   
    }
}
