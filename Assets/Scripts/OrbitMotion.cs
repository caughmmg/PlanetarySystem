using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    /// <summary>
    /// The planet that is orbiting
    /// </summary>
    public Transform orbitingObject;
    /// <summary>
    /// what is being orbited around
    /// </summary>
    public Transform centerPoint;
    /// <summary>
    /// the Ellipse that the planet will transform around
    /// </summary>
    public Ellipse orbitPath;

    /// <summary>
    /// How far along in the orbit the planet is from 0 to complete
    /// </summary>
    [Range(0f,1f)]
    public float orbitProgress= 0;
    /// <summary>
    /// How long it takes to complete 1 orbit
    /// </summary>
    public float orbitPeriod = 3f;
    /// <summary>
    /// Controller for the orbit to be active or inactive (aka: paused)
    /// </summary>
    public bool orbitActive = true;

    void Start()
    {
        //if there is a null ref for the orbiting object it will deactivate that orbit
        if(orbitingObject == null)
        {
            orbitActive = false;
            return;
        }

        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());  
    
    }//End Start

    void SetOrbitingObjectPosition()
    {
        //Takes the angle of the Ellipse and translates it to orbit position
        Vector2 orbitPosition = orbitPath.Evaluate(orbitProgress);
       Vector3 pos = new Vector3(orbitPosition.x, 0, orbitPosition.y);
        orbitingObject.position = pos + centerPoint.position;
    }

    IEnumerator AnimateOrbit()
    {
        if(orbitPeriod < 1f)
        {
            orbitPeriod = 1f;
        }
        float orbitSpeed = 1f / orbitPeriod;
        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %=1f;
            SetOrbitingObjectPosition();
            yield return null;
        }

    }

}//End Class
