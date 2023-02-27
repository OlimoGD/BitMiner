using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MailScriptableObject")]
public class MailSO : ScriptableObject
{
    public string from;
    public string subject;
    [TextAreaAttribute(minLines: 5, maxLines: 5)]
    public string message;
}
