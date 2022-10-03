using System;
using System.Collections.Generic;
using UnityEngine;

public enum TurretVersion
{
    TurretA
}

[Serializable]
public class TurretEntry
{
    [SerializeField] private TurretVersion turretVersion;
    [SerializeField] private GameObject turretPrefab;

    public TurretVersion TurretVersion { get => turretVersion; set => turretVersion = value; }
    public GameObject TurretPrefab { get => turretPrefab; set => turretPrefab = value; }
}

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<TurretEntry> turrets;
    private bool turretCanBePlaced;
    private TurretVersion turretToPlace;

    public bool TurretCanBePlaced { get => turretCanBePlaced; set => turretCanBePlaced = value; }
    public TurretVersion TurretToPlace { get => turretToPlace; set => turretToPlace = value; }


    void Update()
    {
        if(Input.touchCount > 0 )
        {
            if (turretCanBePlaced)
            {
                turretCanBePlaced = false;

                Vector3 newTurretWorldPosition = mainCamera.ScreenToWorldPoint(Input.touches[0].position);
                Vector3 newTurretPosition = new Vector3(newTurretWorldPosition.x, newTurretWorldPosition.y, 0);
                PlaceTurret(turretToPlace, newTurretPosition);
            }
        }
    }

    public void PlaceTurret(TurretVersion turretVersion, Vector3 position)
    {
        switch (turretVersion)
        {
            case TurretVersion.TurretA:
                Instantiate(GetTurret(TurretVersion.TurretA), position, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private GameObject GetTurret(TurretVersion turretVersion)
    {
        foreach (TurretEntry turretEntry in turrets)
        {
            if (turretEntry.TurretVersion == turretVersion)
            {
                return turretEntry.TurretPrefab;
            }
        }

        return null;
    }
}
