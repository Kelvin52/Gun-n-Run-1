using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

	

public class GameStart : MonoBehaviour
{

 
    //Game start
    public void OnGameStartButtonClicked()
    {
        //load to main scenes
        SceneManager.LoadScene("Main");
    }
}

