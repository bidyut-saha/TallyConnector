﻿namespace TallyConnector.Models.Masters.Inventory;

[XmlRoot(ElementName = "STOCKITEM")]
public class StockItem : TallyXmlJson, ITallyObject
{
    public StockItem()
    {
        LanguageNameList = new();
        BOMList = new();
    }

    [XmlElement(ElementName = "MASTERID")]
    public int? TallyId { get; set; }


    [XmlAttribute(AttributeName = "NAME")]
    [JsonIgnore]
    public string OldName { get; set; }

    private string name;

    [XmlElement(ElementName = "NAME")]
    [Required]
    public string Name
    {
        get
        {
            name = (name == null || name == string.Empty) ? OldName : name;
            return name;
        }
        set => name = value;
    }

    [XmlElement(ElementName = "PARENT")]
    public string StockGroup { get; set; }

    [XmlElement(ElementName = "CATEGORY")]
    public string Category { get; set; }

    [XmlElement(ElementName = "GSTAPPLICABLE")]
    public string GSTApplicable { get; set; }

    [XmlElement(ElementName = "GSTTYPEOFSUPPLY")]
    public string GSTTypeOfSupply { get; set; }

    [XmlElement(ElementName = "TCSAPPLICABLE")]
    public string TCSApplicable { get; set; }

    [XmlElement(ElementName = "DESCRIPTION")]
    public string Description { get; set; }

    [XmlElement(ElementName = "NARRATION")]
    public string Narration { get; set; }

    [XmlElement(ElementName = "COSTINGMETHOD")]
    public string CostingMethod { get; set; }

    [XmlElement(ElementName = "VALUATIONMETHOD")]
    public string ValuationMethod { get; set; }

    [XmlElement(ElementName = "ISCOSTCENTRESON")]
    public string IsCostTracking { get; set; }

    [XmlElement(ElementName = "ISBATCHWISEON")]
    public string MaintainInBranches { get; set; }

    [XmlElement(ElementName = "ISPERISHABLEON")]
    public string UseExpiryDates { get; set; }

    [XmlElement(ElementName = "HASMFGDATE")]
    public string TrackDateOfManufacturing { get; set; }

    [XmlElement(ElementName = "BASEUNITS")]
    public string BaseUnit { get; set; }

    [XmlElement(ElementName = "ADDITIONALUNITS")]
    public string AdditionalUnits { get; set; }

    [XmlElement(ElementName = "INCLUSIVETAX")]
    public string InclusiveOfTax { get; set; }


    [XmlElement(ElementName = "CONVERSION")]
    public string Conversion { get; set; }

    [XmlElement(ElementName = "BASICRATEOFEXCISE")]
    public string RateOfDuty { get; set; }

    [XmlElement(ElementName = "OPENINGBALANCE")]
    public string OpeningBal { get; set; }

    [XmlElement(ElementName = "OPENINGVALUE")]
    public string OpeningValue { get; set; }

    [XmlElement(ElementName = "OPENINGRATE")]
    public string OpeningRate { get; set; }



    [XmlIgnore]
    public string Alias { get; set; }

    [JsonIgnore]
    [XmlElement(ElementName = "LANGUAGENAME.LIST")]
    public List<LanguageNameList> LanguageNameList { get; set; }

    [XmlElement(ElementName = "MULTICOMPONENTLIST.LIST")]
    public List<ComponentsList> BOMList { get; set; }

    /// <summary>
    /// Accepted Values //Create, Alter, Delete
    /// </summary>
    [JsonIgnore]
    [XmlAttribute(AttributeName = "Action")]
    public string Action { get; set; }

    [XmlElement(ElementName = "GUID")]
    public string GUID { get; set; }

    public void CreateNamesList()
    {
        if (LanguageNameList.Count == 0)
        {
            LanguageNameList.Add(new LanguageNameList());
            LanguageNameList[0].NameList.NAMES.Add(Name);

        }
        if (Alias != null && Alias != string.Empty)
        {
            LanguageNameList[0].LanguageAlias = Alias;
        }
    }
    public new string GetXML(XmlAttributeOverrides attrOverrides = null)
    {
        CreateNamesList();
        return base.GetXML(attrOverrides);
    }

    public void PrepareForExport()
    {
        if (StockGroup != null && StockGroup.Contains("Primary"))
        {
            StockGroup = null;
        }
        CreateNamesList();
    }
}
[XmlRoot(ElementName = "ENVELOPE")]
public class StockItemEnvelope : TallyXmlJson
{

    [XmlElement(ElementName = "HEADER")]
    public Header Header { get; set; }

    [XmlElement(ElementName = "BODY")]
    public SIBody Body { get; set; } = new();
}

[XmlRoot(ElementName = "BODY")]
public class SIBody
{
    [XmlElement(ElementName = "DESC")]
    public Description Desc { get; set; } = new();

    [XmlElement(ElementName = "DATA")]
    public SIData Data { get; set; } = new();
}

[XmlRoot(ElementName = "DATA")]
public class SIData
{
    [XmlElement(ElementName = "TALLYMESSAGE")]
    public SIMessage Message { get; set; } = new();

    [XmlElement(ElementName = "COLLECTION")]
    public StockItemColl Collection { get; set; } = new StockItemColl();


}

[XmlRoot(ElementName = "COLLECTION")]
public class StockItemColl
{
    [XmlElement(ElementName = "STOCKITEM")]
    public List<StockItem> StockItems { get; set; }
}

[XmlRoot(ElementName = "TALLYMESSAGE")]
public class SIMessage
{
    [XmlElement(ElementName = "STOCKITEM")]
    public StockItem StockItem { get; set; }
}