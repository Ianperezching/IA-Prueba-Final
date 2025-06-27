using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LogicDiffuseZombie: LogicDiffuse
{
    public LogicDiffuseDataScriptableObject logicDiffuseData;
     
    private void Start()
    {
        this.LoadScriptableObject();
    }

    public override void LoadScriptableObject()
    {
        if (logicDiffuseData != null)
        {
            // Usa los valores preconfigurados en el ScriptableObject
            // Usa los valores preconfigurados en el ScriptableObject
            SpeedDependDistanceEnemy = logicDiffuseData.SpeedDependDistanceEnemy;
            SpeedDependDistanceAllied = logicDiffuseData.SpeedDependDistanceAllied;
            SpeedDependDistancePosition = logicDiffuseData.SpeedDependDistancePosition;
        }
    }
}
