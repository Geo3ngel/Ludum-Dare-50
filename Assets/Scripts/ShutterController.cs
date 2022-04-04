using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterController : MonoBehaviour
{
    /// <summary>
    /// Shutter controller should be an easy to reference/reactive component
    /// For opening & closing the shutters when deemed necessary!
    /// - I.E:
    ///     Observes when a mini-game is done being played. [SHUTS_DOORS]
    ///     Observes when a mini-game is ready to be played. [OPENS_DOORS]
    /// 
    /// Will be using animations for the door opening/closing.
    /// - Ideally would like some SFX for opening. Like maybe a piston/compression SFX.
    /// </summary>

    private void Awake() {
        GM.Instance.MiniGameReadyEvent += OpenShutter;
        GM.Instance.FinishMiniGameEvent += CloseShutter;
    }

    private void OnDestroy() {
        GM.Instance.MiniGameReadyEvent -= OpenShutter;
        GM.Instance.FinishMiniGameEvent -= CloseShutter;
    }

    public void OpenShutter(){
        // TODO: Call open animation
    }

    public void CloseShutter(){
        // TODO: Call close animation
    }
}
