using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform _enemyPrefab;
    public Transform _enemy2Prefab;
    public Transform _enemy3Prefab;
    public Transform _enemy4Prefab;

    public Transform spawnPoint;

    public Wave[] waves;

    public string _levelToLoad;
    public float _timeBetweenWaves = 5.5f;
    private float _spawnTime = 2f;

    public Text waveTimer;
    private int _waveNumber = 0;

    public GameMaster gameMaster;

    [SerializeField] float _timeBetweenEnemies = 1f;
    void Start()
    {
        EnemiesAlive = 0;
        Time.timeScale = 1f;
        //Debug.Log("The Game Has Started!");
        //Debug.Log(_spawnTime);
        Debug.Log(EnemiesAlive);
    }

    // Update is called once per frame
    void Update()
    {

        if(EnemiesAlive > 0 || BossSpawner.BossAlive > 0){
            return;
        }

    if(!(_waveNumber == waves.Length))
    {
        if (_spawnTime < 0f){
            StartCoroutine(SpawnEnemyWave());
            _spawnTime = _timeBetweenWaves;
            return;
        }
        _spawnTime -= Time.deltaTime;

        waveTimer.text = Mathf.Round(_spawnTime).ToString();
    }
    else{
        if((EnemiesAlive <= 0 && BossSpawner.BossAlive <= 0)){
            Debug.Log("You Won");
            gameMaster.WinLevel();
            this.enabled =  false;
        }
    }
        
    }

    IEnumerator SpawnEnemyWave()
    {
        PlayerStats._rounds++;
        //Debug.Log(_waveNumber);

        Wave wave = waves[_waveNumber];

        for (int i = 0; i < wave._count; i++)
        {
            yield return new WaitForSeconds(1f / wave._rate);
            SpawnEnemy();
            yield return new WaitForSeconds(_timeBetweenEnemies);
        }

        _waveNumber++;
        Debug.Log("WaveNumber:"+_waveNumber);
        Debug.Log("Wave Length:"+ waves.Length);

       /* if((_waveNumber == waves.Length) && (EnemiesAlive <= 0 && BossSpawner.BossAlive <= 0)){
            Debug.Log("You Won");
            SceneManager.LoadScene(_levelToLoad);
            this.enabled =  false;
        }
        */
    }

    void SpawnEnemy()
    {
        if ( _waveNumber < 5){
            Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
        }
        else if((_waveNumber >= 5) && (_waveNumber < 10)){
            if (Random.Range(1,3) == 1){
                 Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                 EnemiesAlive++;
             }
            else{
                 Instantiate(_enemy2Prefab, spawnPoint.position, spawnPoint.rotation);
                 EnemiesAlive++;
             }
        }
        else if((_waveNumber >= 10) && (_waveNumber < 20)){
            if (Random.Range(1,3) == 1){
                Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                EnemiesAlive++;
            }
            else if(Random.Range(1,3) == 2){
                Instantiate(_enemy2Prefab, spawnPoint.position, spawnPoint.rotation);
                EnemiesAlive++;
            }
            else{
                Instantiate(_enemy3Prefab, spawnPoint.position, spawnPoint.rotation);
                EnemiesAlive++;
            }
        }
        else if(_waveNumber >= 20){
            if (Random.Range(1,5) == 1){
                Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                EnemiesAlive++;
            }
            else if(Random.Range(1,5) == 2){
                Instantiate(_enemy2Prefab, spawnPoint.position, spawnPoint.rotation);
                EnemiesAlive++;
            }
            else if(Random.Range(1,5) == 3){
                Instantiate(_enemy3Prefab, spawnPoint.position, spawnPoint.rotation);
                EnemiesAlive++;
            }
            else{
                Instantiate(_enemy4Prefab, spawnPoint.position, spawnPoint.rotation);
                EnemiesAlive++;
            }
        }
        
       
    }
    
}
