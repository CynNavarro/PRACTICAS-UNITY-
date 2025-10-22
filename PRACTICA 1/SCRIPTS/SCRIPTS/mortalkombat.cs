using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortalkombat : Item
{
    public override void Recoger()
    {
        throw new System.NotImplementedException();
        Score.PuntajeActual += 10;
        Debug.Log
    }
}
