using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanToHaveSex : PlanBasic
{
    private ActionFuck fuck;
    private ActionGoToTile goToBed;
    public PlanToHaveSex(GameObject subject, Animator animator): base(subject)
    {
        goToBed = new ActionGoToTile(subject);
        fuck = new ActionFuck(subject, animator);
    }
    public override void Execute()
    {
        if (!CanExecute()) return;
        if (!this.isActivated)
        {
            var bed = GameObject.Find("Bed");
            goToBed.Target = bed.transform.position;
            goToBed.Execute();
            this.isActivated = true;       
        }
        //else
        //{
        //    if (!actions.First().IsCompleted)
        //        return;
        //    else
        //    {
        //        var action = this.actions.Where(x => x is ActionFuck).FirstOrDefault();
        //        if (action != null)
        //        {                    
        //            action.Execute();
        //        }
        //    }
        //}
    }
    public override bool CanExecute()
    {
        if (!base.CanExecute()) return false;
        return true;
    }
    public override bool IsCompleted()
    {
        return fuck.IsCompleted();
    }
    public override void Proceed()
    {
        if (goToBed.IsCompleted())
        {
            if (!fuck.isActivated)
            {
                fuck.Execute();
            }
        }
    }
}
