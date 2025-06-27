 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LogicDiffuseDataScriptableVillager", menuName = "FuzzyLogic/LogicDiffuseDataScriptableVillager")]
public class LogicDiffuseDataScriptableVillager : LogicDiffuseDataScriptableObject
{
    //controla la velocidad de parametro (Forward )en el animator control
    //public FuzzySystem SpeedAnimationDependDistanceAllied = new FuzzySystem();
    //public FuzzySystem SpeedAnimationDependDistancePosition = new FuzzySystem();

    //controla la velocidad del navmeshagent para evadir
    public FuzzySystem EvadeSpeedDistanceEnemy = new FuzzySystem();
}

