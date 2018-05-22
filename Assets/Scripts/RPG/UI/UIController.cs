using System.Collections;
using System.Collections.Generic;
using RPG.Entities;
using UnityEngine;

namespace RPG.UI
{

    public class UIController : MonoBehaviour
    {
        public static UIController controller;
        
        [SerializeField] private PlayerUI _playerUI;
        [SerializeField] private Player _player;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private UnityEngine.GameObject _UIPrefab;
        [SerializeField] private UnityEngine.GameObject _playerUIPrefab;
        private void Awake()
        {
            if (controller == null)
            {
                DontDestroyOnLoad(gameObject);
                controller = this;
            }
            else if(this != controller)
            {
                Destroy(this);
            }
        }

        // Use this for initialization
        void Start()
        {
            if (_player == null)
            {
                _player = FindObjectOfType<Player>();
            }

            if (_canvas == null)
            {
                _canvas = FindObjectOfType<Canvas>();
                if (_canvas.gameObject.name != "UI")
                {
                    Destroy(_canvas.gameObject);
                    _canvas = null;
                }
                if (_canvas == null)
                {
                    _canvas = Instantiate(_UIPrefab, Vector3.zero, Quaternion.identity).GetComponent<Canvas>();
                    _playerUI = _canvas.gameObject.GetComponentInChildren<PlayerUI>();
                    
                    if(!_player)
                    {
                        Destroy(_playerUI.gameObject);
                        _playerUI = null;
                    }
                }
                else if (_player && !_playerUI)
                {
                    _playerUI = Instantiate(_playerUIPrefab, _canvas.transform).GetComponent<PlayerUI>();
                }
                foreach (Canvas canvas in FindObjectsOfType<Canvas>())
                {
                    if(canvas != _canvas) Destroy(canvas.gameObject);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}