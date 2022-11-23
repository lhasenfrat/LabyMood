using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    List<string> condition = new List<string>() { "Cheer", "Peace", "Stress" };
    List<int> generatedIds = new List<int>();
    int currentId;
    System.Random rnd = new System.Random();
    bool continuousMove = false;
    public GameObject Player;
    public void init()
    {
        do
        {
            currentId = rnd.Next(10000);
        } while (generatedIds.Contains(currentId));
        generatedIds.Add(currentId);
        PlayerPrefs.SetInt("currentid",currentId);
        condition = condition.OrderBy(_ => rnd.Next()).ToList();

    }
    public void StartGame(int number)
    {
        SceneManager.LoadScene("mazegeneration" + condition[number]);
        PlayerPrefs.SetString("condition", condition[number]);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void changeMovement()
    {
        continuousMove = !continuousMove;
        if (continuousMove)
        {
            PlayerPrefs.SetString("Movement","Continuous");
        } else
        {
            PlayerPrefs.SetString("Movement", "Teleport");

        }

        Player.GetComponent<MovementManager>().ChangeMovement();
    }
}
