using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleObjectModel : GeometryObjectModel
{
    protected override void Awake()
    {
        _objectType = "Capsule";

        base.Awake();
    }

    protected override void Start()
    {
        // Задаем имя для нашего объекта полученное из Json
        gameObject.name = FindObjectOfType<JsonSystem>().GetFigure(_objectType).name;

        base.Start();
    }
}
