using UnityEngine;

public class IAEyeVillagerVisor : IAEyeVillager
{
    private void Start()
    {
        LoadComponent();
    }

    private void Update()
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
