using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AUDIO functionality:
// [] For BEEPER:
// - low time increases FREQUENCY of beeps
// - More Strikes increases the PITCH of beeps.

public class Beeper : MonoBehaviour
{

    public void Awake(){
        GM.Instance.ThirdStrikeEvent += ThirdStrike;
        GM.Instance.ThirdStrikeEvent += ThirdStrike;
        GM.Instance.ThirdStrikeEvent += ThirdStrike;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
