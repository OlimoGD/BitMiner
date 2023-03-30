using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private MailInbox inbox;
    [SerializeField]
    private MailSO introductionMail;
    [SerializeField]
    private MailSO howToInsertGpuMail;
    [SerializeField]
    private GpuBoxSpawner gpuBoxSpawner;
    [SerializeField]
    private MiningRig miningRig;
    private int numberOfDestroyedGpus = 0;
    private int numberOfInsertedGpus = 0;
    private bool insertGpuTutorialMailSent = false;

    private void OnEnable()
    {
        gpuBoxSpawner.OnGpuSpawned += OnGpuSpawned;
        miningRig.OnGpuAdded += OnGpuInsertedIntoMiningRig;
    }

    private void OnDisable()
    {
        gpuBoxSpawner.OnGpuSpawned -= OnGpuSpawned;
        miningRig.OnGpuAdded -= OnGpuInsertedIntoMiningRig;
    }

    private void Start()
    {
        SendMail(introductionMail);
    }

    private void SendMail(MailSO mail)
    {
        inbox.PutInMail(new Mail(mail));
    }

    private void OnGpuSpawned(GPU gpu)
    {
        gpu.OnDestroyed += () => OnGpuDestroyed(gpu);
    }

    private void OnGpuDestroyed(GPU gpu)
    {
        numberOfDestroyedGpus++;
        if(TutorialInsertingGpusIsNotNeeded()) return;
        if(numberOfDestroyedGpus >= 3 && numberOfInsertedGpus == 0)
        {
           SendMail(howToInsertGpuMail);
           insertGpuTutorialMailSent = true;
        }
    }

    private void OnGpuInsertedIntoMiningRig(GpuItem gpu)
    {
        numberOfInsertedGpus++;
    }

    private bool TutorialInsertingGpusIsNotNeeded()
    {
        if(numberOfInsertedGpus > 0 || insertGpuTutorialMailSent)
        {
            gpuBoxSpawner.OnGpuSpawned -= OnGpuSpawned;
            miningRig.OnGpuAdded -= OnGpuInsertedIntoMiningRig;
            return true;
        }
        return false;
    }
}
