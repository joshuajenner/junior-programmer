using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetPlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;


    // Start is called before the first frame update
    void Start()
    {
        nameLabel.text = PlayerDataManager.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
