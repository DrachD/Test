using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObjectModel : GeometryObjectModel
{
    protected override void Awake()
    {
        _objectType = "Cube";

        base.Awake();
    }

    protected override void Start()
    {
        // Задаем имя для нашего объекта полученное из Json
        gameObject.name = FindObjectOfType<JsonSystem>().GetFigure(_objectType).name;

        base.Start();
    }
}
