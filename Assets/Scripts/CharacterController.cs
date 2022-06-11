using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{                        
	[Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;  
    [SerializeField] Animator _animator;                      
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _attackArea;

    private Rigidbody2D _rigidbody2D;
	private bool _facingRight = true;
	private bool _attacking = false;
	private Vector3 _velocity = Vector3.zero;
	private float _timeToAttack = 0.25f;
	private float _timer = 0f;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        if (_attacking)
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeToAttack)
            {
                _timer = 0;
                _attacking = false;
                _attackArea.SetActive(_attacking);
            }
        }
    }

    public void Move(float move, float acceleration, bool jump, bool attack, bool dead)
	{
        if (!dead)
        {
            if (attack)
            {
                
                _attacking = true;
                _attackArea.SetActive(_attacking);
                _animator.Play("Attack_1");
            }
            else
            {
                if (move != 0)
                {
                    if (Mathf.Abs(move) < 1.5f && Mathf.Abs(move) >= 0.1f)
                    {
                        _animator.Play("Walk");
                    }

                    else if (Mathf.Abs(move) >= 1.5f)
                    {
                        _animator.Play("Run");
                    }
                    else if (Mathf.Abs(move) < 0.1f)
                    {
                        _animator.Play("Idle");
                    }
                }


            }

            Vector3 targetVelocity = new Vector2(move * acceleration, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);

            if (move > 0 && !_facingRight)
            {
                Flip();
            }
            else if (move < 0 && _facingRight)
            {
                Flip();
            }
        }

        else
        {
            _animator.Play("Death");
        }
	}

	private void Flip()
	{
        _facingRight = !_facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}