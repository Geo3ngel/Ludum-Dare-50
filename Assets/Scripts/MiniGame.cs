using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGame : MonoBehaviour
{
    /// <summary>
    /// Acts as the basis for all MiniGames!
    /// Extent to easily be able to slot them in!
    /// </summary>
    
    // Generate

    /// <summary>
    /// Failure cause to report if the mini-game is failed for further processing.
    /// Should always store the value in Constants.cs & reference.
    /// </summary>
    /// <returns></returns>
    protected abstract int GetCause();
}
