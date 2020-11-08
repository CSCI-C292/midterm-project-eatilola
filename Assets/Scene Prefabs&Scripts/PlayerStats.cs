using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int _currency;
    public int _startMoney = 500;

    public static int _life;
    public int _startHealth = 100;

    public static int _rounds;
    // Start is called before the first frame update
    void Start()
    {
        _currency = _startMoney;
        _life = _startHealth;

        _rounds = 0;
    }

}
