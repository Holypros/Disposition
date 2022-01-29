using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject gameMenu1;
    public bool isPlayerDead = false;
    bool isGamePaues = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPlayerDead)
        {
            isGamePaues = !isGamePaues;
        }
        if(isGamePaues && !isPlayerDead)
        {
            gameMenu1.SetActive(true);
             Cursor.lockState = CursorLockMode.None;
                 Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            Time.timeScale = 0f;

        }
        else if(!isGamePaues && !isPlayerDead)
        {
            gameMenu1.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }
    public void UnPause()
    {
        Debug.Log("Pressed");
        isGamePaues = false;
        Time.timeScale = 1f;
    }
   
       public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Rerty()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(2);
    }
}
