using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class setId : MonoBehaviour
{
  
    
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("currentid"))
        {
            GetComponent<TextMeshProUGUI>().text =  PlayerPrefs.GetInt("currentid").ToString();
        }
    }
}
