using UnityEngine;
using NUnit.Framework;

public class ScoreTest {

    private GameObject go;
    private Score score;

    [SetUp]
    public void Setup() {
        go = new GameObject();
        score = go.AddComponent<Score>();
    }

    [TearDown]
    public void Teardown() {
        GameObject.DestroyImmediate(go);
    }

	[Test]
	public void CanSetScore() {
        this.score.GameScore = 5;
        Assert.AreEqual(5, this.score.GameScore);
	}

    [Test]
    public void SetsHighScoreWhenNewScoreIsHigherThanPreviousScore() {
        this.score.GameScore = 5;

        Assert.AreEqual(5, this.score.GetHighScore());

        this.score.GameScore = 2;
        Assert.AreEqual(5, this.score.GetHighScore());

        this.score.GameScore = 10;
        Assert.AreEqual(10, this.score.GetHighScore());
    }

    [Test]
    public void ResetScoreDoesNotResetHighScore() {
        this.score.GameScore = 5;
        this.score.ResetScore();

        Assert.AreEqual(0, this.score.GameScore);
        Assert.AreEqual(5, this.score.GetHighScore());
    }
}
