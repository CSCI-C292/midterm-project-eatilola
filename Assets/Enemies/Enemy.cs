using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 0.1f;
    private float _health ;

    public float _startHealth = 100f;

    public int _value = 50;

    private Transform _target;

    private int wavepointIndex = 0;

    public Image healthBar;
    void Start()
    {
        _target = Waypoints.wayPoints[0];
        _health = _startHealth;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        healthBar.fillAmount = _health / _startHealth;

        if(_health <= 0){ 

            Die();

        }

        Debug.Log("I just took " + amount + " amount of damage");
        Debug.Log("I have " + _health +" health Left");
    }

    void Die()
    {
        PlayerStats._currency += _value;
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.1f){
            GetNextWayPoint();
            Vector3 direction = _target.position - transform.position;
            direction.Normalize();
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, -90);
            transform.rotation = rotation;

            /*Vector3 dir2 = new Vector3(_target.position.x, _target.position.y, 0);
            //Vector2 dir3 = (Vector2)_target.position - (Vector2) transform.position ;
            //transform.Rotate(dir3);
            //dir2 = Quaternion.Euler(90, 0, 0) * dir2;
            transform.LookAt(_target.position);
            //transform.Rotate(Vector3.up, 90);
            */
        }
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.wayPoints.Length - 1){
            EndPath();
            return;
        }
        
        wavepointIndex++;
        _target = Waypoints.wayPoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats._life--;
        Destroy(gameObject);
    }

}