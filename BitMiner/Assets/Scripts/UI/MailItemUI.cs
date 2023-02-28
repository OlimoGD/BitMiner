using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    [SerializeField]
    private Image panelImage;

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

    public void OnMailRead()
    {
        Color readColor = new Color(
            panelImage.color.r - 0.2f, 
            panelImage.color.g - 0.2f, 
            panelImage.color.b - 0.2f, 
            panelImage.color.a);
        panelImage.color = readColor;
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
