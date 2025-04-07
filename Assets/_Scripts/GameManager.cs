using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture2D banIcon, punchIcon, endCallIcon, cutPowerIcon;
    public Sprite banSprite, punchSprite, endCallSprite, cutPowerSprite;

    //0 = ban, 1 = punch, 2 = end call, 3 = cut power
    int action = -1;

    // Quantities
    public static int banQty, punchQty, dcQty, cutPowerQty;
    public int banCount, punchCount, dcCount, cutPowerCount;
    public TextMeshProUGUI banCounter, punchCounter, dcCounter, cutPowerCounter;

    //Other stuff
    private bool buildMode = false;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Set qtys to whatever is set in inspector and update tmp's accordingly
        banQty = banCount;
        punchQty = punchCount;
        dcQty = dcCount;
        cutPowerQty = cutPowerCount;
        banCounter.text = $"{banQty}";
        punchCounter.text = $"{punchQty}";
        dcCounter.text = $"{dcQty}";
        cutPowerCounter.text = $"{cutPowerQty}";

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (buildMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = mainCamera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.CompareTag("User"))
                    {
                        GameObject clickedUser = hit.transform.gameObject;
                        User user = clickedUser.GetComponent<User>();
                        
                        //If no action, take user's action
                        if (action == -1)
                        {
                            if (user.currentAction == 0)
                            {
                                action = 0;
                                user.currentAction = -1;
                                banQty++;
                                banCounter.text = $"{banQty}";
                                Cursor.SetCursor(banIcon, Vector2.zero, CursorMode.Auto);
                                user.runCheck(user.currentAction);
                                user.action.sprite = null;
                            }
                            else if (user.currentAction == 1)
                            {
                                action = 1;
                                user.currentAction = -1;
                                punchQty++;
                                punchCounter.text = $"{punchQty}";
                                Cursor.SetCursor(punchIcon, Vector2.zero, CursorMode.Auto);
                                user.runCheck(user.currentAction);
                                user.action.sprite = null;
                            }
                        }

                        else if (action == 0 && user.currentAction != 0) 
                        {
                            if (user.currentAction == 1)
                            {
                                punchQty++;
                                punchCounter.text = $"{punchQty}";

                            }
                            user.action.sprite = banSprite;
                            user.currentAction = action;
                            banQty--;
                            banCounter.text = $"{banQty}";
                            user.runCheck(action);
                            if (banQty <= 0)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                action = -1;
                            }
                        }

                        else if (action == 1 && user.currentAction != 1)
                        {
                            if (user.currentAction == 0)
                            {
                                banQty++;
                                banCounter.text = $"{banQty}";
                            }
                            user.action.sprite = punchSprite;
                            user.currentAction = action;
                            punchQty--;
                            punchCounter.text = $"{punchQty}";
                            user.runCheck(action);
                            if (punchQty <= 0)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                action = -1;
                            }
                        }
                    } 
                    else if (hit.transform.CompareTag("Connection"))
                    {
                        GameObject clickedConnection = hit.transform.gameObject;
                        Connection connection = clickedConnection.GetComponent<Connection>();

                        //If no action, take connections's action
                        if (action == -1)
                        {
                            if (connection.currentAction == 2)
                            {
                                action = 2;
                                connection.currentAction = -1;
                                dcQty++;
                                dcCounter.text = $"{dcQty}";
                                Cursor.SetCursor(endCallIcon, Vector2.zero, CursorMode.Auto);
                                connection.runCheck(connection.currentAction);
                                connection.action.sprite = null;
                            }
                            else if (connection.currentAction == 3)
                            {
                                action = 3;
                                connection.currentAction = -1;
                                cutPowerQty++;
                                cutPowerCounter.text = $"{cutPowerQty}";
                                Cursor.SetCursor(cutPowerIcon, Vector2.zero, CursorMode.Auto);
                                connection.runCheck(connection.currentAction);
                                connection.action.sprite = null;
                            }
                        }

                        else if (action == 2 && connection.currentAction != 2)
                        {
                            if (connection.currentAction == 3)
                            {
                                cutPowerQty++;
                                cutPowerCounter.text = $"{cutPowerQty}";

                            }
                            connection.action.sprite = endCallSprite;
                            connection.currentAction = action;
                            dcQty--;
                            dcCounter.text = $"{dcQty}";
                            connection.runCheck(action);
                            if (dcQty <= 0)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                action = -1;
                            }
                        }

                        else if (action == 3 && connection.currentAction != 3)
                        {
                            if (connection.currentAction == 2)
                            {
                                dcQty++;
                                dcCounter.text = $"{dcQty}";

                            }
                            connection.action.sprite = cutPowerSprite;
                            connection.currentAction = action;
                            cutPowerQty--;
                            cutPowerCounter.text = $"{cutPowerQty}";
                            connection.runCheck(action);
                            if (cutPowerQty <= 0)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                action = -1;
                            }
                        }
                    }
                }
            }
        }
    }


    //Enter build mode and change cursor for button clicks
    public void banButton()
    {
        if (banQty > 0)
        {
            buildMode = true;
            action = 0;
            Cursor.SetCursor(banIcon, Vector2.zero, CursorMode.Auto);
        }
    }

    public void punchButton()
    {
        if (punchQty > 0)
        {
            buildMode = true;
            action = 1;
            Cursor.SetCursor(punchIcon, Vector2.zero, CursorMode.Auto);
        }
    }

    public void endCallButton()
    {
        if (dcQty > 0)
        {
            buildMode = true;
            action = 2;
            Cursor.SetCursor(endCallIcon, Vector2.zero, CursorMode.Auto);
        }
    }

    public void cutPowerButton()
    {
        if (cutPowerQty > 0)
        {
            buildMode = true;
            action = 3;
            Cursor.SetCursor(cutPowerIcon, Vector2.zero, CursorMode.Auto);
        }
    }
}
