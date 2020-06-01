using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSleep : ActionBasic
{
    public ActionSleep(GameObject subject) : base(subject) { }

    // Update is called once per frame
    public override void Execute()
    {
        var bed = GameObject.Find("Bed");
        var bhv = subject.GetComponent<BasicMoving>();
        bhv.SetTargetPosition(bed.transform.position);
        this.AI.States.Add(new HumanStateSleeping());
        base.Execute();
    }
    public override bool CanExecute()
    {
        if (!base.CanExecute()) return false;
        //if (AI.States.Exists(x => x is HumanStateSleeping))
        //    return false;
        if (WorldTime.TimeOfDay == TimeOfDay.night)
            return true;
        return false;
    }
}
