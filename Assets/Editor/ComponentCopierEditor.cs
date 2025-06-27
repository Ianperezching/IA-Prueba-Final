using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ComponentCopier))]
public class ComponentCopierEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ComponentCopier copier = (ComponentCopier)target;

        if (GUILayout.Button("Copiar Componentes"))
        {
            CopyComponents(copier.sourceObject, copier.targetObject);
        }

        if (GUILayout.Button("Instanciar Prefabs como hijos"))
        {
            foreach (var prefab in copier.prefabsToAdd)
            {
                if (prefab != null && copier.targetObject != null)
                {
                    GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                    instance.transform.SetParent(copier.targetObject.transform);
                    instance.transform.localPosition = Vector3.zero;
                }
            }
        }

        if (GUILayout.Button("Eliminar Componentes de B"))
        {
            DeleteComponents(copier.targetObject);
        }
    }

    void CopyComponents(GameObject source, GameObject target)
    {
        if (source == null || target == null)
        {
            Debug.LogWarning("Faltan objetos Source o Target");
            return;
        }

        var components = source.GetComponents<Component>();
        foreach (var comp in components)
        {
            if (comp is Transform) continue; // nunca copiar Transform

            UnityEditorInternal.ComponentUtility.CopyComponent(comp);
            UnityEditorInternal.ComponentUtility.PasteComponentAsNew(target);
        }
    }

    void DeleteComponents(GameObject target)
    {
        if (target == null)
        {
            Debug.LogWarning("Falta el objeto Target");
            return;
        }

        var components = target.GetComponents<Component>();
        foreach (var comp in components)
        {
            if (comp is Transform) continue; // nunca eliminar Transform
            DestroyImmediate(comp);
        }
    }
}
