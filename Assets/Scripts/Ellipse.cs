using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse 
{


    public float xAxis;
    public float yAxis;

    public Ellipse(float xAxis, float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }

    /// <summary>
    /// Caclulates the Ellipse by taking the sin and cos of the angle and converting it to radians, and returning x and y
    /// </summary>
    /// <param name="t">the x and y values of the ellipse</param>
    /// <returns></returns>
    public Vector2 Evaluate (float t)
    {
        //This is converting the math from degrees to radians to create our ellipse
        float angle = Mathf.Deg2Rad * 360f * t;
        //Sin of the angle multiplied by xAxis
        float x = Mathf.Sin(angle) * xAxis;
        //Cos of the angle multiplied by the yAxis
        float y = Mathf.Cos(angle) * yAxis;
        //new Vectors for the Ellipse
        return new Vector2(x, y);
    }

}
