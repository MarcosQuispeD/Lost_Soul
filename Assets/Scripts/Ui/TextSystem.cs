using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionText
{
    public int id;
    public string text;
}

public class TextSystem : MonoBehaviour
{
    public static TextSystem instance;
    public List<CollectionText> texts = new List<CollectionText>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        texts.Add(new CollectionText() { id = 0, text= "Encontraste una llave, busca una puerta del mismo color para utilizarla" });
        texts.Add(new CollectionText() { id = 1, text = "Cuidado te vas a quemar si pasas por aca, encuentra una forma de apagar el fuego" });
        texts.Add(new CollectionText() { id = 2, text = "Felicidades, encontraste un cofre de poder, usa el elemento del agua con sabiduria" });
        texts.Add(new CollectionText() { id = 3, text = "Esta puerta esta cerrada busca una llave del mismo color para abrirla" });
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ViewText(int id)
    {
        for (int i = 0; i < texts.Count; i++)
        {
            if (id == texts[i].id)
            {
                gameObject.GetComponent<Text>().text = texts[i].text;
            }
        }

        
    }
}


