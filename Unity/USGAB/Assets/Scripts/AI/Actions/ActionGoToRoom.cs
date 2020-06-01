using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionGoToRoom : ActionBasic
{
    private LocationCell CellToGo;
    public ActionGoToRoom(GameObject subject, LocationCell cell) : base(subject)
    {
        CellToGo = cell;
    }

    public override void Execute()
    {
       
        List<Vector3> path = null;
        Vector2Int goal = Vector2Int.zero;
        foreach (var entrance in CellToGo.Entrances)
        {
            var newpath = AbPath.FindPath(subject.transform.position, entrance.Entrance);
            if (newpath != null && newpath.Any())
            {
                if (path == null)
                {
                    path = newpath;
                    goal = entrance.Entrance;
                }
                else if (newpath.Count < path.Count)
                {
                    path = newpath;
                    goal = entrance.Entrance;
                }
            }
        }
        if (goal != Vector2Int.zero)
        {
            var bhv = subject.GetComponent<BasicMoving>();
            bhv.SetTargetPosition(goal);
            base.Execute();
        }
    }
}
