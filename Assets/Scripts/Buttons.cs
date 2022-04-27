using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Buttons : MonoBehaviour
{
    public UnityEngine.UI.Text Highscore;
    public virtual void Update()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        this.Highscore.text = "H i g h s c o r e : " + PlayerPrefs.GetInt("Best").ToString();
    }

    public virtual void QuitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }

    public virtual void MainMenu()
    {
        Application.LoadLevel("MainMenu");
        Time.timeScale = 1;
    }

    public virtual void PLAY()
    {
        Application.LoadLevel("Endless");
    }

}