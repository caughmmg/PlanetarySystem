using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour
{
    LineRenderer lr;
    OrbitMotion om;

    [Range(3, 36)]
    public int segments;
    public Ellipse ellipse;



    void Awake()
    {
        //This is the Render of the actual Ellipse that will show the orbiting path
        lr = GetComponent<LineRenderer>();
        om = GetComponent<OrbitMotion>();

        ellipse.xAxis = om.orbitPath.xAxis;
        ellipse.yAxis = om.orbitPath.yAxis;

        CalculateEllipse();
    
    }//End Awake



    /// <summary>
    /// Calculates an ellipse with the xAxis sin and yAxis cos
    /// </summary>
    void CalculateEllipse()
    {

        

        //Array of points the ellipse will have, the more segments the rounder the ellipse
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            //Gets our positions for the Ellipse by Calculating for t from the Ellipse classes Evaluate function
            Vector2 position2D = ellipse.Evaluate(((float)i / (float)segments));

            //creates a new point on the array wit the x and y value of the new angle
            points[i] = new Vector3(position2D.x, 0f, position2D.y);
        }
        //the last point of Segments array will be same same as the first point
        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }//End CalculateEllipse
}//End Class
