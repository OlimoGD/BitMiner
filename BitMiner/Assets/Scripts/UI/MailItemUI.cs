using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MailItemUI : MonoBehaviour
{
    public delegate void OnClickedDelegate(MailItemUI mailItemUi);
    public event OnClickedDelegate OnClicked;

    [SerializeField]
    private TextMeshProUGUI fromText;
    [SerializeField]
    private TextMeshProUGUI subjectText;
    [SerializeField]
    private TextMeshProUGUI dateText;

    [SerializeField]
    private MouseArea mouseArea;

    private Mail mail;
    public Mail Mail { get { return mail; } }

    private void OnEnable()
    {
        mouseArea.OnMousePrimaryButtonPressed += OnMousePrimaryButtonPressed;
    }

    private void OnDisable()
    {
        mouseArea.OnMousePrimaryButtonPressed -= OnMousePrimaryButtonPressed;
    }

    public void SetMail(Mail mail)
    {
        this.mail = mail;
        fromText.text = mail.From;
        subjectText.text = mail.Subject;
        dateText.text = mail.Date;
    }

    private void OnMousePrimaryButtonPressed(int zOrder)
    {
        if(zOrder != 0) return;
        OnClicked?.Invoke(this);
    }
}
