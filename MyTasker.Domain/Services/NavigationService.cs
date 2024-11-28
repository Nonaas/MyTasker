namespace MyTasker.Domain.Services
{
    public class NavigationService
    {
        public string? NavigationPageValue { get; set; }
        public event Action? OnValueChanged;

        public void SetNavigationPageValue(string value)
        {
            NavigationPageValue = value;
            OnValueChanged?.Invoke();
        }
    }
}
