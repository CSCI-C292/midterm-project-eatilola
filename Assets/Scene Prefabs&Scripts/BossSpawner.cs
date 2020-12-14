using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class BossSpawner : MonoBehaviour
{
    public static int BossAlive = 0;
    public Transform _kingPrefab;
    public Transform _queenPrefab;

    public Transform spawnPoint;

    public Wave[] waves;

    public float _timeBetweenWaves = 5.5f;
    private float _spawnTime = 2f;

    //public Text BossTimer;
    private int _waveNumber = 0;

    [SerializeField] float _timeBetweenEnemies = 1f;
    void Start()
    {
        BossAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((WaveSpawner.EnemiesAlive > 0 || BossAlive > 0) && _timeBetweenWaves > 0){
            return;
        }
    
        if (_spawnTime < 0f){
            StartCoroutine(SpawnEnemyWave());
            _spawnTime = _timeBetweenWaves;
        }
        _spawnTime -= Time.deltaTime;

        //waveTimer.text = Mathf.Round(_spawnTime).ToString();
    }

    IEnumerator SpawnEnemyWave()
    {
       Wave wave = waves[_waveNumber];

        for (int i = 0; i < wave._count; i++)
        {
            yield return new WaitForSeconds(0.8f);
            SpawnEnemy();
            yield return new WaitForSeconds(_timeBetweenEnemies);
        }

        _waveNumber++;
        //PlayerStats._rounds++;
        if(_waveNumber == waves.Length){
            this.enabled =  false;
        }
        
        
    }

    void SpawnEnemy()
    {
        if (Random.Range(1,4) == 1 || Random.Range(1,4) == 4)
        {
            Instantiate(_kingPrefab, spawnPoint.position, spawnPoint.rotation); 
            BossAlive++;
        }
        else{
            Instantiate(_queenPrefab, spawnPoint.position, spawnPoint.rotation);
            BossAlive++;
        }
       
    }
    
}
