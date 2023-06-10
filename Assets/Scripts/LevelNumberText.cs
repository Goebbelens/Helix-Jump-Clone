using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelNumberText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Game Game;

    private void Start()
    {
        Text.text = "Level " + (Game.LevelIndex + 1).ToString();
    }

}
