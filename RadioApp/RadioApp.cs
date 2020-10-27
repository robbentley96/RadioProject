using System;
using System.Security.Authentication.ExtendedProtection;

namespace RadioApp
{
    public class Radio
    {
        private int _channel = 1;
        private bool _on = false;
        private Uri _source;
        private double _volume = 0.5;

        public double Volume { get { return Math.Round(_volume,1); } private set { } }

        public Uri Source { get { return _source; } private set { } }

        public int Channel
        {
            get { return _channel; }
            set 
            {
                if (_on)
                {
                    switch (value)
                    {
                        case 1:
                            _source = new Uri("https://kathy.torontocast.com:1435/stream");
                            _channel = 1;
                            break;
                        case 2:
                            _source = new Uri("http://192.99.37.181:8030/live");
                            _channel = 2;
                            break;
                        case 3:
                            _source = new Uri("https://str2b.openstream.co/1566?aw_0_1st.collectionid=4790&amp;stationId=4790&amp;publisherId=1590");
                            _channel = 3;
                            break;
                        case 4:
                            _source = new Uri("https://pri.gocaster.net/Throwbacks");
                            _channel = 4;
                            break;
                        default:
                            break;
                    }
                }
                 
            }
        }

        public string Play()
        {
            if (_on)
            {
                return $"Playing channel {_channel}";
            }
            else
            {
                return "Radio is off";
            }
            
            
        }

        public void TurnOff()
        {
            _on = false;
        }

        public void TurnOn()
        {
            _on = true;
        }

        public void IncreaseVolume()
        {
            if (_volume < 0.99 && _on)
            {
                _volume += 0.1;
            }
        }

        public void DecreaseVolume()
        {
            if (_volume > 0.01 && _on)
            {
                _volume -= 0.1;
            }
        }
    }
    // implement a class Radio that corresponds to the Class diagram 
    //   and specification in the Radio_Mini_Project document
}