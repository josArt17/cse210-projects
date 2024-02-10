using System;


//JOSE ANGEL ARTEAGA CSE210 EXCEED REQUIREMENTS I ADD A CLASS FOR REWARDS, THE USEA CAN SET REWARDS FOR THEYSELF
// WHEN THE SCORE IS EQUAL TO THE VALUE FOT THE REWARDS THE PROGRAM SHOW A MESSAGE TO THE USER SAYING THE REWARD IS CLAIMED
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}