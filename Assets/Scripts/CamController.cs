using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public Transform player1, player2;
    public float minSizeY = 5f;
    public float maxSizeY = 15f;

    void SetCameraPos()
    {
        Vector3 middle = (player1.position + player2.position) * 0.5f;

        GetComponent<Camera>().transform.position = new Vector3( middle.x, middle.y - .5f * middle.y, GetComponent<Camera>().transform.position.z);
    }

    void SetCameraSize()
    {
        //horizontal size is based on actual screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;


        //multiplying by 0.5, because the ortographicSize is actually half the height
        float width = Mathf.Abs(player1.position.x - player2.position.x) * 0.5f;
        float height = Mathf.Abs(player1.position.y - player2.position.y) * 0.5f;

        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX);
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(Mathf.Max(height, camSizeX * Screen.height / Screen.width, minSizeY), minSizeY, maxSizeY) * 1.1f;
    }

    void Update()
    {
        SetCameraPos();
        SetCameraSize();
    }

    public float GetMaxCamSize()
    {
        return GetComponent<Camera>().orthographicSize;
    }

   
}
