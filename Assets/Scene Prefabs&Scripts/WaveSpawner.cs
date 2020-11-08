using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public Transform _enemyPrefab;

    public Transform spawnPoint;

    public int[] waves;

    public float _timeBetweenWaves = 5.5f;
    private float _spawnTime = 2f;

    public Text waveTimer;
    private int _waveNumber = 0;

    [SerializeField] float _timeBetweenEnemies = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (_spawnTime < 0f){
            StartCoroutine(SpawnEnemyWave());
            _spawnTime = _timeBetweenWaves;
        }
        _spawnTime -= Time.deltaTime;

        waveTimer.text = Mathf.Round(_spawnTime).ToString();
    }

    IEnumerator SpawnEnemyWave()
    {
        
        for (int i = 0; i < waves[_waveNumber]; i++)
        {
            yield return new WaitForSeconds(0.8f);
            SpawnEnemy();
            yield return new WaitForSeconds(_timeBetweenEnemies);
        }

        _waveNumber++;
        PlayerStats._rounds++;
        
    }

    void SpawnEnemy()
    {
        //
        Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
       
    }
    
}
