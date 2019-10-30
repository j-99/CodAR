using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_end : MonoBehaviour
{


    public void mainMenu(){
        SceneManager.LoadScene(0);
    }

    public void retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void next(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
