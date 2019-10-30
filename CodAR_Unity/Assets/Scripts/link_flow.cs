using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link_flow : MonoBehaviour
{
    public int index;
    public string command;
    public GameObject connector;
    public GameObject codecube;
    public bool haveChild = false;
    void Start()
    {
        index = 100;
        connector.SetActive(false);
        // GameObject zone = this.FindComponentInChildWithTag<MeshRenderer>("zone");
        // zone.enabled = false;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("zone")){
            codecube = col.gameObject.transform.parent.gameObject;
            codecube.GetComponent<link_flow>().haveChild = true;
            // index = codecube.GetComponent<link_flow>().index + 1;
            // col.gameObject.GetComponent<MeshRenderer>().enabled = true;
            connector.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.CompareTag("zone")){
            index = 100;
            codecube.GetComponent<link_flow>().haveChild = false;
            //col.gameObject.GetComponent<MeshRenderer>().enabled = false;
            connector.SetActive(false);
        }
    }
}
