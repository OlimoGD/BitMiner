using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MailIcon : MonoBehaviour
{
    [SerializeField]
    private Image mailImage;
    [SerializeField]
    private Sprite mailIcon;
    [SerializeField]
    private Sprite mailIconWithNotification;
    [SerializeField]
    private TextMeshProUGUI notificationText;

    [SerializeField]
    private MailInbox mailInbox;
    private int numberOfUnreadMails = 0;

    private void OnEnable()
    {
        mailInbox.OnMailReceived += OnMailReceived;
        mailInbox.OnMailRead += OnMailRead;
    }

    private void OnDisable()
    {
        mailInbox.OnMailReceived -= OnMailReceived;
        mailInbox.OnMailRead -= OnMailRead;
    }

    private void OnMailReceived(Mail mail)
    {
        numberOfUnreadMails++;
        UpdateIconSprite();
    }

    private void OnMailRead(Mail mail)
    {
        numberOfUnreadMails--;
        UpdateIconSprite();
    }

    private void UpdateIconSprite()
    {
        if(numberOfUnreadMails > 0)
        {
            mailImage.sprite = mailIconWithNotification;
            notificationText.gameObject.SetActive(true);
            notificationText.text = numberOfUnreadMails.ToString();
        }
        else
        {
            notificationText.gameObject.SetActive(false);
            mailImage.sprite = mailIcon;
        }
    }
}
