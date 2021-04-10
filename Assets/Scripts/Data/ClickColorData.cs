using UnityEngine;

[CreateAssetMenu(fileName = "ClickColorData", menuName = "Data/ClickColorData")]
public class ClickColorData : ScriptableObject
{    
    public string ObjectType => _objectType; // тип создаваемого объекта (куб, сфера, капсула)
    public int MinClicksCount => _minClicksCount;
    public int MaxClicksCount => _maxClickCount;
    public Color Color => _color;

    [SerializeField] private string _objectType;
    [SerializeField] private int _minClicksCount;
    [SerializeField] private int _maxClickCount;
    [SerializeField] private Color _color;
}
