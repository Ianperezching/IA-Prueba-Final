using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LogicDiffusePaladin: LogicDiffuse
{
    public LogicDiffuseDataScriptablePaladin logicDiffuseData;
    //public FuzzySystem SpeedAnimationDependDistancePosition = new FuzzySystem();


    private void Start()
    {
        this.LoadScriptableObject();
    }

    public override void LoadScriptableObject()
    {
        if (logicDiffuseData != null)
        {
            // Usa los valores preconfigurados en el ScriptableObject
            SpeedDependDistanceEnemy = logicDiffuseData.SpeedDependDistanceEnemy;
            SpeedDependDistanceAllied = logicDiffuseData.SpeedDependDistanceAllied;
            SpeedDependDistancePosition = logicDiffuseData.SpeedDependDistancePosition;

            //SpeedAnimationDependDistancePosition = logicDiffuseData.SpeedAnimationDependDistancePosition;
            
        }
    }
}
