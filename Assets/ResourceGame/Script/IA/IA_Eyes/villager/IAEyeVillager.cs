using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeVillager : IAEyeAttack
{
    void Start()
    {
        LoadComponent();
    }

    void Update()
    {
        UpdateScan();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }


    public override void UpdateScan()
    {
        base.UpdateScan();

    }

    private void OnValidate()
    {
        mainDataView.CreateMesh();
        AttackDataView.CreateMesh();

    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        AttackDataView.OnDrawGizmos();
    }

}
