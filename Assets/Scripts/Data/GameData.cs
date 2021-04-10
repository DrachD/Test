using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// баланс самой игры
[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    public int ObservableTime => _observableTime;
    
    [SerializeField] private int _observableTime;
}