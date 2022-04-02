using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    [SerializeField] float startTime = 60f;
    [SerializeField] TextMeshProUGUI timeDisplay;
    [SerializeField] private float maxTime = 5999.999f;
    [SerializeField] private bool bombTicking = false;
    private float remainingTime;

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
                timeDisplay.SetText(Util.formatTime(remainingTime));
                TriggerExplosion(Constants.OUT_OF_TIME);
            }else{
                timeDisplay.SetText(Util.formatTime(remainingTime));
                // TODO: Check threshold for beep timing & trash talking.
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
            timeDisplay.SetText(Util.formatTime(remainingTime));
            TriggerExplosion(Constants.TIME_OVERFLOW);
        }else{
            timeDisplay.SetText(Util.formatTime(remainingTime));
            // TODO: Trigger sound effect/animation bit to indicate successfully added time!
        }
    }

    public void TriggerExplosion(int cause){
        // Stops timer
        bombTicking = false;
        // Triggers pre-explosion sfx & trash talk [Uses cause]
        // Explosion Animation
        // Game over Screen + score submission
    }
}
