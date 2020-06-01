using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBasic 
{    
    public GameObject subject;
    public BasicAI AI;
    public bool isActivated = false;

    

    public ActionBasic(GameObject subject)
    {
        this.subject = subject;
        this.AI = subject.GetComponent<BasicAI>();
    }
    public virtual void Execute()
    {
        isActivated = true;
    }
    public virtual bool CanExecute()
    {
        if (isActivated) return false;
        return true;
    }
    public virtual bool IsCompleted()
    {
        return true;
    }
}
