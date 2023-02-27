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

    private Mail currentlyOpenMail;
    public Mail CurrentlyOpenMail { get { return currentlyOpenMail; } }

    private void OnEnable()
    {
        mailInbox.OnMailReceived += OnMailReceived;
    }

    private void OnDisable()
    {
        mailInbox.OnMailReceived -= OnMailReceived;
    }

    private void OnMailReceived(Mail mail)
    {
        InstantiateMailItem(mail);
    }

    private void InstantiateMailItem(Mail mail)
    {
        GameObject go = Instantiate(mailItemPrefab, Vector3.zero, Quaternion.identity, mailItemsContainer.transform);
        MailItemUI ui = go.GetComponent<MailItemUI>();
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
        currentlyOpenMail.Read = true;
        viewNavigationManager.NavigateTo(ViewNavigationManager.ViewName.MAIL_DETAILS);
    }
}
