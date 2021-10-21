using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sealed classes are used to restrict the users from inheriting the class.
 * A class can be sealed by using the sealed keyword.
 * The keyword tells the compiler that the class is sealed, and therefore, cannot be extended. 
 * No class can be derived from a sealed class.
 */
public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> checkPoints = new List<GameObject>();

    public List<GameObject> CheckPoints
    {
        get
        {
            return checkPoints;
        }
    }

    public static GameEnvironment Singleton
    {
        get
        {
            if(instance == null)
            {
                instance = new GameEnvironment();
                instance.CheckPoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
            }
            return instance;
        }
    }
}
