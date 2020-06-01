using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFuck : ActionBasic
{
    Animator Animator;
    public ActionFuck(GameObject subject, Animator animator) : base(subject)
    {
        this.Animator = animator;
    }

    // Update is called once per frame
    public override void Execute()
    {
        this.Animator.SetInteger("Action", 100);
        this.AI.States.Add(new HumanStateFucking());
        base.Execute();
    }
    public override bool CanExecute()
    {
        if (!base.CanExecute()) return false;
        if (AI.States.Exists(x => x is HumanStateFucking))
            return false;
        return true;
    }
}
