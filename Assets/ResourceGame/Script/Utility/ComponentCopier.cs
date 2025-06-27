using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ComponentCopier : MonoBehaviour
{
    public GameObject sourceObject;     // A
    public GameObject targetObject;     // B
    public List<GameObject> prefabsToAdd = new List<GameObject>();
}
