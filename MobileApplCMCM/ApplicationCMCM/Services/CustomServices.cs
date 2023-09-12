using ApplicationCMCM.CustomConstants;

namespace ApplicationCMCM.Services;

public static class CustomServices
{
    public static void CallingEmergencyFunction()
    {
        if (PhoneDialer.Default.IsSupported)
        {
            PhoneDialer.Current.Open(CustomConst.EmergencyNumber);
        }
    }
}
