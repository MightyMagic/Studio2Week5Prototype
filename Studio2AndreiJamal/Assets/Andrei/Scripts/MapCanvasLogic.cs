using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapCanvasLogic : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject floor;
    [SerializeField] Image playerDot;
    [SerializeField] Image mapImage;

    [SerializeField] GameObject crossHairCanvas;
    [SerializeField] GameObject mapCanvas;
    [SerializeField] GameObject hpCanvas;

    [SerializeField] float leftXCoord;
    [SerializeField] float bottomZCoord;

    bool mapOpened;
    bool crossHairWasClosed;
    // Start is called before the first frame update
    void Start()
    {
        mapOpened = false;
        DisableAllCanvases();
        hpCanvas.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !mapOpened)
        {
           mapOpened = ! mapOpened;
           OpenMap();
        }
        else if(Input.GetKeyDown(KeyCode.M) && mapOpened)
        {
            mapOpened = !mapOpened;
            CloseMap();
        }

        if(Input.GetKeyDown(KeyCode.Escape) && mapOpened)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void OpenMap()
    {
        if(crossHairCanvas.activeInHierarchy)
        {
            crossHairCanvas.SetActive(false);
            crossHairWasClosed = true;
        }
        DisableAllCanvases();
        mapCanvas.SetActive(true);
        

        float xFactor, yFactor;
        //xFactor = (player.transform.position.x - leftXCoord) / (floor.transform.localScale.x);
        //yFactor = (player.transform.position.y - bottomZCoord) / 70f;

        xFactor = (player.transform.position.x - 0) / ((floor.transform.localScale.x) / 2);
        yFactor = (player.transform.position.z - 0) / (90 / 2);


        //    playerDot.rectTransform.anchorMin = new Vector2(xFactor, 0f);
        //    playerDot.rectTransform.anchorMax = new Vector2(xFactor, 1f);
        //
        //   playerDot.rectTransform.pivot = new Vector2(0.5f, yFactor);

        print("Proportions are: " + xFactor+ ", " + yFactor + ")");
        RectTransform mapRect = mapImage.GetComponent<RectTransform>();

        print("Map is : " + mapRect.rect.width + " x " + mapRect.rect.height);

        Vector2 anchoredPosition = new Vector2(xFactor * 630f, yFactor * 400f);

        playerDot.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;

        Time.timeScale = 0;
    }

    void CloseMap()
    {
        if(crossHairWasClosed)
        {
            crossHairCanvas.SetActive(true);
            crossHairWasClosed = false;
        }
        
        mapCanvas.SetActive(false);
        hpCanvas.SetActive(true);
        Time.timeScale = 1;
    }

    void DisableAllCanvases()
    {
        crossHairCanvas.SetActive(false);
        mapCanvas.SetActive(false);
        hpCanvas.SetActive(false);
    }
}
