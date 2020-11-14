using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTower1Upgraded : MonoBehaviour
{
    
   private Transform _target;

    [Header("Tower Attributes")]
    public float _range  = 15f;
    public float fireRate = 1f;
    public float _turnSpeed = 10f;
    private float fireCountdown = 0f;

    [Header("Setup Fields")]
    public string enemyTag = "Enemy1";
    public string bossTag = "Boss1";

    public GameObject _rocketfab;
    public Transform firepoint;
    public Transform firepoint2;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget ()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //GameObject[] boss = GameObject.FindGameObjectsWithTag(bossTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        if (enemies.Length > 0){
            foreach (GameObject Enemy1 in enemies){
                float distanceToEnemy = Vector3.Distance(transform.position, Enemy1.transform.position);
                if(distanceToEnemy < shortestDist){
                    shortestDist = distanceToEnemy;
                    nearestEnemy = Enemy1;
                } 
            }
            if( nearestEnemy != null && shortestDist <= _range)
            _target = nearestEnemy.transform;
            if(shortestDist > _range)
            {
                _target = null;
            }
        }
        else{
            _target = null;
        }
        /*
         if (boss.Length > 0){
            foreach (GameObject Boss1 in boss){
                float distanceToEnemy = Vector3.Distance(transform.position, Boss1.transform.position);
                if(distanceToEnemy < shortestDist){
                    shortestDist = distanceToEnemy;
                    nearestEnemy = Boss1;
                } 
            }
            
            if( nearestEnemy != null && shortestDist <= _range)
            _target = nearestEnemy.transform;
            if(shortestDist > _range)
            {
                _target = null;
            }
        }
        else{
            _target = null;
        }
    */
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
        
        if (_target != null){
            Vector3 direction = _target.position - transform.position;
            direction.Normalize();
            float fixRotate = -90f;
            if (_target.position.x > transform.position.x){
                fixRotate = 90f;
            }
            Quaternion rotation = Quaternion.Euler(0,0,fixRotate) * Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 180);
            transform.rotation = rotation;
        }
      
        if (fireCountdown <= 0f){
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        
        Rocket rocket1 = null;
        Rocket rocket2 = null;

        Quaternion rotation = Quaternion.Euler(0,0,-90);
        if(Random.Range(1,3) == 1){
            GameObject TheShot = (GameObject)Instantiate(_rocketfab, firepoint.position, firepoint.rotation);
            rocket1 = TheShot.GetComponent<Rocket>();
        }
        else{
            GameObject TheShot2 = (GameObject)Instantiate(_rocketfab, firepoint2.position, firepoint2.rotation);
            rocket2 = TheShot2.GetComponent<Rocket>();
        }
        

        if(rocket1 != null){
            rocket1.Shooter(_target);
        }

        if(rocket2 != null){
            rocket2.Shooter(_target);
        }
    }
}