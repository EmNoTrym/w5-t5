using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(.0f, 100.0f)] public float health = 100.0f;
    [Range(0.5f, 3.0f)][SerializeField] float _speed = 0.5f;
    [SerializeField] float _acceleration = 4.0f;

    
    private CharacterController _controller;
    private float _input;
    public bool jump = false;
    public bool attack = false;
    public bool dead = false;

    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            dead = true;
        }
        else
        {
            _input = Input.GetAxis("Horizontal") * _speed;

            if (Input.GetButtonDown("Fire1"))
            {
                attack = true;
            }
        }
    }

    private void FixedUpdate()
    {
        _controller.Move(_input, _acceleration, jump, attack, dead);

        if (attack)
        {
            attack = false;
        }

        if (jump)
        {
            jump = false;   
        }
    }

    public void LossHealth(float value)
    {
        health -= value;
    }


}
