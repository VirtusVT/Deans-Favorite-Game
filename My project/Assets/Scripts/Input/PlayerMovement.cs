using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private float movementSpeed;

    private InputManager inputManager;
    private Vector3 destination;
    private Camera cam;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        cam = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += Touch;
        inputManager.MClick += MouseClick; 
    }

    private void OnDisable()
    {
        inputManager.OnEndTouch -= Touch;
        inputManager.MClick -= MouseClick;
    }

    private void Start()
    {
        destination = transform.position;
    }

    private void Touch(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cam.nearClipPlane);
        Vector3 worldCoordinates = cam.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0;
        Vector3Int gridPosition = map.WorldToCell(worldCoordinates);
        if (map.HasTile(gridPosition)) destination = worldCoordinates;
    }
    
    private void MouseClick(Vector2 mousePosition)
    {
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition)) destination = mousePosition;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f)
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
    }
}
