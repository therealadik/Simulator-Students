using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog")]
public class Dialog : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] dialogLines;
    // ������ ������ ����, ������� ���� �����
}

public class Test : ScriptableObject
{
    List<string> dialog;
}
