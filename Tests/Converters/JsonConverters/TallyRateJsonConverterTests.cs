﻿namespace Tests.Converters.JsonConverters;
internal class TallyRateJsonConverterTests
{

    [Test]
    public void TestSerializeTallyRatewhenNull()
    {
        TallyRate tallyRate = null;
        string json = JsonSerializer.Serialize(tallyRate);
        Assert.AreEqual(json, "null");
    }
    [Test]
    public void TestSerializeTallyRatewhenEmpty()
    {
        TallyRate tallyRate = new();
        string json = JsonSerializer.Serialize(tallyRate);
        Assert.AreEqual(json, "{\"RatePerUnit\":0,\"Unit\":\"\",\"ForexAmount\":0,\"RateOfExchange\":0,\"ForeignCurrency\":null}");
    }
    [Test]
    public void TestSerializeTallyRate()
    {
        TallyRate tallyRate = new(10, "Nos");
        string json = JsonSerializer.Serialize(tallyRate);
        Assert.AreEqual(json, "{\"RatePerUnit\":10,\"Unit\":\"Nos\",\"ForexAmount\":0,\"RateOfExchange\":0,\"ForeignCurrency\":null}");
    }
    [Test]
    public void TestSerializeTallyRatewithForex()
    {
        TallyRate tallyRate = new("Nos", 10, 10, "$");
        string json = JsonSerializer.Serialize(tallyRate);
        Assert.AreEqual(json, "{\"RatePerUnit\":100,\"Unit\":\"Nos\",\"ForexAmount\":10,\"RateOfExchange\":10,\"ForeignCurrency\":\"$\"}");
    }



    [Test]
    public void TestDeSerializeTallyRatewhenNull()
    {
        string json = "null";
        var tallyRate = JsonSerializer.Deserialize<TallyRate>(json);
        Assert.AreEqual(tallyRate, null);
    }

    [Test]
    public void TestDeSerializeTallyRatewhenEmpty()
    {
        string json = "{\"RatePerUnit\":0,\"Unit\":\"\",\"ForexAmount\":0,\"RateOfExchange\":0,\"ForeignCurrency\":null}";
        var tallyRate = JsonSerializer.Deserialize<TallyRate>(json);
        Assert.AreEqual(tallyRate.Unit, string.Empty);
        Assert.AreEqual(tallyRate.RatePerUnit, 0);
    }
    [Test]
    public void TestDeSerializeTallyRate()
    {
        string json = "{\"RatePerUnit\":10,\"Unit\":\"Nos\"}";
        var tallyRate = JsonSerializer.Deserialize<TallyRate>(json);
        Assert.AreEqual(tallyRate.Unit, "Nos");
        Assert.AreEqual(tallyRate.RatePerUnit, 10);
    }
    [Test]
    public void TestDeSerializeTallyRatewithForex()
    {
        string json = "{\"RatePerUnit\":100,\"Unit\":\"Nos\",\"ForexAmount\":10,\"RateOfExchange\":10,\"ForeignCurrency\":\"$\"}";
        var tallyRate = JsonSerializer.Deserialize<TallyRate>(json);

        Assert.AreEqual(tallyRate.Unit, "Nos");
        Assert.AreEqual(tallyRate.RatePerUnit, 100);
        Assert.AreEqual(tallyRate.RateOfExchange, 10);
        Assert.AreEqual(tallyRate.ForeignCurrency, "$");
        Assert.AreEqual(tallyRate.ForexAmount, 10);
    }
}
