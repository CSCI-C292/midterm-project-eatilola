using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform _target;
    public float _speed = 10f;

    public int _damage = 100;

    public void Shooter(Transform target)
    {
        _target = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distInFrame = _speed * Time.deltaTime;

        if(dir.magnitude <= distInFrame){
            Hit(_target);
            Destroy(gameObject);
            return;
        }

        transform.Translate(dir.normalized * distInFrame, Space.World);
    
        
    }

   void Hit(Transform _enemy)
    {
        Enemy en = _enemy.GetComponent<Enemy>();
    
        if (en != null){
            en.TakeDamage(_damage);
        }
    }
}
