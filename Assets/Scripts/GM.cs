using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
    The GM Manages Game State, as well as handling any necessary data between scenes.
*/
public class GM : MonoBehaviour
{
    // Singleton Declaration
    private static GM _instance;
    public static GM Instance {get {return _instance;}}

    [SerializeField] private int strikes = 0;
    public delegate void StrikeEventHandler(int strikeCount);
    public event StrikeEventHandler StrikeEvent;

    // Mini-Game delegates & handlers, mostly for controlling interactions w/
    // Mini-Game area. 
    public delegate void PlayingMiniGameEventHandler();
    public event PlayingMiniGameEventHandler MiniGameReadyEvent;
    public delegate void FinishMiniGameEventHandler();
    public event FinishMiniGameEventHandler FinishMiniGameEvent;

    // PlayGameEvent refers to when the player has indicated they are ready to play
    // the game. Starts the count down timer.
    public delegate void PlayGameEventHandler();
    public event FinishMiniGameEventHandler PlayGameEvent;

    // Msg sent out when failure is achieved.
    public delegate void GameOverEventHandler(int cause);
    public event GameOverEventHandler GameOverEvent;

    private void Awake() {
        if(_instance != null && _instance != this){
            Debug.Log("Destroyed duplicate instance of GM");
            Destroy(this.gameObject);
        }else{
            _instance = this;
            Reset();
        }
    }

    // I want to trigger various behavioral changes based on game "state"...
    // So this should send out a "Message" right? As in a messaging system?
    // Essentially an "Event" to update the necessary processes to change behavior state!

    public void Strike(){
        strikes++;
        StrikeEvent?.Invoke(strikes);
    }

    public void miniGameReady(){
        MiniGameReadyEvent?.Invoke();
        Debug.Log("MiniGameReadyEvents");
    }

    public void Reset(){
        strikes = 0;
        StrikeEvent?.Invoke(strikes);
        // ResetEvent?.Invoke(this, EventArgs.Empty);
    }
}
