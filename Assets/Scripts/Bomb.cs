using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Bomb : MonoBehaviour
{

    // Singleton Declaration
    private static Bomb _instance;
    public static Bomb Instance {get {return _instance;}}

    private void Awake() {
        if(_instance != null && _instance != this){
            Debug.Log("Destroyed duplicate instance of Bomb");
            Destroy(this.gameObject);
        }else{
            _instance = this;
            // Set as subscriber to Strike Event
            GM.Instance.StrikeEvent += Strike;
            GM.Instance.PlayGameEvent += BeginCountdown;
            GM.Instance.GameOverEvent += TriggerExplosion;
        }
        ResetTimer();
    }

    [SerializeField] float startTime = 60f;
    [SerializeField] TextMeshProUGUI timeDisplay;
    [SerializeField] private float maxTime = 5999.999f;
    [SerializeField] private bool bombTicking = false;
    private float remainingTime;

    public void BeginCountdown(){
        bombTicking = true;
    }

    // Update is called once per frame
    void FixedUpdate()
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

    public void Strike(int strike){
        if(strike == 3){
            // TODO: Prime bomb for detonation...
            // Might set a flag & send out another message, so once all required messages are received,
            // The Explosion is triggered. (To ensure other animations/dialog is completed.)
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
