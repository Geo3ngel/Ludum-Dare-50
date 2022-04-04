using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject gear;
    [SerializeField] GameObject lens;
    [SerializeField] GameObject glare;
    [SerializeField] float rotationMin = -180f;
    [SerializeField] float rotationMax = 180f;
    [SerializeField] float speedMin = .1f;
    [SerializeField] float speedMax = 5f;
    [SerializeField] private float delayDurationMin = 0f;
    [SerializeField] private float delayDurationMax = 10f;
    private const int LEFT = -1;
    private const int RIGHT = 1;
    private const int NONE = 0;
    private bool controlled;
    private bool rotating;
    private int direction;
    [SerializeField] private float speed = 1f;
    private float delayTime;

    private SpriteRenderer lensGlare;
    // Start is called before the first frame update
    private void Awake() {
        lensGlare = glare.GetComponent<SpriteRenderer>();
        controlled = false;
        rotating = false;
        delayTime = 0f;
        direction = 0;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        // Randomly turn the gear now & then when it isn't being controlled by another process
        if(!controlled){
            doRandomRotation();
        }
    }

    private void doRandomRotation(){
        // Determine random degree to turn gear to, w/ cool down.
        // Determine if already rotating
        if (rotating){
            // TODO: Add controls for target degree!
            turnGear(direction*speed*Time.deltaTime);
        }else{
            if(delayTime == 0){
                // Generate rotation target!
                float rotationTarget = Random.Range(rotationMin, rotationMax);
                speed = Random.Range(speedMin, speedMax);
                // Calc direction to rotate
                float zRot = gear.transform.rotation.z;
                if(rotationTarget != zRot){
                    if(zRot > rotationTarget){
                        direction = LEFT;
                    }else{
                        direction = RIGHT;
                    }
                }
                // Set delay after rotation completes before activating next rotation
                delayTime = Random.Range(delayDurationMin, delayDurationMax);
                rotating = true;
            }else{
                delayTime -= Time.deltaTime;
            }
        }
    }

    private void turnGearTo(float targetDegrees){
        
    }

    private void turnGear(float degrees){
        // Make Lens smaller/larger in proportion to gear rotation!
            // Decrease the glare's opacity when the lens is made larger
        // Lens MAX scale value should be 1.5, MIN should be .5
        // 90 degrees = .25 scale?
        float newZ = gear.transform.rotation.z + degrees;
        if(newZ >= rotationMin && newZ <= rotationMax){
            Quaternion newRot = gear.transform.rotation;
            newRot.z = newZ;
            gear.transform.localRotation = newRot;
        }else{
            Quaternion newRot = gear.transform.rotation;
            if(newZ >= rotationMin){
                newRot.z = rotationMax;
            }else{
                newRot.z = rotationMin;
            }
            gear.transform.localRotation = newRot;
            // Signals to stop rotating in this direction
            rotating = false;
        }
    }

    public void takeControl(){
        controlled = true;
    }

    public void releaseControl(){
        controlled = false;
    }
}
