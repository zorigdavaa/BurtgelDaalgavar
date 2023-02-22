namespace Homework.Client.Services
{
    public class AppState
    {
        public EventHandler authenticationChanged;
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                if (_isAuthenticated != value)
                {
                    _isAuthenticated = value;
                    authenticationChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private bool _isAuthenticated = false;


    }
}
