using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Open(GameObject penal)
    {
        penal.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close(GameObject penal)
    {
        penal.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
