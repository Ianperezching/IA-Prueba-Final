using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LogicDiffuseVillager : LogicDiffuse
{
    public LogicDiffuseDataScriptableVillager logicDiffuseData;

    public FuzzySystem EvadeSpeedDistanceEnemy = new FuzzySystem();

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

            EvadeSpeedDistanceEnemy = logicDiffuseData.EvadeSpeedDistanceEnemy;
        }
    }
}
