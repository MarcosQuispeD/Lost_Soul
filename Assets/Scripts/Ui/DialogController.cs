using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogController : MonoBehaviour
{
    bool isPlayerInrRange;
    bool dialogStart;
    bool isObjectDestroy;
    int lineIndex;
    [SerializeField,TextArea(4,6)] private string[] dialegLines;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogtext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isPlayerInrRange)
        {
            if (!dialogStart)
            {
                StartDialgo();
            }
        }

        if (dialogStart && dialogtext.text == dialegLines[lineIndex] && Input.GetKeyDown(KeyCode.Space))
        {
            NextDialog();
        }


    }

    private void StartDialgo()
    {
        dialogStart = true;
        dialogPanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    public void ClosePanel()
    {
        dialogStart = false;
        dialogPanel.SetActive(false);
    }

    void NextDialog()
    {
        lineIndex++;
        if (lineIndex < dialegLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogStart = false;
            dialogPanel.SetActive(false);
            if (isObjectDestroy)
            {
                PauseController.instance.isInPause = false;
                Time.timeScale = 1;
                Destroy(gameObject);
            }
           
        }
    }

    private IEnumerator ShowLine()
    {
        dialogtext.text = string.Empty;

        foreach(char caracter in dialegLines[lineIndex])
        {
            dialogtext.text += caracter;
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }

    private void CollisionDoor(Collider2D collision)
    {
        if (GameManagerController.instance.keys.Count == 0)
        {
            isObjectDestroy = false;
        }
        else if (GameManagerController.instance.keys.Count > 0 && GameManagerController.instance.OpenDoorForKey(gameObject.GetComponent<DoorsController>().idDoor))
        {
            isPlayerInrRange = false;
            isObjectDestroy = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInrRange = true;
            if (gameObject.CompareTag("DoorClose"))
            {
                CollisionDoor(collision);
            }

            if (gameObject.CompareTag("Tutorial"))
            {
                PauseController.instance.isInPause = true;
                Time.timeScale = 0;
                isObjectDestroy = true;
            }

            if (gameObject.CompareTag("CheckPoint"))
            {
                isObjectDestroy = true;
            }

            if (gameObject.CompareTag("Cofre"))
            {
                isObjectDestroy = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInrRange = false;
            if (gameObject.CompareTag("DoorClose"))
            {
                CollisionDoor(collision);
            }
        }

    }
}
