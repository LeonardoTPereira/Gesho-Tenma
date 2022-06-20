using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ScenarioData", menuName = "GeshouTenma/ScenarioData", order = 0)]
public class ScenarioData : ScriptableObject
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public Sprite Scenario { get; set; }
}
