using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField] GameObject _win;
    [SerializeField] GameObject _lose;

    [SerializeField] GameObject[] _enemyInScene;

    void Update()
    {
        _enemyInScene = GameObject.FindGameObjectsWithTag("Enemy");
        if(_enemyInScene.Length == 0)
        {
            _win.SetActive(true);
        }

        else if (_player.dead)
        {
            _lose.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
