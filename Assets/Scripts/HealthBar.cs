using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[Header("For Player")][SerializeField] PlayerController _playerController;
    [Header("For Enemy")][SerializeField] Enemy _enemy;
	[SerializeField] Slider _healthBar;

	void Update()
	{
        if(_playerController != null)
        {
            _healthBar.value = _playerController.health;

        }
        else if (_enemy != null)
        {
            _healthBar.value = _enemy.health;
        }
		
	}
}
