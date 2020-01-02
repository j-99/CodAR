using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_controller : MonoBehaviour
{
    private GameObject[] codeblocks;
    public GameObject[] carrots;
    public string[] commands;
    public int links = 0;
    public GameObject rabbit;
    public float angle = 0f;
    public Text carrot_text;
    public Text status_text;
    private bunny_controller bunny_bot;
    private GameObject[] connections;
    public GameObject endPanel;
    public GameObject retryButton;
    public GameObject nextButton;
    public Button play;
    private bool activate = true;
    public int for_times;
    void Start()
    {
        carrots = GameObject.FindGameObjectsWithTag("carrot");
        bunny_bot = rabbit.GetComponent<bunny_controller>();
        status_text.text = "";
        play.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        carrots = GameObject.FindGameObjectsWithTag("carrot");
        connections =  GameObject.FindGameObjectsWithTag("connection");
        if(carrots.Length == 0){
            status_text.text = "Great work !";
            PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
            nextButton.SetActive(true);
            endPanel.SetActive(true);
            Debug.Log("Win");
            StopAllCoroutines();
        }
        if(bunny_bot.alive == false){
            status_text.text = "Oh nooo";
            retryButton.SetActive(true);
            endPanel.SetActive(true);
            Debug.Log("Lose");
            StopAllCoroutines();
        }
        if(connections.Length == links && activate){
            // StartCoroutine("CalculateSequence");
            play.interactable = true;
        }
        else{
            play.interactable = false;
        }
        // if(Input.GetKeyDown(KeyCode.A)){
        //     bunny_bot.rotate(90f);
        // }
        // if(connections.Length < links && activate){
        //     calculate = true;
        //     play.interactable = false;
        // }
        carrot_text.text = "Carrots left : " + carrots.Length.ToString();
    }

    // public void flow(){
    //     codeblocks = GameObject.FindGameObjectsWithTag("code");
    //     commands = new string[codeblocks.Length];
    //     foreach ( GameObject code in codeblocks){
    //         if(code.activeSelf == true){
    //             int index = code.GetComponent<link_flow>().index;
    //             string command = code.GetComponent<link_flow>().command;
    //             commands[index] = command;
    //             Debug.Log(commands[index]);
    //         }
    //     }
    //     Debug.Log("locked");
    // }

    IEnumerator CalculateSequence(){
        codeblocks = GameObject.FindGameObjectsWithTag("code");
        commands = new string[codeblocks.Length];
        foreach (GameObject code in codeblocks){
            link_flow code_flow = code.GetComponent<link_flow>();
            if(code_flow.connector.activeSelf == false && code_flow.haveChild == true){
                code_flow.index = 0;
                string command = code.GetComponent<link_flow>().command;
                commands[0] = command;
                Debug.Log("FOUND ZERO");
            }
        }
        for (int i=0; i<codeblocks.Length; i++){
            foreach (GameObject code in codeblocks){
                link_flow code_flow = code.GetComponent<link_flow>();
                if(code_flow.index == 0){
                    continue;
                }
                else{
                    if(code_flow.codecube != null && code_flow.codecube.GetComponent<link_flow>().index == i){
                        string command = code.GetComponent<link_flow>().command;
                        commands[i+1] = command;
                        code_flow.index = i+1;
                    }
                }
            }
        }
        StartCoroutine("executeCode");
        yield return null;
    }

    public void playflow(){
        StartCoroutine("CalculateSequence");
        play.interactable = false;
        activate = false;
    }

    IEnumerator executeCode(){
        int i = 0;
        int count = for_times;
        while(i<commands.Length){
            string command = commands[i];

            if(command == "hop"){
                bunny_bot.move();
                Debug.Log("hopping");
            }

            if(command == "rcw"){
                angle = 90f;
                bunny_bot.rotate(angle);
                Debug.Log("rotating");
            }

            if(command == "racw"){
                angle = -90f;
                bunny_bot.rotate(angle);
                Debug.Log("rotating");
            }

            if(command == "for" && count > 0){
                i--;
                count--;
                Debug.Log("found for !!");
            }
            else{
                i++;
            }

            
            if(command == "while"){
                i=0;  
                count = for_times;       
            }
            
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }
}
