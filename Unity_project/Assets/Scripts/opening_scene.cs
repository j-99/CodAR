using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class opening_scene : MonoBehaviour
{
        public Button[] levels;
        private int click = 0;
        public Animator devText;
        public Animator userText;

        public void levelUpdate(){
            int current = PlayerPrefs.GetInt("level", 0);
            int i = 0;
            foreach (Button level in levels){
                if (i <= current){
                    level.interactable = true;
                }
                else{
                    level.interactable = false;
                }
                i++;
            }
        }

        public void play(int i)
        {
            SceneManager.LoadScene(i);
        }

        public void clickAll(){
            click++;
            if(click%7==0){
                unlockAll();
            }
            else if(click%13==0){
                lockAll();
            }
        }

        private void unlockAll(){
            PlayerPrefs.SetInt("level", 12);
            devText.Play("dev_text");
        }

        private void lockAll(){
            PlayerPrefs.SetInt("level", 0);
            userText.Play("user_text");
        }
        

}
