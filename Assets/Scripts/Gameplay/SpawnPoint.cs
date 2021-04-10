using UnityEngine;

// точкой создания фигурных объектов является наша камера всего диапазона
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GeometryObjectModel[] figuresPrefab;
    
    private void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Vector3 pos = ray.origin + ray.direction * 10.0f;
        int range = Random.Range(0, figuresPrefab.Length);
        GameObject obj = figuresPrefab[range].gameObject as GameObject;

        Instantiate(obj, pos, Quaternion.identity);
    }
}