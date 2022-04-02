using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLED : MonoBehaviour
{
    [SerializeField] Sprite off;
    [SerializeField] Sprite on;
    private SpriteRenderer spriteRenderer;
    private float blinkTime = 0;
    [SerializeField] private float blinkDurationRangeMin = 0;
    [SerializeField] private float blinkDurationRangeMax = 3;
    private bool isOn;

    // Used to denote external usage (disables default configured blinking behavior)
    private bool controlled = false; 

    void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        isOn = false;
    }

    private void FixedUpdate() {
        if(!controlled){
            // Blink for random durations
            blinkTime -= Time.deltaTime;
            if (blinkTime < 0){
                toggleLED();
                generateBlinkTime();
            }
        }
    }

    public void toggleLED(){
        isOn = !isOn;
        if(isOn){
            spriteRenderer.sprite = on;
        }else{
            spriteRenderer.sprite = off;
        }
    }

    // TODO: Add more variation to this, like burst patterns, shorter time weights for on states vs on, etc.
    // The idea being to better simulate some kind of 'usage'
    public void generateBlinkTime(){
        blinkTime = Random.Range(blinkDurationRangeMin, blinkDurationRangeMax);
    }
}
