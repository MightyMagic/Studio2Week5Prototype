using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    [SerializeField] GameObject canvas;
    [SerializeField] string m_Text;

    [SerializeField] List<GameObject> interactiveObjects;
    [SerializeField] bool isInteractive;

    bool inside;

    void Start()
    {
        if (canvas != null) { canvas.SetActive(false); }
        inside = false;

    }

    private void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject go in interactiveObjects)
            {
                if (go != null)
                    Destroy(go);
            }
            if(m_TextMeshPro != null)
                Destroy(m_TextMeshPro);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(canvas!= null)
        {
            canvas.SetActive(true);
            m_TextMeshPro.text = m_Text;
        }
        if(isInteractive)
        {
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canvas != null) { canvas.SetActive(false); }
        inside = false;
    }

}
