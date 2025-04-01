using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject PreviewPrefab;
    public int BumperQty = 3;
    public TextMeshProUGUI ButtonText;
    public Texture2D DefaultCursor;
    public Texture2D AddCursor;

    private Camera MainCamera;
    private bool BuildMode;
    private GameObject Preview;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        BuildMode = false;
        ButtonText.text = $"Add ({BumperQty})";
        Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
        Preview = GameObject.Instantiate(PreviewPrefab, Vector3.zero, Quaternion.identity);
        Preview.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = MainCamera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.CompareTag("Buildable"))
                    {
                        Vector3 point = hit.point;
                        point += Vector3.up * .25f;
                        Instantiate(Prefab, point, Quaternion.identity);
                        BumperQty--;
                        BuildMode = false;
                        ButtonText.text = $"Add ({BumperQty})";
                        Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
                        Preview.SetActive(false);
                    }
                }
            }
            else
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = MainCamera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.CompareTag("Buildable"))
                    {
                        Vector3 point = hit.point;
                        point += Vector3.up * .25f;
                        Preview.transform.position = point;
                        Preview.SetActive(true);
                    }
                    else
                    {
                        Preview.SetActive(false);
                    }
                }
            }
        }
    }

    public void TurnBuildModeOn()
    {
        if (BumperQty > 0)
        {
            BuildMode = true;
            Cursor.SetCursor(AddCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
