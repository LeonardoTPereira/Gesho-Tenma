using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "BossData", menuName = "GeshouTenma/BossData", order = 0)]
public class BossData : ScriptableObject
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public GameObject BossPrefab { get; set; }
    [field: SerializeField] public Color ColorMask { get; set; }
}
