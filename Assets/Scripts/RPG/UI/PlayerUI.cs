using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Entities;
using UnityEngine;
using UnityEngine.UI;


namespace RPG.UI
{

    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private Image _health;
        [SerializeField] private Player _player;
        [SerializeField] private float _lerpSpeed = 2.5f;
        [SerializeField] private Text _name;
        [SerializeField] private Text _level;
        [SerializeField] private Text _healthValue;
        private readonly float _yellowHealthPercent = .5f;
        private readonly float _redHealthPercent = .3f;

        // Use this for initialization
        void Start ()
	    {
	        _player = UnityEngine.GameObject.FindWithTag("Player").GetComponent<Player>();
            if(!_player) Debug.LogError("Player Not found");
	        _healthBar = gameObject.GetComponentInChildren<Image>();
	        _health = _healthBar.gameObject.GetComponentsInChildren<Image>()[1];
	        _name = gameObject.GetComponentInChildren<Text>();
	        _level = gameObject.GetComponentsInChildren<Text>()[1];
	        _healthValue = gameObject.GetComponentsInChildren<Text>()[2];

        }
	
	    // Update is called once per frame
	    void LateUpdate ()
	    {
	        HealthChange();
	        _name.text = _player.Name;
	        _level.text = "Level: " + _player.Level;
	        _healthValue.text = "Health: " + Mathf.RoundToInt(_health.fillAmount * _player.MaxHealth) + " / " + _player.MaxHealth;
	    }

        void HealthChange()
        {
            if (_player.MaxHealth != 0)
            {
                _health.fillAmount = Mathf.Lerp(_health.fillAmount, _player.Health / (float)_player.MaxHealth, Time.deltaTime * _lerpSpeed);
            }

            if (_player.Health / (float)_player.MaxHealth > _yellowHealthPercent)
            {
                _health.color = Color.green;
            }
            else if (_player.Health / (float)_player.MaxHealth > _redHealthPercent)
            {
                _health.color = Color.yellow;
            }
            else _health.color = Color.red;
        }
    }

}
