using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Goal
{
    public string name;
    public float value;
}
public struct Action
{
    public float getGoalChange(Goal goal)
    {
        return 0f;
    }
}

public class GoalBehavior : MonoBehaviour {

    public List<Action> actions = new List<Action>();
    public List<Goal> goals = new List<Goal>();

    Action chooseAction(List<Action> actions, List<Goal> goals)
    {
        Goal topGoal = goals[0];
        foreach (var goal in goals)
        {
            if(goal.value>topGoal.value)
            {
                topGoal = goal;
            }
        }

        Action bestAction = actions[0];
        float bestUtility = -actions[0].getGoalChange(topGoal);

        foreach (var action in actions)
        {
            float utility = -action.getGoalChange(topGoal);

            if(utility>bestUtility)
            {
                bestUtility = utility;
                bestAction = action;
            }
        }
        return bestAction;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
