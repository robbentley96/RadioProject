using System;
using NUnit.Framework;
using RadioApp;
namespace RadioTests
{
    public class RadioSouceAndVolumeTests
    {
        private Radio _radio;
        [SetUp]
        public void Setup()
        {
            _radio = new Radio();
            _radio.TurnOn();
        }

        [Test]
        public void IncreaseVolumeTest()
        {
            Assert.AreEqual(_radio.Volume, 0.5);
            _radio.IncreaseVolume();
            Assert.AreEqual(_radio.Volume, 0.6);
            _radio.IncreaseVolume();
            _radio.IncreaseVolume();
            _radio.IncreaseVolume();
            _radio.IncreaseVolume();
            _radio.IncreaseVolume();
            Assert.AreEqual(_radio.Volume, 1.0);


        }

        [Test]
        public void DecreaseVolumeTest()
        {
            Assert.AreEqual(_radio.Volume, 0.5);
            _radio.DecreaseVolume();
            Assert.AreEqual(_radio.Volume, 0.4);
            _radio.DecreaseVolume();
            _radio.DecreaseVolume();
            _radio.DecreaseVolume();
            _radio.DecreaseVolume();
            Assert.AreEqual(_radio.Volume, 0.0);
        }
        [TestCase(1, "https://kathy.torontocast.com:1435/stream")]
        [TestCase(2, "http://192.99.37.181:8030/live")]
        [TestCase(3, "https://str2b.openstream.co/1566?aw_0_1st.collectionid=4790&amp;stationId=4790&amp;publisherId=1590")]
        [TestCase(4, "https://pri.gocaster.net/Throwbacks")]
        public void ChannelChangeSetsSourceTest(int channelNum, string expectedSource)
        {
            _radio.Channel = channelNum;
            Assert.AreEqual(expectedSource, _radio.Source.ToString());
        }

    }
}