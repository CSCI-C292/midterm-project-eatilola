using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float _strtSpeed = 0.5f;

    [HideInInspector]
    public float _speed;

    private float _health ;

    public float _startHealth = 100f;

    public int _value = 50;

    public WaveSpawner _totalEnemies;


    public Image healthBar;

    void Start()
    {
        _speed = _strtSpeed;
        _health = _startHealth;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;

        healthBar.fillAmount = _health / _startHealth;

        if(_health <= 0){ 

            Die();

        }

        //Debug.Log("I just took " + amount + " amount of damage");
        //Debug.Log("I have " + _health +" health Left");
    }

    public void Slow( float amount)
    {
        _speed = (_strtSpeed * (1f - amount)) + .1f;
    }

    void Die()
    {
        PlayerStats._currency += _value;

        if(_startHealth < 1000){
            WaveSpawner.EnemiesAlive--; 
        }
        else{
            BossSpawner.BossAlive--;
        }

        Destroy(gameObject);
    }


    
}