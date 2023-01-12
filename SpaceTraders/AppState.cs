using SpaceTraders.Userdata;

namespace SpaceTraders
{
    public class AppState
    {
      public event Action OnChange;
      private MyAccountDto myAccount;
      public MyAccountDto MyAccount
      {
        get
        {
         return myAccount;
        }
        set
        {
         myAccount = value;
         NotifyStateChanged();
        }
      }
     private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
