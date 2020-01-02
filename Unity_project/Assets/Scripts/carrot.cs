using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrot : MonoBehaviour
{
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("collector")){
            Destroy(this.gameObject);
        }
    }
}
