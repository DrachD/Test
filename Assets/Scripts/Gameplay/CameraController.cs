using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Cash
    private Camera _camera;
    #endregion

    #region Callback Methods
    private void Awake() => _camera = GetComponent<Camera>();

    private void Update() => InputHandler();
    #endregion

    private void InputHandler()
    {
        // Бросаем луч из диапазона камеры и обрабатывает данные, если луч попал по нужному объекту
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.transform.gameObject;

                if (obj.CompareTag("Figure"))
                {
                    GeometryObjectModel geometry = obj.GetComponent<GeometryObjectModel>();
                    geometry.ClickCount++;
                }
            }
        }
    }
}
