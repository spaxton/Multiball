using UnityEngine;
public class StatDisplay : MonoBehaviour, IStatTracker
{
    [Header("Configuration")]
    public string StatName;

    [Header("Debugging")]
    public Stat ConnectedStat;

    private void OnDestroy()
    {
        if (ConnectedStat == null)
        {
            return;
        }

        ConnectedStat.UnregisterStatDisplay(this);
    }

    public void RegisterStat(Stat _stat)
    {
        ConnectedStat = _stat;
        ConnectedStat.RegisterStatDisplay(this);
        OnStatUpdate();
    }

    public virtual void OnStatUpdate()
    {

    }
}