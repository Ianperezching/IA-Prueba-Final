using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FuzzyRule
{
    public string Condition; // Ejemplo: "Si X es BAJO entonces Y es ALTO"
    public float Weight; // Peso de la regla
}

[System.Serializable]
public class FuzzyFunction
{
    public string Name; // Nombre de la función de membresía (Ej: "BAJO", "MEDIO", "ALTO")
    public AnimationCurve FunctionCurve; // Curva de membresía
    public FuzzyRule AssociatedRule; // Regla asociada a la función
    public float SingletonDistance; // Valor asociado a la función en la desfusificación

    public float Evaluate(float x)
    {
        return Mathf.Clamp01(FunctionCurve.Evaluate(x)); // Evalúa el grado de pertenencia
    }

    public float GetMaxValue()
    {
        return FunctionCurve.keys.Length > 0 ? FunctionCurve.keys[FunctionCurve.length - 1].value : 0;
    }
}

public static class FuzzyOperators
{
    public static float FuzzyAND(float a, float b) => Mathf.Min(a, b);
    public static float FuzzyOR(float a, float b) => Mathf.Max(a, b);
    public static float FuzzyNOT(float a) => 1.0f - a;
}

[System.Serializable]
public class FuzzySystem
{
    public List<FuzzyFunction> MembershipFunctions = new List<FuzzyFunction>(); // Lista de funciones de membresía
    public float Promedio;

    public float CalculateFuzzy(float inputValue, float secondaryInput = 1.0f)
    {
        float SumaW = 0;
        float MultW = 0;
        string appliedRules = ""; // Para almacenar las reglas aplicadas

        foreach (var fuzzyFunction in MembershipFunctions)
        {
            float membershipValue = fuzzyFunction.Evaluate(inputValue); // Evalúa la entrada en la función de membresía

            // Solo consideramos las funciones de membresía con un valor mayor a 0 y con una regla asociada
            if (membershipValue > 0 && fuzzyFunction.AssociatedRule != null)
            {
                float ruleWeight = fuzzyFunction.AssociatedRule.Weight; // Peso de la regla
                float weightedValue = membershipValue * fuzzyFunction.SingletonDistance * ruleWeight; // Ponderación

                // Suma y multiplicación ponderada
                SumaW += membershipValue * ruleWeight;
                MultW += weightedValue;

                // Agregar la regla aplicada (si lo deseas mostrar)
                appliedRules += $"{fuzzyFunction.AssociatedRule.Condition} con peso {ruleWeight}\n";
            }
        }

        Promedio = (SumaW != 0) ? MultW / SumaW : MultW;

        // Mostrar las reglas aplicadas en la consola (para depuración o visualización)
        //if (!string.IsNullOrEmpty(appliedRules))
        //{
        //    Debug.Log($"Reglas aplicadas:\n{appliedRules}");
        //}

        // Aplicamos desfusificación: Promedio ponderado
        return (SumaW != 0) ? MultW / SumaW : MultW;
    }

    public float MaxValue()
    {
        float maxValue = 0;
        foreach (var function in MembershipFunctions)
        {
            maxValue = Mathf.Max(maxValue, function.GetMaxValue());
        }
        return maxValue;
    }
}

public class LogicDiffuse: MonoBehaviour
{
    public FuzzySystem SpeedDependDistanceEnemy = new FuzzySystem();
    public FuzzySystem SpeedDependDistanceAllied = new FuzzySystem();
    public FuzzySystem SpeedDependDistancePosition = new FuzzySystem();

      

    public virtual void LoadScriptableObject()
    {
        //if (logicDiffuseData != null)
        //{
        //    // Usa los valores preconfigurados en el ScriptableObject
        //    SpeedDependDistanceEnemy = logicDiffuseData.SpeedDependDistanceEnemy;
        //    SpeedDependDistanceAllied = logicDiffuseData.SpeedDependDistanceAllied;
        //    SpeedDependDistancePosition = logicDiffuseData.SpeedDependDistancePosition;
             
        //}
    }
}
