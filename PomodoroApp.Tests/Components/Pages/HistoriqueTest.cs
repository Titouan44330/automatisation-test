using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroApp.Components.Pages;

namespace PomodoroApp.Tests.Components.Pages;

[TestClass]
[TestSubject(typeof(Historique))]
public class HistoriqueTest
{

    [TestMethod]
    public void SumTotalWorkTimeTest()
    {
        var historique = new Historique();
        Historique.Sequence sequence = new Historique.Sequence();
        sequence.workTime = "00:00:01.4385665";
        System.Collections.Generic.List<Historique.Sequence> sequences = new System.Collections.Generic.List<Historique.Sequence>();
        sequences.Add(sequence);
        Assert.AreEqual(historique.SumTotalWorkTime(sequences), System.TimeSpan.Parse("00:00:01.4300000"));
    }
    
    [TestMethod]
    public void SumTotalWorkTimeMultipleTimesTest()
    {
        var historique = new Historique();
        Historique.Sequence sequence = new Historique.Sequence();
        sequence.workTime = "00:00:01.4385665";
        Historique.Sequence sequence2 = new Historique.Sequence();
        sequence2.workTime = "00:00:02.4385665";
        System.Collections.Generic.List<Historique.Sequence> sequences = new System.Collections.Generic.List<Historique.Sequence>();
        sequences.Add(sequence);
        sequences.Add(sequence2);
        Assert.AreEqual(historique.SumTotalWorkTime(sequences), System.TimeSpan.Parse("00:00:03.8600000"));
    }
    
    [TestMethod]
    public void SumPauseWorkTimeTest()
    {
        var historique = new Historique();
        Historique.Sequence sequence = new Historique.Sequence();
        sequence.pauseTime = "00:00:01.4385665";
        System.Collections.Generic.List<Historique.Sequence> sequences = new System.Collections.Generic.List<Historique.Sequence>();
        sequences.Add(sequence);
        Assert.AreEqual(historique.SumTotalPauseTime(sequences), System.TimeSpan.Parse("00:00:01.4300000"));
    }
    
    [TestMethod]
    public void SumPauseWorkTimeMultipleTimesTest()
    {
        var historique = new Historique();
        Historique.Sequence sequence = new Historique.Sequence();
        sequence.pauseTime = "00:00:01.4385665";
        Historique.Sequence sequence2 = new Historique.Sequence();
        sequence2.pauseTime = "00:00:02.4385665";
        System.Collections.Generic.List<Historique.Sequence> sequences = new System.Collections.Generic.List<Historique.Sequence>();
        sequences.Add(sequence);
        sequences.Add(sequence2);
        Assert.AreEqual(historique.SumTotalPauseTime(sequences), System.TimeSpan.Parse("00:00:03.8600000"));
    }
    
    
    
    
}