using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float startTime = 60f;
    [SerializeField] string display = ""; // Change to text field for setting time!
    private float remainingTime;
    [SerializeField] private float maxTime = 5999.999f;
    private bool bombTicking = false;
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    public void BeginCountdown(){
        bombTicking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bombTicking){
            remainingTime -= Time.deltaTime;
            if(remainingTime <= 0f){
                remainingTime = 0f;
                // TODO: Set Text
                TriggerExplosion(Constants.OUT_OF_TIME);
            }else{
                // TODO: Set Text
            }
        }
        // TODO: Add logic for quickening beeps! (ups pitch of SFX & frequency!)
    }

    void ResetTimer(){
        remainingTime = startTime;
    }

    public void addTime(float time){
        remainingTime += time;
        if(remainingTime > maxTime){
            remainingTime = maxTime;
            TriggerExplosion(Constants.TIME_OVERFLOW);
        }
    }

    public void TriggerExplosion(int cause){ // Consider passing in cause for trash talk processing? [USE CONSTANTS]
        // Stops timer
        bombTicking = false;
        // Triggers pre-explosion sfx & trash talk
        // Explosion Animation
        // Game over Screen + score submission
    }
}
