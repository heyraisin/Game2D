using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScreen");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
