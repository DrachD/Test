using System.IO;
using UnityEngine;

public class Figure
{
    public string objectType;
    public string name;
}

public class JsonSystem : MonoBehaviour
{
    private Figure[] figureInstance;

    private string path;

    private void Awake()
    {
        path = Path.Combine(Application.dataPath, "SaveFigureData.json");

        if (File.Exists(path))
        {
            figureInstance = JsonHelper.FromJson<Figure>(File.ReadAllText(path));
        }
        else
        {
            SetDefaultData();
        }
    }

    private void SetDefaultData()
    {
        figureInstance = new Figure[3];

        figureInstance[0] = new Figure();
        figureInstance[0].objectType = "Cube";
        figureInstance[0].name = "CubeName";

        figureInstance[1] = new Figure();
        figureInstance[1].objectType = "Sphere";
        figureInstance[1].name = "SphereName";

        figureInstance[2] = new Figure();
        figureInstance[2].objectType = "Capsule";
        figureInstance[2].name = "CapsuleName";

        JsonHelper.ToJson<Figure>(figureInstance);
    }

    public Figure GetFigure(string objectType)
    {
        if (figureInstance == null)
        {
            Debug.Log("figureInstance is Empty");
        }

        foreach (Figure figure in figureInstance)
        {
            if (figure.objectType == objectType)
            {
                return figure;
            }
        }
        return figureInstance[0];
    }
}
