using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    private List<PlanBasic> plans = new List<PlanBasic>();
    public PlanBasic CurrentPlan;
    public ActionBasic CurrentAction;
    public List<HumanStateBasic> States = new List<HumanStateBasic>();
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {       
        
    }

    // Update is called once per frame
    void Update()
    {
        // set moving target
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            CurrentAction = new ActionGoToTile(this.gameObject);
            CurrentAction.Execute();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            CurrentPlan = new PlanToHaveSex(this.gameObject, this.animator);
            CurrentPlan.Execute();
        }

        if (CurrentPlan != null)
            CurrentPlan.Proceed();
    }
}
