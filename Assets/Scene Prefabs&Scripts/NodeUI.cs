using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Node _target;
    //public GameObject arrow;

    public void SetTarget(Node target)
    {
        _target = target;
        //Debug.Log("" + _target);
        transform.position = new Vector3(_target.GetBuildPosition().x, _target.GetBuildPosition().y - .7f, _target.GetBuildPosition().z );

        ui.SetActive(true);
        
    }
    public void Hide()
    {
        //ui.G.SetActive(false);
        ui.SetActive(false);
       
    }
    public void Upgrade()
    {
        Debug.Log("" + _target);
        _target.UpgradeTower();

        BuildManager.instance.DeselectTower();
    }
}
