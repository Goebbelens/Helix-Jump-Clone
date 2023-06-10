using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Player Player;
    

    private void Update()
    {
        Text.text = (Player.Score).ToString();
    }
}
