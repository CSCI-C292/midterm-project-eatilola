using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake()
    {
        if(instance != null){
            return;
        }
        instance = this;
    }
    private TowerBlueprint towerToBuild;
    private Node selectedTower;
    public NodeUI nodeUI;

    /*
    public void BuildTowerOn(Node node)
    {
        if(PlayerStats._currency < towerToBuild._cost){
            Debug.Log("Not enough Money: Your Broke!");
            return;
        }

        PlayerStats._currency -= towerToBuild._cost;

        GameObject _tower = (GameObject) Instantiate(towerToBuild._towerPrefab, node.GetBuildPosition(), Quaternion.identity);
        node.tower = _tower;

        Debug.Log("Tower Has Been Built, You have "+"$"+PlayerStats._currency+" Left");
    }
    */

    public bool CanBuild { get { return towerToBuild != null;}}

    public bool HasMoney { get { return PlayerStats._currency >= towerToBuild._cost;}}

    public void SelectedTower(Node node)
    {
        if (selectedTower == node){
            DeselectTower();
            return;
        }
        selectedTower = node;
        towerToBuild = null;

        nodeUI.SetTarget(node);
        
    }

    public void DeselectTower()
    {
        selectedTower  =  null;
        nodeUI.Hide();
    }
    public void SelectTowerToBuild(TowerBlueprint _tower)
    {
        towerToBuild = _tower;
        DeselectTower();
       
    }
    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }


    
}
