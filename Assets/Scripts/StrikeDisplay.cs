using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeDisplay : MonoBehaviour
{
    [SerializeField] [Range(0,3)] int strikeActivation = 0;
    [SerializeField] private GameObject lcdBackground;
    [SerializeField] private GameObject skullDisplay;
    private SpriteRenderer lcdBgSprite;
    private SpriteRenderer skullSprite;

    public void Awake(){
        lcdBgSprite = lcdBackground?.GetComponent<SpriteRenderer>();
        skullSprite = skullDisplay?.GetComponent<SpriteRenderer>();
        skullDisplay.SetActive(false);
        
        GM.Instance.StrikeEvent += ActivateDisplay;
    }

    public void ActivateDisplay(int strike){
        if(strike == strikeActivation){
            // TODO: Play animation for activating the strike for the display!
            // Should try to apply a glitch effect to the BG & fade in the skull display?
            //  -OR fade out the additional BG to reveal the skull display!
            skullDisplay.SetActive(true);
        }
    }

    // TODO: Add reset function & Observer...?
}
