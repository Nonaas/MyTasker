using MyTasker.Domain.Services.Interfaces;

namespace MyTasker.Domain.Services
{
    public class StatsService : IStatsService
    {
        public int MyLevel { get; set; }
        public int MyXP { get; set; }
        public int XPforNextLevel { get; set; } = 100;


        public void AddXP(int xpAmount)
        {
            MyXP += xpAmount;

            // Level up if XP reaches or exceeds required amount
            while (MyXP >= XPforNextLevel)
            {
                MyXP -= XPforNextLevel;
                MyLevel++;
                XPforNextLevel += 50;
            }
        }

        public int GetXPPercentage()
        {
            return (int)((float)MyXP / XPforNextLevel * 100);
        }
    }
}
