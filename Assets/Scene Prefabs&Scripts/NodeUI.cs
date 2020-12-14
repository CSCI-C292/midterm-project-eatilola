using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node _target;

    public Text _upgradeCost;

    public Text _sellAmount;


    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = new Vector3(_target.GetBuildPosition().x, _target.GetBuildPosition().y - .7f, _target.GetBuildPosition().z );
        
        

        if(!_target.isUpgraded)
        {
            _upgradeCost.text = "$" +_target.towerBlueprint._upgradeCost;
        }
        else{
            _upgradeCost.text = "Tower Maxed!";
           
        }

        _sellAmount.text = "$" +  target.towerBlueprint.GetSellAmount();

        ui.SetActive(true);


        
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        Debug.Log("" + _target);
        _target.UpgradeTower();

        BuildManager.instance.DeselectTower();
    }

    public void Sell()
    {
        _target.SellTower();
        BuildManager.instance.DeselectTower();
    }
}
