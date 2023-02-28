using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailInbox : MonoBehaviour
{
    public delegate void MailReceivedDelegate(Mail mail);
    public event MailReceivedDelegate OnMailReceived;
    public delegate void MailReadDelegate(Mail mail);
    public event MailReadDelegate OnMailRead;

    private readonly List<Mail> mails = new List<Mail>();

    public void PutInMail(Mail mail)
    {
        mails.Add(mail);
        OnMailReceived?.Invoke(mail);
    }

    public List<Mail> GetMails()
    {
        return mails;
    }

    public void ReadMail(Mail mail)
    {
        mail.Read = true;
        OnMailRead?.Invoke(mail);
    }
}
