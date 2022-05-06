using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    bool isPlayerInrRange;
    bool dialogStart;
    bool isObjectDestroy;
    bool continueDialog = false;
    int lineIndex;
    [SerializeField, TextArea(4, 6)] private string[] dialegLines;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogtext;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInrRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogStart)
            {
                StartDialgo();
            }else if (dialogtext.text == dialegLines[lineIndex])
            {
                NextDialog();
            }
            else
            {
                StopAllCoroutines();
                dialogtext.text = dialegLines[lineIndex];
            }
        }


        if (Input.GetKeyDown(KeyCode.Y) && lineIndex == 2)
        {
            continueDialog = true;
            NextDialog();
        }
        if (Input.GetKeyDown(KeyCode.N) && lineIndex == 2)
        {
            lineIndex = 4;
            continueDialog = true;
            NextDialog();
        }


        FirstOption();
        SecondOption();

    }

    private void FirstOption()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && lineIndex == 5)
        {
            if (GameManagerController.instance.bounds>= 30f)
            {
                lineIndex = 5;
                LifeSystem.instance.AddLife();
                GameManagerController.instance.bounds = GameManagerController.instance.bounds - 30f;
                continueDialog = true;
                NextDialog();
            }
            else
            {
                lineIndex = 7;
                continueDialog = true;
                NextDialog();
            }
            
        }


    }
    private void SecondOption()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && lineIndex == 5)
        {
            if (GameManagerController.instance.bounds >= 20)
            {
                lineIndex = 5;
                PlayerMovement.instance.speed = 1.8f;
                GameManagerController.instance.bounds = GameManagerController.instance.bounds - 20f;
                continueDialog = true;
                NextDialog();
            }
            else
            {
                lineIndex = 7;
                continueDialog = true;
                NextDialog();
            }

          
        }
    }


    private void StartDialgo()
    {
        PauseController.instance.isInPause = true;
        Time.timeScale = 0;
        dialogStart = true;
        dialogPanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    void NextDialog()
    {
        if (lineIndex == 2 && !continueDialog)
        {
            return;
        }else if (lineIndex == 3)
        {
            lineIndex = 5;
            continueDialog = false;
        }
        else if (lineIndex == 4)
        {
            if (dialegLines[lineIndex] == dialogtext.text)
            {
                lineIndex = 10;
            }
        }else if (lineIndex == 5 && !continueDialog)
        {
            return;
        }else if (lineIndex == 7 && continueDialog)
        {
            if (dialegLines[lineIndex] == dialogtext.text)
            {
                lineIndex = 10;
            }
        }
        else
        {
            lineIndex++;
            if (lineIndex == 7)
            {
                lineIndex = 10;
            }
        }
       
        if (lineIndex < dialegLines.Length)
        {
            StartCoroutine(ShowLine());
           
        }
        else
        {
            dialogStart = false;
            dialogPanel.SetActive(false);
            PauseController.instance.isInPause = false;
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogtext.text = string.Empty;

        foreach (char caracter in dialegLines[lineIndex])
        {
            dialogtext.text += caracter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        if (lineIndex == 4)
        {
            dialogStart = false;
            dialogPanel.SetActive(false);
            PauseController.instance.isInPause = false;
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInrRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInrRange = false;
        }

    }
}
