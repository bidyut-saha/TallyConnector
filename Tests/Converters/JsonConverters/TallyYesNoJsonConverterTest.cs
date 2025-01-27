﻿namespace Tests.Converters.JsonConverters;
internal class TallyYesNoJsonConverterTest
{
    JsonSerializerOptions jsonSerializerOptions;
    public TallyYesNoJsonConverterTest()
    {
        jsonSerializerOptions = new();
        jsonSerializerOptions.Converters.Add(new TallyYesNoJsonConverter());
    }

    [Test]
    public void TestSerializeTallyYesNo()
    {
        TallyYesNo Tallybool = false;
        string json = JsonSerializer.Serialize(Tallybool, jsonSerializerOptions);
        Assert.AreEqual(json, "false");
    }
    [Test]
    public void TestDeSerializeTallyYesNo()
    {
        var obj = JsonSerializer.Deserialize<TallyYesNo>("true", jsonSerializerOptions);
        Assert.AreEqual((bool)obj, true);
    }

}
