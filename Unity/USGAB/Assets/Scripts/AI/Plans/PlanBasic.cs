using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanBasic
{
    public GameObject subject;
    public BasicAI AI;
    public List<ActionBasic> actions;
    public bool isActivated = false;
    public PlanBasic(GameObject subject)
    {
        this.subject = subject;
        this.AI = subject.GetComponent<BasicAI>();
    }
    public virtual void Execute()
    {
        isActivated = true;
    }
    public virtual void Proceed()
    {

    }
    public virtual bool CanExecute()
    {
        return true;
    }
    public virtual bool IsCompleted()
    {
        return true;
    }
}
