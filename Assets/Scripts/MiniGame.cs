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

    protected abstract void Load();
    // Should interact w/ some persisting value?
    // Need a way to translate the difficulty to gameplay features too...
    protected abstract void RaiseDifficulty(); 
    
    /// <summary>
    /// Marks the game as finished.
    /// Adds appropriate bonus to timer
    /// Triggers the shutter close animation
    /// Closes out/Clears the mini game
    /// </summary>
    protected abstract void Complete();

    /// <summary>
    /// Failure cause to report if the mini-game is failed for further processing.
    /// Should always store the value in Constants.cs & reference.
    /// </summary>
    /// <returns></returns>
    protected abstract int GetCause();
}
