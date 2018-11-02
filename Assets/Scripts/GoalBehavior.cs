using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;





public class GoalBehavior : MonoBehaviour {

    public List<Goal> goals = new List<Goal>();
    public List<Action> actions = new List<Action>();

    public Action ChooseAction(List<Action> actions, List<Goal> goals)
    {
        // Сначала выбираем какая цель имеет наибольшую важность
        Goal topGoal = goals[0];
        foreach (var goal in goals)
        {
            if(goal.value>topGoal.value)
            {
                topGoal = goal;
            }
        }

        // Находим наилучшее действие по полезности для заданной цели
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

	void Start () {
		
	}
	

	void Update () {
		
	}
}
