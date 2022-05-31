using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTheWiresMiniGame : MiniGame
{
    // [SerializeField] GameObject spawnPlane;
    [SerializeField] private RectTransform plane;
    [SerializeField] private int maxWires = 16;
    private float planeWidth;
    private float planeHeight;
    private HashSet<WirePoint> wirePoints; 
    // For now, we'll keep a static array of size 8x8 for spawning "wire nodes"
    private void Awake() {
        // TODO: Check if I need to account for scale!
        planeWidth = plane.rect.width;
        planeHeight = plane.rect.height;
        Debug.Log("Width: "+planeWidth);
    }

    protected override void Load(){
        // TODO: Implement
    }

    // BG is a circuit board.
    // The wire's "connection points" have a base that appears as a metal contact,
    // With a color in the middle. (Color is randomly generated)

    private void spawnWirePoints(){
        // TODO: To make this easy, I could just define the plane of coords to spawn on,
        // Then divide it up like a 2D array based on the # of WirePoints we want to spawn
        //      Which is determined by difficulty level (total accumulated time)
        // Then assign the end points to  random values on either side!
    }

    // TODO: Generate a pair of points for wires!
    // Will need to ensure the point isn't already included in the current 'wires point' set.

    private void definePointGrid(int wires){
        // Make the grid wires x wires in dimension.
        // The grid 'cells' will need to parent wires? This might get weird...
        // Try without a grid first, and just some rough rules about not putting them on top of each other!
    }

    // Each "Wire" should consist of 2 end points. 
    // Dosen't matter which one the player clicks first!
    // Click & Drag from one point to the other!
    //      - Should draw from that point to where the player is clicking until the correct
    //        one is matched, or cancels if nothing is selected.

    private void placeWirePoints(){
        // TODO: Place these as gameobjects!
        // TODO: Actually need to represent the wire points as paired game obejcts.
    }

    private void generateWirePoints(int amountOfWires){
        for (int i = 0; i < amountOfWires; i++){
            generateWirePointPair();
        }
    }

    private void generateWirePointPair(){
        // TODO: Store 2 wire points as a Pair object! ( IMPORTANT FOR GENERATION!!!)
        // TODO: Swap out random color generation w/ predetermined colors!
        Color color = new Color(
            Random.Range(0.3F,1F), 
            Random.Range(0.3F, 1F), 
            Random.Range(0.3F, 1F)
        );
        // Ensures 2 wire points are generated
        int added = 0;
        while(added < 2){
            // Very bad brute force solution, but I'm short on time and energy rn. [Written @ 5am]
            try
            {
                wirePoints.Add(generateWirePoint(color));
                added++;
            }
            catch (System.Exception ex)
            {
                 Debug.Log("Duplicate point caught. Regenerating...");
            }
        }
    }

    private WirePoint generateWirePoint(Color color){
        int x = Random.Range(0,8);
        int y = Random.Range(0,8);
        return new WirePoint(x, y, color);
    }

    protected override int GetCause(){
        return Constants.FAILED_CONNECT_THE_WIRES;
    }

    protected override void RaiseDifficulty(){
        // TODO: Implement
    }

    protected override void Complete(){
        // TODO: Implement
    }
}
