using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class InkTestingScript : MonoBehaviour
{

    public TextAsset inkJSON;
    private Story story;

    public Text textPrefab;
    public Button buttonPrefab;

    void Start()
    {
        story = new Story(inkJSON.text);

        refreshUI();

    }

    void refreshUI()
    {
        eraseUI();

        Text storyText = Instantiate(textPrefab) as Text;

        string text = loadStoryChunk();

        List<string> tags = story.currentTags;  // a ideia é usar o index desse tags[] pra determinar qual animação de fala aparece. Pra funcionar direito, TODO diálogo precisa começar pelo player (aí o index dele fica sempre sendo o 0)

        
        storyText.text = text;
        storyText.transform.SetParent(this.transform, false);  //aqui tem que mudar pra em vez de this.transform, colocar o canvas (ou panel dentro do canvas) como parent

        for (int i = 0; i < tags.Count; i++)
        {
            //se tags.(string que tá nesse index) for igual a PLAYER, display nome/cara do player; se não, display cara/nome do npc
            if (tags[i].Contains("PLAYER"))
            {
            Debug.Log("apareceu o player");
            }
            else
            {
            Debug.Log("não deu certo, mas aqui tem npc");
            }

        }

           
        
        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(this.transform, false); //aqui tem que mudar pra em vez de this.transform, colocar o canvas (ou panel dentro do canvas) como parent

            choiceButton.onClick.AddListener(delegate {
                chooseStoryChoice(choice);
            });
        }



    }

    void eraseUI()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    void chooseStoryChoice (Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();

    }

    void Update()
    {

    }

    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }
        return text;
    }

}
