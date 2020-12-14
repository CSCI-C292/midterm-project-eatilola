using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTower : MonoBehaviour
{
    
    private Transform _target;
    private Enemy _targetEnemy;

    [Header("Tower Attributes")]
    public float _range  = 15f;
    public float fireRate = 1f;
    public float _turnSpeed = 10f;
    //private float fireCountdown = 0f;

    [Header("Setup Fields")]
    public string enemyTag = "Enemy1";
    public string bossTag = "Boss1";

    [Header("Laser Attributes")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public Transform firepoint;
    public ParticleSystem ImpactEffect;
    public int damageOverTime = 10;
    public float _slowPct = 0.3f;
    

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
            if( nearestEnemy != null && shortestDist <= _range){
                _target = nearestEnemy.transform;
                _targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }
          
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
            LockOnTarget();

            if(useLaser){
                Laser();
            }
        }
        else{
            if(useLaser){
                if(lineRenderer.enabled)
                    lineRenderer.enabled = false;
                    ImpactEffect.Stop();
            }
        }
        
      
        
    }

    void LockOnTarget()
    {
         Vector3 direction = _target.position - transform.position;
            direction.Normalize();
            float fixRotate = -90f;
            if (_target.position.x > transform.position.x){
                fixRotate = 90f;
            }
            Quaternion rotation = Quaternion.Euler(0,0,fixRotate) * Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 180);
            transform.rotation = rotation;
    }

    void Laser()
    {
        _targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        _targetEnemy.Slow(_slowPct);

        if(!lineRenderer.enabled){
            lineRenderer.enabled = true;
            ImpactEffect.Play();
        }
        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1, _target.position);

        Vector3 dir = firepoint.position - _target.position;

        ImpactEffect.transform.position = new Vector3(_target.position.x , _target.position.y, _target.position.z -.5f)+ dir.normalized * .5f;

        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

}
