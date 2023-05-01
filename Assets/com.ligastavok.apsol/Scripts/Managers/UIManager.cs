using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private GameObject _gameRef;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;

    [Space(10)]
    [SerializeField] GameObject landOther;

    public static bool IsOverlay;


    private void Start()
    {
        OpenMenu();
    }

    public void Pause(bool IsPause)
    {
        IsOverlay = IsPause;
        pause.SetActive(IsPause);
    }

    public void StartGame()
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        landOther.SetActive(false);

        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

        pause.SetActive(false);
        menu.SetActive(false);
        game.SetActive(true);

        IsOverlay = false;
    }

    public void OpenMenu()
    {
        if(_gameRef)
        {
            Destroy(_gameRef);
        }

        landOther.SetActive(true);

        pause.SetActive(false);
        game.SetActive(false);
        menu.SetActive(true);

        IsOverlay = false;
    }
}
