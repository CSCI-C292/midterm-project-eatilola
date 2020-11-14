using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject _towerPrefab;
    public int _cost;

    public GameObject _upgradedTowerPrefab;
    public int _upgradeCost;

    public int _sellCost;

    public int GetSellAmount()
    {

        
            _sellCost = (_cost / 2);
           return _sellCost;
    }
}
