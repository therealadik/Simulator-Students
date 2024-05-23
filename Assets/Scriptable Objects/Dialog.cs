using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog")]
public class Dialog : ScriptableObject
{

    [TextArea(3, 10)]
    public string[] dialogLines;
    public string NPCName;
    // ƒобавь другие пол€, которые тебе нужны
}