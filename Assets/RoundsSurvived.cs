using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoundsSurvived : MonoBehaviour
{
   public Text roundsText;
   
   void OnEnable()
    {
        roundsText.text = PlayerStats._rounds.ToString();
    }
}
