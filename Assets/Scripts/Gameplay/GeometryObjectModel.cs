using System;
using UniRx;
using UnityEngine;
using System.Collections;

public class GeometryObjectModel : MonoBehaviour
{
    [SerializeField] private int _clickCount;
    public int ClickCount 
    {
        get => _clickCount;
        set
        {
            _clickCount = value;
            
            // Меняем цвет, если кол-во кликов находится в диапазоне
            if (_clickColorData.MinClicksCount <= _clickCount &&
                _clickColorData.MaxClicksCount >= _clickCount)
            {
                FigureColor = _clickColorData.Color;
            }
        }
    }

    [SerializeField] private Color _figureColor;
    public Color FigureColor 
    {
        get => _figureColor;
        set
        {
            _figureColor = value;
            _render.material.color = _figureColor;
        }
    }

    #region Cash
    protected string _objectType;

    protected GeometryObjectData _geometryObjData;

    private ClickColorData _clickColorData;

    protected GameData _gameData;

    private Renderer _render;
    #endregion

    private IDisposable _update;

    #region Callback Methods
    protected virtual void Awake()
    {
        // Загружаем все необходимые ScriptableObjects из папки ресурсов
        _geometryObjData = Resources.Load("GameData/GeometryObjectData") as GeometryObjectData;
        _gameData = Resources.Load("GameData/GameData") as GameData;

        _render = GetComponent<Renderer>();

        // Достаем данные для объекта, в зависимости от типа объекта, который в данный момент времени испльзуется
        // данный куба, сферы или капсулы
        _clickColorData = _geometryObjData.ClicksData(_objectType);
    }

    //---------------------------------------------------------//
    // Возможно стоило бы воспользоваться OnEnable и OnDisable
    // для того, чтобы в случае отключения объекта останавливать корутину
    // и включать в случае включения объекта
    // Думаю это зависит от специфики работы какого-то объекта, в данном случае этого
    // Был бы рад услышать ваше мнение 
    //---------------------------------------------------------//
    protected virtual void Start()
    {
        // Аналогия корутины, обновляем цвет через n времени
        _update = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(_gameData.ObservableTime)).Subscribe(_ => 
        {
            FigureColor = new Color(UnityEngine.Random.value, 
                                        UnityEngine.Random.value, 
                                        UnityEngine.Random.value);
        });
    }

    private void OnDestroy()
    {
        _update.Dispose();
    }
    #endregion
}
