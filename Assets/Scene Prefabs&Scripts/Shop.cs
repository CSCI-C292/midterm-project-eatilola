using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint SoldierTower1;
    public TowerBlueprint TurretTower1;
    public TowerBlueprint TurretTower2;
    public TowerBlueprint LazerTower;
    BuildManager buildManager;
    
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectSoldierTower()
    {
        Debug.Log("Soldier bought");
        buildManager.SelectTowerToBuild(SoldierTower1);
    }
    public void SelectTurretTower()
    {
        Debug.Log("Turret bought");
        buildManager.SelectTowerToBuild(TurretTower1);
    }
    public void SelectTurretTower2()
    {
        Debug.Log("Turret bought");
        buildManager.SelectTowerToBuild(TurretTower2);
    }
    public void SelectLazerTower()
    {
        Debug.Log("Tower bought");
        buildManager.SelectTowerToBuild(LazerTower);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
