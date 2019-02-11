using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace VirtualPetsAmok.Tests
{
    public class RoboticPetsTests
    {
        [Fact]
        public void Robot_Has_OilLevel()
        {
            Robotic myPet = new Robotic();

            Assert.InRange(myPet.OilLevel, 20, 50);
        }

        [Fact]
        public void Robot_Has_BatteryLevel()
        {
            Robotic myPet = new Robotic();

            Assert.InRange(myPet.BatteryLevel, 20, 50);
        }

        [Fact]
        public void Robot_Has_Temperature()
        {
            Robotic myPet = new Robotic();

            Assert.InRange(myPet.Temperature, 20, 50);
        }

        [Fact]
        public void OilChange_Increase_Level()
        {
            Robotic myPet = new Robotic();

            myPet.OilChange();

            Assert.Equal(100, myPet.OilLevel);
        }

        [Fact]
        public void Charge_Increase_Level()
        {
            Robotic myPet = new Robotic();

            myPet.ChargeBattery();

            Assert.Equal(100, myPet.BatteryLevel);
        }

        [Fact]
        public void Cooldown_Decrease_Level()
        {
            Robotic myPet = new Robotic();

            myPet.CoolDown();

            Assert.Equal(0, myPet.Temperature);
        }
    }
}
