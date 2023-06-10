using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    public GameObject DeathMenu;
    public GameObject WinMenu;

    public void SetDeathMenuActive()
    {
        DeathMenu.SetActive(true);
    }


}
