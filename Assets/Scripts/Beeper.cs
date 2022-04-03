using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AUDIO functionality:
// [] For BEEPER:
// - low time increases FREQUENCY of beeps
// - More Strikes increases the PITCH of beeps.

public class Beeper : MonoBehaviour
{
    [SerializeField] private AudioSource beep;
    [SerializeField] private float defaultPitch = 0;
    [SerializeField] private float lowPitch = 1;
    [SerializeField] private float mediumPitch = 2;
    [SerializeField] private float highPitch = 3;

    // TODO: Implement such that it plays at the specified frequency at the desired times!
    [SerializeField] private float frequency = 1f;

    public void Awake(){
        beep = gameObject.GetComponent<AudioSource>();
        GM.Instance.StrikeEvent += SetPitch;
    }
    
    public void SetPitch(int strikes){
        switch (strikes)
        {
            case Constants.NO_STRIKES:
                beep.pitch = defaultPitch;
                break;
            case Constants.FIRST_STRIKE:
                beep.pitch = lowPitch;
                break;
            case Constants.SECOND_STRIKE:
                beep.pitch = mediumPitch;
                break;
            case Constants.THIRD_STRIKE:
                beep.pitch = highPitch;
                break;
            default:
                Debug.LogError("Invalid strike value in SetPitch.");
                break;
        }
        
    }
}
