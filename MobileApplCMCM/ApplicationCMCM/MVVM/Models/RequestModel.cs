using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCMCM.MVVM.Models;

public class RequestModel
{
    public int id { get; set; }
    public int UserId {  get; set; }
    public int CategoryId { get; set; }
    public int DocumentId {  get; set; }
    public string Subject { get; set; }
    public string RequestComment { get; set; }
    public string RequestStatus { get; set; }
    public bool IsComplete { get; set; }
    public bool IsArchived { get; set; }
    public byte[] FileData { get; set; }
}
