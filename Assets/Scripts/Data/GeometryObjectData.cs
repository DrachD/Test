using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// содержит данные о геометрических объектах, типа сферы, кубы, капсулы
[CreateAssetMenu(fileName = "GeometryObjectData", menuName = "Data/GeometryObjectData")]
public class GeometryObjectData : ScriptableObject
{
    [SerializeField] List<ClickColorData> clicksData;

    // можно было воспользоваться foreach в GeometryObjectModel
    // но данный вариант мне показался более приятным
    public ClickColorData ClicksData(string objType)
    {
        return clicksData.Find((element) => element.ObjectType == objType);
    }
}
