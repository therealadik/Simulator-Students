using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences = new();
    private QuestGiver currentQuestGiver = null;
    private PlayerController playerController;
    private QuestManager questManager;
    private string currentSentence = "";

    public TMP_Text sentenceText;
    public TMP_Text nameText;

    public Animator animator;

    private void Awake()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        questManager = FindFirstObjectByType<QuestManager>();
    }

    public void StartDialogue(Dialog dialog, QuestGiver questGiver = null)
    {
        currentQuestGiver = questGiver;
        nameText.text = dialog.NPCName;
        animator.SetBool("isOpen", true);
        playerController.SetControll(false);

        sentences.Clear();

        foreach (string sentence in dialog.dialogLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        StopAllCoroutines();
        if (currentSentence != "" && sentenceText.text.Length != currentSentence.Length)
        {
            sentenceText.text = currentSentence;
            return;
        }

        currentSentence = sentences.Dequeue();
        
        StartCoroutine(TypeSentence());
    }

    private IEnumerator TypeSentence()
    {
        sentenceText.text = "";
        foreach (char item in currentSentence.ToCharArray())
        {
            sentenceText.text += item;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        StartCoroutine(TakePlayerControl());
        if (currentQuestGiver)
        {
            questManager.AddQuest(currentQuestGiver.GetQuest);
            currentQuestGiver.TakeQuest();
        }
    }

    private IEnumerator TakePlayerControl()
    {
        yield return new WaitForSeconds(2);
        playerController.SetControll(true);
    }
}
