using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mail
{
    private MailSO mailSo;

    public string From { get{ return mailSo.from; } }
    public string Subject { get{ return mailSo.subject; } }
    public string Date { get; }
    public string Message { get{ return mailSo.message; } }
    public bool Read { get; set; }

    public Mail(MailSO so)
    {
        mailSo = so;
        Date = DateTimeOffset.Now.ToString("yyyy.MM.dd.");
        Read = false;
    }
}
