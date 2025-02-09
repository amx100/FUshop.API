using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Size
{
    public int SizeId { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreatedAt { get; set; }
}
