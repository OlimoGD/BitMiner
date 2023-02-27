using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MailDetailsUI : MonoBehaviour
{
    [SerializeField]
    private MailUI mailUI;
    [SerializeField]
    private TextMeshProUGUI fromText;
    [SerializeField]
    private TextMeshProUGUI subjectText;
    [SerializeField]
    private TextMeshProUGUI dateText;
    [SerializeField]
    private TextMeshProUGUI messageText;


    private void OnEnable()
    {
        UpdateMailTexts(mailUI.CurrentlyOpenMail);
    }

    private void UpdateMailTexts(Mail mail)
    {
        if(mail == null) return;
        fromText.text = mail.From;
        subjectText.text = mail.Subject;
        dateText.text = mail.Date;
        messageText.text = mail.Message;
    }
}
