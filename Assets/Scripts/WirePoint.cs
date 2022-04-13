using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePoint
{
    // WirePoints should ALWAYS be generated in pairs!

    // Just meant to hold the (x, y) grid location of a wirepoint, it's color
    private int x;
    private int y;
    private Color color;

    public WirePoint(int x, int y, Color color){
        this.x = x;
        this.y = y;
        this.color = color;
    }
}
