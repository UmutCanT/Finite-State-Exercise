using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/* Sealed classes are used to restrict the users from inheriting the class.
 * A class can be sealed by using the sealed keyword.
 * The keyword tells the compiler that the class is sealed, and therefore, cannot be extended. 
 * No class can be derived from a sealed class.
 */
public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> checkPoints = new List<GameObject>();
    private GameObject safeZone;

    public List<GameObject> CheckPoints
    {
        get
        {
            return checkPoints;
        }
    }

    public GameObject SafeZone
    {
        get
        {
            return safeZone;
        }
    }

    public static GameEnvironment Singleton
    {
        get
        {
            if(instance == null)
            {
                instance = new GameEnvironment();
                instance.safeZone = GameObject.FindGameObjectWithTag("Safe");
                instance.CheckPoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
                instance.checkPoints = instance.checkPoints.OrderBy(waypoint => waypoint.name).ToList();
            }
            return instance;
        }
    }
}
