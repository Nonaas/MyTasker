namespace MyTasker.Domain.Services.Interfaces
{
    public interface IStatsService
    {
        int MyLevel { get; set; }
        int MyXP { get; set; }
        int XPforNextLevel { get; set; }


        void AddXP(int xpAmount);

        int GetXPPercentage();
    }
}
