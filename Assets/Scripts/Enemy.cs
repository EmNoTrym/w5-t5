using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _attackArea;
    [SerializeField] GameObject _healthPotion;
    [SerializeField] Animator _animator;
    [SerializeField] float _move;
    [SerializeField] float _detectRange;
    [SerializeField] float _attackRange;

    private Rigidbody2D _rigi2D;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _healthPotionSpawnOffset = new Vector3(0, 1f, 0);
    private bool _isMoving;
    private bool _isAttacking;
    private bool _isDead = false;
    private bool _isStartCountdownDeath = false;
    private float _timeToAttack = 0.5f;
    private float _timer = 0f;
    private float _deathLength = 1.5f;

    private void Start()
    {
        _rigi2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            _isDead = true;
            if (!_isStartCountdownDeath)
            {
                StartCoroutine(TimeBeforeDisapear());
                _isStartCountdownDeath = true;
            }
        }

        if (!_isDead)
        {
            _moveDirection = Vector3.zero;

            float distance = Vector2.Distance(_player.transform.position,transform.position);
            Debug.Log(distance);
            if (distance <= _detectRange && distance > _attackRange)
            {
                Vector3 direction = _player.transform.position - transform.position;
                direction.y = 0;

                _moveDirection = direction.normalized;
                _isMoving = true;
                _isAttacking = false;
            }
            else if (distance <= _attackRange && !_isAttacking)
            {
                _animator.Play("Attack_2");
                _isAttacking = true;
                _isMoving = false;
            }

            if (_isAttacking)
            {
                _attackArea.SetActive(true);
                _timer += Time.deltaTime;
                if (_timer >= _timeToAttack)
                {
                    _attackArea.SetActive(false);
                    _isAttacking = false;
                    _timer = 0;

                }
            }

            if (_isMoving)
            {
                _animator.Play("Walk");
            }
        }

        else
        {
            _isAttacking = false;
            _isMoving = false;

            _animator.Play("Death");
        }
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _rigi2D.velocity = _moveDirection * _move;
        }
    }
    public void LossHealth(float value)
    {
        _animator.Play("Hurt");
        health -= value;
    }

    IEnumerator TimeBeforeDisapear()
    {
        yield return new WaitForSeconds(_deathLength);
        Debug.Log("FinishCoundown");
        
        Instantiate(_healthPotion, transform.position + _healthPotionSpawnOffset, _healthPotion.transform.rotation);
        Destroy(gameObject);
    }
}
