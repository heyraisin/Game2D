using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject misstionText;
    [SerializeField] GameObject cancelText;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void openNotice()
    {
        misstionText.SetActive(true);
    }

    public void closeNotice()
    {
        misstionText.SetActive(false);
    }
}
