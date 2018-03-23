using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtilities : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
            {
                LoadLastScene();
            }
            else
            {
                ExitApp();
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }



    public void ExitApp()
    {
        Application.Quit();
    }



    public void ChangeScenes(string aScanaName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(aScanaName);
    }


    public void LoadLastScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 1);
    }



    public float CheckScreenSize()
    {
        float height = Screen.height;
        float width = Screen.width;
        float dpi = Screen.dpi;

        height *= height;
        width *= width;

        float diag = Mathf.Sqrt(width + height) / dpi;

        return diag;
    }



    public void DisableGameobject(GameObject aObject)
    {
        aObject.SetActive(false);
    }



    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }
}