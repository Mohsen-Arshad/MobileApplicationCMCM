using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCMCM.MVVM.Models;

public class RequestModel
{
    public int CategoryId { get; set; }
    public string Subject { get; set; }
    public string RequestComment { get; set; }
    public string DocFile { get; set; }
}
