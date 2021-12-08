using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] Texture2D cursor;
    private void Start()
    {
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
    }
    public void ClickStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void ClickScores()
    {
        SceneManager.LoadScene("Scores");
    }

    public void ClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ClickExitGame()
    {
        Application.Quit();
    }
}
