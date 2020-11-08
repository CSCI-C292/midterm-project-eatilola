using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor; 
    public Color brokeColor;

    [HideInInspector]
    public GameObject tower;
    public TowerBlueprint towerBlueprint;
    public bool isUpgraded = false;
    private Color strtColor;
    public string grassTag = "Grass";

    private SpriteRenderer rend;
    BuildManager buildManager;
    void Start()
    {
    
        GameObject[] placableGrass = GameObject.FindGameObjectsWithTag(grassTag);
        if (placableGrass.Length > 0){
            foreach (GameObject Grass in placableGrass)
            {
                rend = (SpriteRenderer)GetComponent<Renderer>();
                
            }
        }
        buildManager = BuildManager.instance;
 
        strtColor = rend.color;
    }

    public Vector3 GetBuildPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
    }

    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        return;
        
         

        if (tower != null){
            buildManager.SelectedTower(this);
            //Debug.Log("" + this);
            return;
        }

        if(!buildManager.CanBuild)
        return;

        BuildTower(buildManager.GetTowerToBuild());

    }

    void BuildTower(TowerBlueprint blueprint)
    {
        if(PlayerStats._currency < blueprint._cost){
            Debug.Log("Not enough Money: Your Broke!");
            return;
        }

        PlayerStats._currency -= blueprint._cost;

        GameObject _tower = (GameObject) Instantiate(blueprint._towerPrefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        towerBlueprint = blueprint;

        Debug.Log("Tower Has Been Built, You have "+"$"+PlayerStats._currency+" Left");
    }    

    public void UpgradeTower()
    {
        if(PlayerStats._currency < towerBlueprint._upgradeCost){
            Debug.Log("Not enough Money: Your Broke!");
            return;
        }

        PlayerStats._currency -= towerBlueprint._upgradeCost;

        Destroy(this.tower);

        GameObject _tower = (GameObject) Instantiate(towerBlueprint._upgradedTowerPrefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        isUpgraded = true;
        Debug.Log("Tower Has Been Upraded, You have "+"$"+PlayerStats._currency+" Left");
    }
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        return;


        if(!buildManager.CanBuild)
        return;
        
        if(buildManager.HasMoney){
            rend.color = hoverColor;
        }
        else{
            rend.color = brokeColor;
        }
        
        
    }
 
    void OnMouseExit ()
    {
        rend.color = strtColor;
    }
}
