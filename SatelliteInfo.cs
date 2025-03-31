using satelite_tracker_jense;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// This script was created by Crafting Heroes LLC as a support for students working on learning how to read in 
/// data from Bluestaq's Unified Data Library.
/// Bluestaq's data is owned by their company and use of their data in our tutorials and supports for students should
/// not be considered an endorsement of our use or support of their data/resources. 
/// This script is provided to make onboarding easier for students to have a starting place, however, not all elements
/// of this script should be taken as an example of best scripting practices. 
/// 
/// If you have any questions about this script or our tutorials, please email sean@craftingheroes.com. 
/// And, of course, if you would like to support our work with students, please feel free to contact us through 
/// our website at https://www.craftingheroes.com. 
/// 
/// Thank you! 
///
/// </summary>
public class SatelliteInfo
{
    public string idElset = "";
    public char classificationMarking = ' ';
    public int satNum = 0;
    public string epoch = "";
    public double meanMotion = 0.0;
    public long idOnOrbit = 0;
    public double eccentricity = 0.0;
    public double inclination = 0.0;
    public double raan = 0.0;
    public double argOfPerigee = 0.0;
    public double meanAnomoly = 0.0;
    public int revNo = 0;
    public double bStar = 0.0;
    public double meanMotionDot = 0.0;
    public double meanMotionDDot = 0.0;
    public double semiMajorAxis = 0.0;
    public double period = 0.0;
    public double apogee = 0.0;
    public double perigee = 0.0;
    public string line1 = "";
    public string line2 = "";
    public string createdAt = "";
    public string createdBy = "";
    public string source = "";
    public string dataMode = "";
    public string algorithm = "";
    public string origNetwork = "";
    public List<string> satData = new List<string>();
    public string[] satDataArray;

    public SatelliteInfo(string newSatData)
    {
        satData.Add(newSatData);
    }

    public void AddSatData(string newSatData)
    {
        satData.Add(newSatData);
    }

    public string GetSatData(Form1 form)
    {
        for (int i = 0; i < satData.Count; i++)
        {
            form.updateTextBox(satData[i], form.textBox4);
        }
        return "complete";
    }

    public string[] GetSatDataArray()
    {
        satDataArray = new string[satData.Count];
        for (int i = 0; i < satData.Count; i++)
        {
            satDataArray[i] = satData[i].ToString() + "\n";
        }
        return satDataArray;
    }

    public void SetSatVariables()
    {
        SetSatID();
        SetSatClassification();
        SetSatNum();
        SetSatEpoch();
        SetSatMeanMotion();
        SetSatIdOnOrbit();
        SetSatEccentricity();
        SetSatInclination();
        SetSatRaan();
        SetSatArgOfPerigee();
        SetSatMeanAnomoly();
        SetSatRevNo();
        SetSatBStar();
        SetSatMeanMotionDot();
        SetSatMeanMotionDDot();
        SetSatSemiMajorAxis();
        SetSatPeriod();
        SetSatApogee();
        SetSatPerigee();
        SetSatLine1();
        SetSatLine2();
        SetSatCreatedAt();
        SetSatCreatedBy();
        SetSatSource();
        SetSatDataMode();
        SetSatAlgorithm();
        SetSatOrigNetwork();
        SetSatData();
    }

    private void SetSatID()
    {
        idElset = satData[1];
    }
    private void SetSatClassification()
    {
        classificationMarking = satData[3].ToCharArray().ElementAt(0);
    }
    private void SetSatNum()
    {
        try
        {
            satNum = Int32.Parse(satData[5]);
        }
        catch
        {
            satNum = -1;
        }
    }

    public int GetSatNum()
    {
        return satNum;
    }
    private void SetSatEpoch()
    {
        epoch = satData[7];
    }
    private void SetSatMeanMotion()
    {
        try
        {
            meanMotion = Double.Parse(satData[9]);
        }
        catch
        {
            meanMotion = -1;
        }
    }
    private void SetSatIdOnOrbit()
    {
        try
        {
            idOnOrbit = Int64.Parse(satData[11]);
        }
        catch
        {
            idOnOrbit = -1;
        }
    }
    private void SetSatEccentricity()
    {
        try
        {
            eccentricity = Double.Parse(satData[13]);
        }
        catch
        {
            eccentricity = -1;
        }
    }
    private void SetSatInclination()
    {
        try
        {
            inclination = Double.Parse(satData[15]);
        }
        catch
        {
            inclination = -1;
        }
    }
    private void SetSatRaan()
    {
        try
        {
            raan = Double.Parse(satData[17]);
        }
        catch
        {
            raan = -1;
        }
    }
    private void SetSatArgOfPerigee()
    {
        try
        {
            argOfPerigee = Double.Parse(satData[19]);
        }
        catch
        {
            argOfPerigee = -1;
        }
    }
    private void SetSatMeanAnomoly()
    {
        try
        {
            meanAnomoly = Double.Parse(satData[21]);
        }
        catch
        {
            meanAnomoly = -1;
        }
    }
    private void SetSatRevNo()
    {
        try
        {
            revNo = Int32.Parse(satData[23]);
        }
        catch
        {
            revNo = -1;
        }
    }
    private void SetSatBStar()
    {
        try
        {

            bStar = Double.Parse(satData[25]);
        }
        catch
        {
            bStar = -1;
        }
    }
    private void SetSatMeanMotionDot()
    {
        try
        {
            meanMotionDot = Double.Parse(satData[27]);
        }
        catch
        {
            meanMotionDot = -1;
        }
    }

    private void SetSatMeanMotionDDot()
    {
        try
        {
            meanMotionDDot = Double.Parse(satData[29]);
        }
        catch
        {
            meanMotionDDot = -1;
        }
    }

    private void SetSatSemiMajorAxis()
    {
        try
        {
            semiMajorAxis = Double.Parse(satData[31]);
        }
        catch
        {
            semiMajorAxis = -1;
        }
    }

    private void SetSatPeriod()
    {
        try
        {
            period = Double.Parse(satData[33]);
        }
        catch
        {
            period = -1;
        }
    }

    private void SetSatApogee()
    {
        try
        {
            apogee = double.Parse(satData[35]);
        }
        catch
        {
            apogee = -1;
        }
    }

    private void SetSatPerigee()
    {
        try
        {
            perigee = double.Parse(satData[37]);
        }
        catch
        {
            perigee = -1;
        }
    }

    private void SetSatLine1()
    {
        line1 = satData[39];
    }

    private void SetSatLine2()
    {
        line2 = satData[41];
    }
    private void SetSatCreatedAt()
    {
        createdAt = satData[43];
    }
    public string GetSatCreatedAt()
    {
        return createdAt;
    }
    private void SetSatCreatedBy()
    {
        createdBy = satData[45];
    }
    public string GetSatCreatedBy()
    {
        return createdBy;
    }
    private void SetSatSource()
    {
        source = satData[47];
    }

    public string GetSatSource()
    {
        return source;
    }
    private void SetSatDataMode()
    {
        dataMode = satData[49];
    }
    private void SetSatAlgorithm()
    {
        algorithm = satData[51];
    }
    private void SetSatOrigNetwork()
    {
        origNetwork = satData[53];
    }
    private void SetSatData()
    {
        satData = satData;
    }
}
