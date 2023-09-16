using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCMCM.MVVM.Models;

public class PharmacyModel
{
    public string PharmacyName { get; set; }
    public string PharmacyAddress { get; set; }
    public string PharmacyPhoneNumber { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
