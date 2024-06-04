using System;
using System.Diagnostics.Metrics;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroApp.Components.Pages;

namespace PomodoroApp.Tests.Components.Pages;

[TestClass]
[TestSubject(typeof(Counter))]
public class CounterTest
{
    

    [TestMethod]
    public void IncrementCountTest()
    {
        var counter = new Counter();
        counter.currentCount = 0;
        counter.IncrementCount();
        Assert.AreEqual(counter.currentCount, 1);
    }
    
    [TestMethod]
    public void FormatTimeTest()
    {
        var counter = new Counter();
        Assert.AreEqual(counter.formatTime(90), "01:30");
    }
    
    [TestMethod]
    public void Set25Test()
    {
        var counter = new Counter();
        counter.Set25();
        Assert.IsTrue(counter.is25);
        Assert.AreEqual(counter.pomodoroDuration, 1500);
        Assert.AreEqual(counter.remainingTime, 1500);
    }
    
    [TestMethod]
    public void Set45Test()
    {
        var counter = new Counter();
        counter.Set45();
        Assert.IsFalse(counter.is25);
        Assert.AreEqual(counter.pomodoroDuration, 2700);
        Assert.AreEqual(counter.remainingTime, 2700);
    }
    
    [TestMethod]
    public void StartTimerTest()
    {
        var counter = new Counter();
        counter.timer = new System.Timers.Timer();
        counter.StartTimer();
        Assert.IsFalse(counter.isTimerPaused);
        Assert.IsTrue(counter.isTimerRunning);
        Assert.IsTrue(counter.timer.Enabled);
        Assert.IsTrue(counter.dureeTotale.IsRunning);
        Assert.IsTrue(counter.dureeTravail.IsRunning);
        Assert.IsFalse(counter.dureePause.IsRunning);
    }
    
    [TestMethod]
    public void StartTimerCurrentCountIsNot0Test()
    {
        var counter = new Counter();
        counter.timer = new System.Timers.Timer();
        counter.currentCount = 1;
        counter.StartTimer();
        Assert.IsFalse(counter.isTimerPaused);
        Assert.IsTrue(counter.isTimerRunning);
        Assert.IsTrue(counter.timer.Enabled);
        Assert.IsFalse(counter.dureeTotale.IsRunning);
        Assert.IsFalse(counter.dureeTravail.IsRunning);
        Assert.IsFalse(counter.dureePause.IsRunning);
    }
    
    [TestMethod]
    public void PauseTimerTest()
    {
        var counter = new Counter();
        counter.timer = new System.Timers.Timer();
        counter.PauseTimer();
        Assert.IsTrue(counter.isTimerPaused);
        Assert.IsFalse(counter.isTimerRunning);
        Assert.IsFalse(counter.timer.Enabled);
        Assert.IsFalse(counter.dureeTotale.IsRunning);
        Assert.IsFalse(counter.dureeTravail.IsRunning);
        Assert.IsFalse(counter.dureePause.IsRunning);
    }
    
    [TestMethod]
    public void ResetTimerTest()
    {
        var counter = new Counter();
        counter.timer = new System.Timers.Timer();
        counter.ResetTimer();
        Assert.IsFalse(counter.timer.Enabled);
        Assert.AreEqual(counter.remainingTime, counter.pomodoroDuration);
    }
    
    [TestMethod]
    public void EndSessionTest()
    {
        var counter = new Counter();
        counter.timer = new System.Timers.Timer();
        counter.endSession();
        Assert.IsFalse(counter.dureeTotale.IsRunning);
        Assert.IsFalse(counter.dureeTravail.IsRunning);
        Assert.IsFalse(counter.dureePause.IsRunning);
    }
    
    

}