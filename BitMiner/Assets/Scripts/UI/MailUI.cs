using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailUI : MonoBehaviour
{
    [SerializeField]
    private MailInbox mailInbox;
    [SerializeField]
    private GameObject mailItemPrefab;
    [SerializeField]
    private GameObject mailItemsContainer;

    [SerializeField]
    private ViewNavigationManager viewNavigationManager;

    private List<MailItemUI> mailItemUis = new List<MailItemUI>();

    private Mail currentlyOpenMail;
    public Mail CurrentlyOpenMail { get { return currentlyOpenMail; } }

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
        InstantiateMailItem(mail);
    }

    private void OnMailRead(Mail mail)
    {
        foreach (MailItemUI mailItemUi in mailItemUis)
        {
            if(mailItemUi.Mail == mail)
            {
                mailItemUi.OnMailRead();
            }
        }
    }

    private void InstantiateMailItem(Mail mail)
    {
        GameObject go = Instantiate(mailItemPrefab, Vector3.zero, Quaternion.identity, mailItemsContainer.transform);
        MailItemUI ui = go.GetComponent<MailItemUI>();
        mailItemUis.Add(ui);
        ui.SetMail(mail);
        ui.OnClicked += OnMailItemClicked;
    }

    private void OnMailItemClicked(MailItemUI mailItemUi)
    {
        OpenMail(mailItemUi.Mail);
    }

    private void OpenMail(Mail mail)
    {
        currentlyOpenMail = mail;
        mailInbox.ReadMail(currentlyOpenMail);
        viewNavigationManager.NavigateTo(ViewNavigationManager.ViewName.MAIL_DETAILS);
    }
}
