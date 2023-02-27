using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    [SerializeField]
    private MailInbox inbox;
    [SerializeField]
    private MailSO gpuSupplierContractMail;

    private void Start()
    {
        inbox.PutInMail(new Mail(gpuSupplierContractMail));
    }
}
