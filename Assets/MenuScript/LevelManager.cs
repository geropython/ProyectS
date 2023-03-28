using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Death()
    {
        SceneManager.LoadScene("Death");
    }
    public void Victory()
    {
        SceneManager.LoadScene("Victory");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}