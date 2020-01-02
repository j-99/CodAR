using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunny_controller : MonoBehaviour
{
    private Vector3 target;
    private float speed = 5f;
    private float minSpeed = 2.5f;
    public bool alive = true;
    private Quaternion localAngle;

    void Start(){
        localAngle = this.transform.localRotation;
    }
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("target")){
            target = col.gameObject.GetComponent<Transform>().localPosition;
        }
        if(col.gameObject.CompareTag("Finish")){
            alive = false;
        }
    }

    public void move(){
        this.transform.localPosition = target;
    }

    public void rotate(float angle){
        if(angle < 0){
            angle = 360 + angle;
        }
        Debug.Log(this.transform.localEulerAngles.y);
         Quaternion ang = localAngle;
                Quaternion target = ang * Quaternion.Euler(0, angle + this.transform.localEulerAngles.y, 0);
                float amountRotated = 0;
                var diff = Mathf.Abs(angle);
                while (amountRotated <= diff*2)
                {
                    this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, target, speed);
                    amountRotated += speed; //the 3rd parameter is the degrees change, so we can keep track of the amount of rotation by adding it each time
                    speed = Mathf.Lerp(speed, minSpeed, .3f); //slowly reduce the speed, so the rotation has a more natural feel, slowing it down towards the end
                }
    }
}
