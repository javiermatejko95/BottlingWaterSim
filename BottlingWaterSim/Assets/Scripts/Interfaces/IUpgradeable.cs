using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeable
{
    void ApplyUpgrade();
    ObjectData GetObjectData();
}