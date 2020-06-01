using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGoToTile : ActionBasic
{
    public Vector3 Target; 
    public ActionGoToTile(GameObject subject) : base(subject)
    { }

    // Update is called once per frame
    public override void Execute()
    {
        if (!CanExecute()) return;
        var bhv = subject.GetComponent<BasicMoving>();
        bhv.SetTargetPosition(Target);
        base.Execute();
    }
    public override bool CanExecute()
    {
        if (!base.CanExecute()) return false;
        return true;
    }
    public override bool IsCompleted()
    {
        return (this.subject.transform.position.x == Target.x 
            && this.subject.transform.position.y == Target.y) ;
    }
}
