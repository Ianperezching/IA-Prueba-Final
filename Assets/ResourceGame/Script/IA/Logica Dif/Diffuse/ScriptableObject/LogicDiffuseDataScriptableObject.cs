 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicDiffuseDataScriptableObject : ScriptableObject
{
    //controla la velocidad del navmeshagent
    public FuzzySystem SpeedDependDistanceEnemy = new FuzzySystem();
    public FuzzySystem SpeedDependDistanceAllied = new FuzzySystem();
    public FuzzySystem SpeedDependDistancePosition = new FuzzySystem();

}

