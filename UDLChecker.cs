using System;
using System.Text;
using System.Net.Http;
using System.Net;
using satelite_tracker_jense;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;

public class UDLChecker
{

    private Form1 form;
    private List<SatelliteInfo> satList  = new List<SatelliteInfo>();
    private int maxResults = 1;
    private int satelliteNumber = 1;
    private string satelliteDate = "";
    private string satelliteAuthor = "";
    private string satelliteSource = "";

    public UDLChecker()
	{
	}

    public void UDL_Get(Form1 formArgument)
    {
        form = formArgument;
        using (var client = new HttpClient())
        {

            // -- Authentication Section -- //
            // Authentication Information will need to be sent with each request for both GET'ing and POST'ing data.
            string username = "YOUR_USERNAME";
            string password = "YOUR_PASSWORD";
            {
                username = "username";
                password = "password";
            }
            // For production code, Username and Password should be kept encrypted and never stored as their plaintext values.

            var basicAuth = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
              Convert.ToBase64String(basicAuth));
            // -- End Authentication Section -- //

            String service_endpoint = "https://unifieddatalibrary.com/";

            /*
               This executes the actual call to the UDL which, in this example, returns the count of all Two-Line Element
               Sets posted in the last two hours.
            */
            var response = client.GetAsync(service_endpoint + "udl/elset?epoch=%3Cnow&maxResults=" + maxResults).Result;

            // Success error codes includes any response code from 200 - 299
            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine("Success!");
                form.textBox1.Text = "Success!";
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                string[] stringSplitters = new string[] { ",", "\":", "\"", "\":\"", ":\"", "{", "}", "[", "]" };
                string[] satValues = responseString.Split(stringSplitters, System.StringSplitOptions.RemoveEmptyEntries);
                int count = 0;
                int satCount = 0;
                for(int i = 0; i < satValues.Length; i++)
                {
                    if(count == 0)
                    {
                        SatelliteInfo satInfoRecord = new SatelliteInfo(satValues[i]);
                        satList.Add(satInfoRecord);
                        count++;
                    }
                    else if (count == 53)
                    {
                        satList[satCount].AddSatData(satValues[i]);
                        satList[satCount].SetSatVariables();
                        count = 0;
                        satCount++;
                    }
                    else
                    {
                        satList[satCount].AddSatData(satValues[i]);
                        count++;
                    }


                }
                    

                
                form.textBox4.Text = string.Empty;
                foreach(var sat in satList)
                {
                    
                    form.comboBox2Update(sat.GetSatNum().ToString());
                }
            }
            else
            {
                /*
                   If your request fails, this will tell you why it failed.
                   A Response of "Forbidden" means that you do not have the proper permissions.
                   A Response of "Unauthorized means that your username and/or password is incorrect or incorrectly encoded.
                */
                //Console.WriteLine("Request Failed. Response: " + response.StatusCode);
                form.textBox1.Text = "Failure!";
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                //Console.WriteLine(responseString);
            }
        }
    }
    public void SetMaxResults(int maxResultsArgument)
    {
        maxResults = maxResultsArgument;
    }

    public void SetSatelliteNumber(string satNumSelectedString)
    {
        satelliteNumber = Int32.Parse(satNumSelectedString);
    }

    public void SelectSpecificSatelliteToDisplay()
    {
        var value =
            from sat in satList
            where sat.GetSatNum() == satelliteNumber
            orderby sat.revNo
            select sat;

        foreach (var sat in value)
        {
            sat.GetSatData(form);
            satelliteDate = sat.GetSatCreatedAt();
            satelliteAuthor = sat.GetSatCreatedBy();
        }
        form.updateTextBox(satelliteNumber.ToString(), form.textBox2);

        form.updateTextBox(value.Count().ToString(), form.textBox3);
        form.updateTextBox(satelliteDate.ToString(), form.textBox6);
        form.updateTextBox(satelliteAuthor.ToString(), form.textBox5);
    }

    public void SetSatCreationDate(string selectedCreationDate)
    {
        satelliteDate = selectedCreationDate;
    }

    public void SetSatCreatedBy(string selectedCreatedBy)
    {
        satelliteAuthor = selectedCreatedBy;
    }

    public void SetSatSource(string selectedSource)
    {
        satelliteSource = selectedSource;
    }

    public void SatelliteNumberCreationOrder()
    {
        var value =
            from sat in satList
            where sat.GetSatNum() == satelliteNumber
            orderby sat.createdAt
            select sat;

        foreach (var sat in value)
        {
            sat.GetSatData(form);
            satelliteDate = sat.GetSatCreatedAt();
            satelliteAuthor = sat.GetSatCreatedBy();
        }
        form.updateTextBox(satelliteNumber.ToString(), form.textBox2);

        form.updateTextBox(value.Count().ToString(), form.textBox3);
        form.updateTextBox(satelliteDate.ToString(), form.textBox6);
        form.updateTextBox(satelliteAuthor.ToString(), form.textBox5);
    }

}
