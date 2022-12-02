
namespace Event
{
    internal class Publisher
    {

    }

    //we are going to create a laptop class and see what happens when we press different keys

    public class laptop
    {
        List<char> Keys = new() { 'A', 'S', 'D', 'F', 'G', 'I','O' };

        int _batteryLevel = 0;

        event Action<string> Click;
        event Action<string> AlertLowBattery;
        event Action<string> ShutDown;

        public void AddClickMethod(Action<string> method)
        {
            Click += method;
        }

        public void AddAlertLowBatteryMethod(Action<string> method)
        {
            AlertLowBattery += method;
        }
        public void AddShutDownMethod(Action<string> method)
        {
            ShutDown += method;
        }

        const int Frequency = 1000;
        const int Duration = 500;
        const int LowBatteryLevel = 4;
        const int ShutDownBatteryLevel = 0;

        public void Start(string message)
        {
            foreach (var character in message)
            {
                if (_batteryLevel < 4)
                {
                    //low battery
                    OnAlertLowBattery("Battery Low\nPlug in laptop");
                }
                if (_batteryLevel == 0)
                {
                    //shutdown
                    OnShutDown("Bye-Bye");
                    Console.Beep(Frequency, Duration);
                    return;
                }

                switch (character)
                {
                    case 'A':
                        OnClick("A");
                        break;
                    case 'S':
                        OnClick("S");
                        break;
                    case 'D':
                        OnClick("D");
                        break;
                    case 'F':
                        OnClick("F");
                        break;
                    case 'G':
                        OnClick("G");
                        break;
                    case 'I':
                        OnClick("I");
                        break;
                    case 'O':
                        OnClick("O");
                        break;
                    default:
                        _batteryLevel--;
                        continue;
                }
            }
        }
        
        protected virtual void OnClick(string key) 
        {
            _batteryLevel--;
            Click?.Invoke(key);
        }

        protected virtual void OnAlertLowBattery(string message)
        {
            AlertLowBattery?.Invoke(message);
        }

        protected virtual void OnShutDown(string message)
        {
            ShutDown?.Invoke(message);
        }

    }
}
