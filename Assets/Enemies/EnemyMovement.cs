using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour
{
    private Transform _target;

    private int wavepointIndex = 0;

    private Enemy _enemy;

    public WaveSpawner _totalEnemies;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = Waypoints.wayPoints[0];
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemy._speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.1f){
            GetNextWayPoint();
            Vector3 direction = _target.position - transform.position;
            direction.Normalize();
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, -90);
            transform.rotation = rotation;
        }

        _enemy._speed = _enemy._strtSpeed;
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
        if(_enemy._startHealth < 1000)
        {
            PlayerStats._life--;
        }
        else 
        {
            if(_enemy._startHealth > 1000 && _enemy._startHealth < 3500){
                PlayerStats._life = PlayerStats._life - 10;
            }
            else
            {
                PlayerStats._life = PlayerStats._life - 15;
            }
            
        }
        
        if(_enemy._startHealth > 1000){
            BossSpawner.BossAlive--;
        }
        else{
            WaveSpawner.EnemiesAlive--;
        }

        Destroy(gameObject);
    }

}
