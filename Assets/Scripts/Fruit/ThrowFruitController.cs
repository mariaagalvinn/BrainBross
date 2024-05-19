using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruitController : MonoBehaviour
{
    public static ThrowFruitController instance;

    public GameObject CurrentFruit { get; set; }
    [SerializeField] private Transform _fruitTransform;
    [SerializeField] private Transform _parentAfterThrow;
    [SerializeField] private FruitSelector _selector;

    private SuikaPlayerController _playerController;

    private Rigidbody2D _rb;
    private PolygonCollider2D _polygonCollider;

    public Bounds Bounds { get; private set; }

    private const float EXTRA_WIDTH = 0.03f;

    public bool CanThrow { get; set; } = true;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _playerController = GetComponent<SuikaPlayerController>();

        SpawnAFruit(_selector.PickRandomFruitForThrow());
    }

    private void Update() 
    {
        if (CurrentFruit != null)
        {
            CurrentFruit.transform.position = _fruitTransform.TransformPoint(Vector3.zero);
        }
        if (UserInput.IsThrowPressed && CanThrow)
        {
            SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
            Quaternion rot = CurrentFruit.transform.rotation;

            GameObject go = Instantiate(FruitSelector.instance.Fruits[index.Index], CurrentFruit.transform.position, rot);
            go.transform.SetParent(_parentAfterThrow);

            Destroy(CurrentFruit);

            CanThrow = false;
        }
    }

    public void SpawnAFruit(GameObject fruit)
    {
        Vector3 globalPosition = _fruitTransform.TransformPoint(Vector3.zero);
        GameObject go = Instantiate(fruit, globalPosition, Quaternion.identity, _parentAfterThrow);

        CurrentFruit = go;
        _polygonCollider = CurrentFruit.GetComponent<PolygonCollider2D>();
        Bounds = _polygonCollider.bounds;

        _playerController.ChangeBoundary(EXTRA_WIDTH);
    }
}
