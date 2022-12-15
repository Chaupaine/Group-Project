using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public static GameControl control;
    public int previousScore;
  

    void Awake()
    {
        //if there's a control already, delete this
        //if there's no control make this the control object
        if (control == null)
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

    }
}
