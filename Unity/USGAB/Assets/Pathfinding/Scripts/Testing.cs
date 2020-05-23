/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Testing : MonoBehaviour {
    
    //[SerializeField] private PathfindingDebugStepVisual pathfindingDebugStepVisual;
    //[SerializeField] private PathfindingVisual pathfindingVisual;
    public MariaBehaviour characterPathfinding;
    //private AbPath pathfinding;

    private void Start() {
        //pathfinding = new AbPath();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            //List<AbWorldTile> path = AbPath.FindPath(Vector3.zero, mouseWorldPosition);
            //if (path != null) {
            //    for (int i=0; i<path.Count - 1; i++) {
            //        Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i+1].x, path[i+1].y) * 10f + Vector3.one * 5f, Color.green, 5f);
            //    }
            //}
            characterPathfinding.SetTargetPosition(mouseWorldPosition);
        }      
    }

}
